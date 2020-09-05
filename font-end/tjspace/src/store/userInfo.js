import { loginUser, logoutUser, registerUser } from "../services/userService"

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
            var resp = await loginUser(payload);
            console.log(resp);
            if (resp.status) {
                // context.commit("setUserInfo", {
                //     email : payload.email,
                // });
                context.commit('setToken', "Bearer " + resp.data)
            }
            context.commit("setIsLoading", false);
        },
        /**
         * 退出登录，将数据仓库中的用户信息置空
         * @param {*} context 
         */
        async logoutUser(context) {
            context.commit("setIsLoading", true);
            var resp = await logoutUser()
            if (resp)
                context.commit("setIsLoading", false);
        },
        /**
         * 注册用户
         * @param {*} context 
         * @param {Object} payload 传入邮箱，密码。用户名，昵称
         */
        async registerUser(context, payload) {
            context.commit("setIsLoading", true);
            var resp = await registerUser(payload)
            context.commit("setIsLoading", false);
            return resp
        }
    },
}