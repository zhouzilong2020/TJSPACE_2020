<template>
    <layout>
        <template v-slot:main> 
            <q-page-container class="detail body-left">
                <course-detail   />
            </q-page-container>
            <q-page-container class="body-right">
                <div class="course-head" >
                <course-head />
                </div>      
                <div class="course-comment">
                <course-comment />
                </div>

            </q-page-container>
        </template>
    </layout>
</template>

<script>
import CourseHead from '../components/courseInfo/CourseHead'
import CourseDetail from '../components/courseInfo/CourseDetail'
import CourseComment from '../components/sfz/CourseComment'
import layout from '../components/layout'
export default {
  components:{
    layout,
    CourseDetail,
    CourseComment,
    CourseHead,
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

