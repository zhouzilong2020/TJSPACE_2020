// 登录用户的仓库数据
import {loginUser, logoutUser} from "../services/userService"

export default{
    namespaced: true,
    state: {
        userInfo: null,
        isLoading: false,
    },
    mutations: {
        setUserInfo(state, payload){
            state.userInfo = payload;
        },
        setToken(state, payload) {
            state.token = payload;
        },
        setIsLoading(state, payload){
            state.isLoading = payload;
        },
    },
 
    actions: {
        async loginUser(context, payload){
            context.commit("setIsLoading", true);     
            var resp = await loginUser(payload);
            console.log(resp);
            if(resp.status){
                let token = "Bearer " + resp.data;
                context.commit("setToken", token);      
            }
            context.commit("setIsLoading", false);
        },
        async logoutUser(context){
            context.commit("setIsLoading", true);   
            var resp = await logoutUser()
            if(resp)
            context.commit("setIsLoading", false);
        }
    },
}
