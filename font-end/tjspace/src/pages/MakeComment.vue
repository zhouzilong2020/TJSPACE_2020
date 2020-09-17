<template>
  <div>
      <q-page-container class="body-right">
          <div class="course-comment">
          <course-comment />
          </div>
      </q-page-container>
  </div>
</template>

<script>

import CourseComment from '../components/sfz/CourseComment'
export default {
  components:{
    CourseComment,
  },
  data () {
    return {
      inputSearch:'',
      logoPath : require("../assets/TJU.png"),
      avatarPath: require("../assets/boy-avatar.png"),
      avatarBGPath: require("../assets/material.png"),
      drawer : false,
      active : -1,
      courseInfo:{
        
      },
      userInfo:{
        nickName: "lili",
        eMail:"1888888@tongji.edu.cn",
      },
      
    }
  },

  mounted () {

  }
}
</script>

<style>
.body{width: 100%;}
.body .body-left{position: fixed; left:15px; top:15px;}
.body .body-right{position: absolute; right:15px; top:0; padding:0; left:245px; }

.body .body-right .course-head{margin-top:15px;}
.body .body-right .course-comment{margin-top:15px;}
.body .body-right .option-group{margin-top:15px}
</style>

