// 登录用户的仓库数据
import {loginUser} from "../services/loginUser"

export default{
    // 哈哈 是namespaced！
    namespaced: true, //开启命名空间, 防止重名属性，哈哈。
    // state就是仓库的具体存储的数据， 哈哈。
    state: {
        // 当前正在登录的用户
        userInfo: null,
        token: '',
        isLoading: false,
    },

    // 组件里面不能改仓库数据，在vuex中必须提交mutation：改变
    // 需要commit一个mutation，放在mutations中配置
    mutations: {
        //配置数据的变异方式
        //获取，销毁，等数据变化
        // state 原来的数据
        // payload 负荷，可以传递任何东西
        setToken(state, payload) {
            state.token = payload;
        },
        setIsLoading(state, payload){
            state.isLoading = payload;
        },
    },
    // 不能出现副作用操作，即只能更改仓库里的数据
    // eg： 改动使用外部数据， ajax， localstorage， 其他异步行为
    // 所以出现了action！！配置和mutations差不多
    actions: {
        // 异步函数
        // context 相当于一个仓库对象
        // payload 是一个负荷
        async loginUser(context){
            //isloading为treu
            // 不能呢直接改动数据，仍然需要提交commit一个mutation
            context.commit("setIsLoading", true);     

            var data = await loginUser();
            console.log(data);
            if(data.status){
                let token = "Bearer " + data.data;
                context.commit("setToken", token);      
            }
            
            context.commit("setIsLoading", false);
        }
    },
}
