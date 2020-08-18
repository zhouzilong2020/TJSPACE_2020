<template>
  <div>
    <!-- <course-info /> -->
    <!-- <forun /> -->
    <!-- <SearchCourse /> -->
    <!-- <homepage /> -->
    <!-- <self-info-modify /> -->
    <!-- <BBSHomePage /> -->
    <!-- <MakeComment /> -->
    <!-- 根据不同的访问路径，渲染不同的组件(page)！ -->
    <!-- hash: 使用/#/后面的路径对应路径；兼容性较好；实际上只需要跟新组件 -->
    <!-- history：路径来自于真实的路径地址；就浏览器兼容不好 -->
    <!-- abstract：路径来自于内存，不体现在地址中 -->
    <router-view></router-view>
  </div>
</template>

<script>
// import CourseInfo from './page/CourseInfo'
// import Forun from './page/Forum'
// import SearchCourse from './page/SearchCourse'
// import Homepage from './page/Homepage'
// import SelfInfoModify from './page/SelfInfoModify'
// import BBSHomePage from './page/BBSHomePage'
// import MakeComment from './page/MakeComment'

import axios from 'axios'
export default {
  name: 'APP',
  components: {
    // CourseInfo,
    // Forun,
    // SearchCourse,
    // Homepage,
    // SelfInfoModify,
    // BBSHomePage,
    // workshop,
    // MakeComment,
  },
  methods:{

  },
  data () {
    return {
      myData:'None'
    }
  },

  mounted(){
    axios.get("http://175.24.115.240:8080/api/Login/login?email=111&password=111").then((res) => {
      this.myData =res.data;
    })
  },
}
</script>

<style>
</style>
