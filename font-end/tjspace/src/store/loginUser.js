// 登录用户的仓库数据
export default{
    namespace: true, //开启命名空间
    state: {
        data: null,
        isLoading: false,
    },
    mutation:{
        setIsLoading(state, payload){
            state.isLoading = payload;
        },
        setData(state, payload){
            state.data = payload;
        }
    },
    actions:{
        login(context, payload){
            context.commit("setIsLoading", true);
            

            context.commit("setIsLoading", false);
        }
    }
}