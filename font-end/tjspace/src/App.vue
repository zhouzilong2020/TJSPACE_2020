<template>
  <div id="app">
    <layout>
      <!-- 根据不同的访问路径，渲染不同的组件(page)！ -->
      <!-- hash: 使用/#/后面的路径对应路径；兼容性较好；实际上只需要跟新组件 -->
      <!-- history：路径来自于真实的路径地址；就浏览器兼容不好 -->
      <!-- abstract：路径来自于内存，不体现在地址中 -->
      <template v-slot:main>
        <router-view></router-view>
      </template>
    </layout>
  </div>
</template>

<script>
import layout from "./components/layout"
// import axios from 'axios'
export default {
  name: 'APP',
  components: {
    layout,
  },
  methods:{

  },
  data () {
    return {
      myData:'None'
    }
  },

  // mounted(){
  //   axios.get("http://175.24.115.240:8080/api/Login/login?email=111&password=111").then((res) => {
  //     this.myData =res.data;
  //   })
  // },
}
</script>

<style>
  @import '~@/styles/global.css'
</style>
