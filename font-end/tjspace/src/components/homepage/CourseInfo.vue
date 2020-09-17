<template>
    <div class="q-pa-md" style="max-width: 100%">
    <q-list bordered separator>

      <q-item >
        <q-item-section>
            <q-item-label >收藏课程</q-item-label>
        </q-item-section>
      </q-item>

      <q-item class="row" >
          <q-item-section class="justify-evenly" style="margin-left:30px">课程名称</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">课程编号</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">开设学院</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">学分</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">教师名称</q-item-section>
          <q-item-section class="col-1" style="text-align: center"></q-item-section>
      </q-item>


      
      <q-scroll-area style="height: 200px">


        <q-item class="row" v-for="(i,index) in collectedcourse" :key='index'>
          <q-item-section clickable v-ripple  class="justify-evenly" style="margin-left:30px" @click="click()">{{ i.courseName }}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{ i.courseId }}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{ i.deptName }}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{ i.credit }}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{ i.teacherName }}</q-item-section>
          <q-btn class="col-1" size="12px" flat dense round icon="delete" @click="cancelCollect(i.courseId,i.teacherId)" />
        </q-item>

        <q-item class="row" @click="click()">
          <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{CourseID}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{College}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{Credit}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{Teacher}}</q-item-section>
          <q-btn class="col-1" size="12px" flat dense round icon="delete"  />
        </q-item>

 
      </q-scroll-area>
    </q-list>
  </div>  
</template>

<script>
import axios from 'axios'
import {mapState} from 'vuex'
import { token } from '../../services/config'
export default {
    data () {
    return {     
          Name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金',
          collectedcourse:[]
    }
    },
     computed:{
       ...mapState('userInfo', ['userInfo']),
       ...mapState("collectedCourse", ["courseName","courseId","deptName","credit","teacherName","teacherId:","isLoading","userId"]),
     },
     methods:{
      click(){
        alert("ok!")  
      },
      async getCollectedCourse() {
        await this.$store.dispatch("collectedCourse/getCollectedCourse", this.userInfo);
    },
    async cancelCollect(courseId,teacherId){
       let res = await axios.post("http://175.24.115.240:8080/api/Course/CancelCollectCourse", {},{
            headers: {
              Authorization: token,
            },
            params: {
                userId:this.userInfo.userid,
                courseId:courseId,
                teacherId:teacherId
            },
           
        })
        this.msg=res.data
        console.log('data in courseInfo:' , this.msg)
        this.getCollectedCourse()
        //  console.log('data in courseInfo:' , this.userInfo.userid,courseId,teacherId)
    }

    },

    created(){
      this.getCollectedCourse()
    }

}
</script>

<style>

</style>