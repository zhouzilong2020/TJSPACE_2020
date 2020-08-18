<template>
  <div>
    <!-- <course-info /> -->
    <!-- <forun /> -->
    <!-- <SearchCourse /> -->
    <!-- <homepage /> -->
    <!-- <self-info-modify /> -->
    <!-- <BBSHomePage /> -->
    <MakeComment />


    {{myData}}
  </div>
</template>

<script>
// import CourseInfo from './page/CourseInfo'
// import Forun from './page/Forum'
// import SearchCourse from './page/SearchCourse'
// import Homepage from './page/Homepage'
// import SelfInfoModify from './page/SelfInfoModify'
// import BBSHomePage from './page/BBSHomePage'
import MakeComment from './page/MakeComment'

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
    MakeComment,
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
