<template>
  <div id="app">
    <layout>
      <!-- 根据不同的访问路径，渲染不同的组件(page)！ -->
      <!-- hash: 使用/#/后面的路径对应路径；兼容性较好；实际上只需要跟新组件 -->
      <!-- history：路径来自于真实的路径地址；就浏览器兼容不好 -->
      <!-- abstract：路径来自于内存，不体现在地址中 -->
      <template v-slot:main>
        <!-- <router-view></router-view> -->
        <div style="width:300px">
          in data: {{dataToken}}
          <br>
          in store: {{$store.state.userInfo.token}}
          <br>
          in mapState: {{token}}
          <br>
          isLoading: {{isLoading? "true" : "false"}}
        </div>
      </template>
     
    </layout>
  </div>
</template>

<script>



import layout from "./components/layout"

// 配置到service中
import axios from 'axios'

// 使用仓库数据！
// mapState辅助函数
import { mapState } from "vuex";

export default {

  // 在这里修改数据！
  // 可以使得vuex 检测到所有的数据改动
  created(){
    this.$store.commit('userInfo/setToken', "asdasd");
    this.$store.dispatch("userInfo/loginUser");
  },

  name: 'APP',
  computed:{
    //ES6 展开运算符
    ...mapState("userInfo", ["token", "isLoading"]),

  },
  components: {
    layout,
  },
  methods:{

  },
  data () {
    return {
      myData:'None',
      dataToken:"haha"
    }
  },

  async mounted(){
    let res = await axios.get("http://175.24.115.240:8080/api/Login/login?email=111&password=111");
    console.log(res);
    this.myData = res.data.data;
    this.dataToken  = 'Bearer ' + res.data.data
  },
}
</script>

<style>
  @import '~@/styles/global.css';
</style>
