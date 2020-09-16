import { loginUser, registerUser, getUserInfo } from "../services/userService"
import { setCookie, getCookie, removeCookie } from '../utils/utils'
/**
 * 用户登录的数据仓库
 */
export default {
    namespaced: true,
    state: {
        userInfo: null,
        token: null,
        isLoading: false,
    },
    mutations: {
        /**
         * 修改个人信息
         * @param {*} state 指向本仓库的state
         * @param {Object} payload payload以object形式传入，包括nickname，userid，email等
         */
        setUserInfo(state, payload) {
            state.userInfo = payload;
        },
        /**
         * 修改是否正在加载
         * @param {*} state 指向本仓库的state
         * @param {boolean} payload payload传入true or false
         */
        setIsLoading(state, payload) {
            state.isLoading = payload;
        },
        /**
         * 设置token
         * @param {*} state 
         * @param {*} payload 
         */
        setToken(state, payload) {
            state.token = payload;
        }
    },

    actions: {
        /**
         * 登录用户
         * @param {*} context 
         * @param {Object} payload payload传入email，password
         */
        async loginUser(context, payload) {
            context.commit("setIsLoading", true);

            let token = getCookie('TJSPACE-token')
            let userId = getCookie('TJSPACE-userId')
            if (token && userId) {
                // 如果cookie中有保存用户信息，则使用cookie登录
                var resp = await getUserInfo({
                    userId,
                    token
                })
                console.log('after cookie resp', resp)
                if (resp) {
                    //成功获取到了用户信息
                    context.commit("setUserInfo", resp)
                    context.commit("setToken", token)
                }
            }

            else {
                var resp1 = await loginUser(payload);
                console.log(resp1);
                if (resp1.status) {
                    // 登录成功，记录其token
                    context.commit('setToken', "Bearer " + resp1.data1)
                    // 使用token获取用户个人信息
                    if (resp1.data1) {
                        var resp2 = await getUserInfo({
                            userId: resp1.data2,
                            token: 'Bearer ' + resp1.data1
                        })
                    }
                    if (resp2) {
                        context.commit("setUserInfo", resp2)
                        setCookie('TJSPACE-token', 'Bearer ' + resp1.data1, 2)
                        setCookie('TJSPACE-userId', resp1.data2)
                    }
                }
            }
            context.commit("setIsLoading", false);
        },
        /**
         * 退出登录，将数据仓库中的用户信息置空
         * @param {*} context 
         */
        async logoutUser(context) {
            console.log("in store logoutUser")

            await context.commit('setToken', null)
            context.commit('setUserInfo', null)

            // 清楚相应的cookie
            removeCookie('TJSPACE-token')
            removeCookie('TJSPACE-userId')

            return true
        },
        /**
         * 注册用户
         * @param {*} context 
         * @param {Object} payload 传入邮箱，密码。用户名，昵称
         */
        async registerUser(context, payload) {
            context.commit("setIsLoading", true);
            var resp = await registerUser(payload)
            console.log("reg user resp:", resp)
            // 注册成功
            if (resp.status) {
                resp = await loginUser({
                    account: {
                        email: payload.email,
                        password: payload.password
                    }
                });
                console.log("login user", resp);
                if (resp.status) {
                    // 登录成功，记录其token
                    context.commit('setToken', "Bearer " + resp.data1)
                    // 使用token获取用户个人信息
                    if (resp.data1) {
                        var resp2 = await getUserInfo({
                            userId: resp.data2,
                            token: 'Bearer ' + resp.data1
                        })
                    }
                    if (resp2) {
                        context.commit("setUserInfo", resp2)
                    }
                }
            }
            context.commit("setIsLoading", false);
            return resp
        }
    },
}
