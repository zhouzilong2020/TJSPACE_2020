<template>

  <div class="q-pa-md" style="max-width: 100%">
    <q-list bordered separator>

      <q-item >
        <q-item-section>
            <q-item-label >历史评价</q-item-label>
        </q-item-section>
      </q-item>


      <div>


      <q-item class="row">
        <q-item-section class="justify-evenly" style="margin-left:30px">评价课程</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: left">评价序号</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: left">点赞数</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: left">点踩数</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: left">评价时间</q-item-section>
      </q-item>
      <q-scroll-area style="height: 200px">

        <q-item class="row" v-for="(i,index) in commentInfo" :key='index' >
          <q-item-section clickable v-ripple  class="justify-evenly" style="margin-left:30px" @click="click()">{{i.courseid}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{CommentID}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{i.usefulnum}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{i.uselessnum}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{i.date.slice(0,10)}}</q-item-section>
        </q-item>

        <q-item class="row" @click="click">
          <q-item-section clickable v-ripple  class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{CommentID}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{Like}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{Reply}}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{Time}}</q-item-section>
        </q-item> 
      </q-scroll-area>   
      </div>
    </q-list>
  </div>  
</template>

<script>
import {mapState} from 'vuex'
import axios from 'axios'
import { token } from '../../services/config'
export default {
    data () {
    return {
          Name: '数据库原理与应用',
          CommentID:1000000,
          Like:100,
          Reply:5,
          Time:'2020.8.31',
          commentInfo:[]
    }
    },
    computed:mapState('userInfo', ['userInfo']),
     methods:{
      click(){
        alert("ok!")  
      },
      async getCommentInfo() {
        let res = await axios.get("http://175.24.115.240:8080/api/Show/personalcomment", {
            headers: {
              Authorization: token,
            },
            params: {
                userId:this.userInfo.userid
            }
        })
        this.commentInfo=res.data.data
        console.log('data in commentinfo:' , this.commentInfo)
    },
    },
    

    created(){
      this.getCommentInfo()
      
    }

}
</script>

<style>

</style>