<template>
  <div class="card" style="margin:0 auto; max-width:800pt">
    <q-card class="my-card" style="margin:0 auto; max-width: 600pt">
      <q-card-section>
        <div class="text-h6">个人信息</div>
      </q-card-section>

      <q-separator />

      <q-card-section style="margin-top: 20pt">
        <div class="row" style="font-size: 20px">
          <div class="col-6">昵称: {{ userInfo.nickname }}</div>
          <div class="col-6" style="text-align: center">性别: {{ Gender }}</div>
        </div>
      </q-card-section>

      <q-card-section style="margin-top: 20pt">
        <div class="row" style="font-size: 20px">
          <div class="col-6">手机号: {{ userInfo.phonenumber }}</div>
          <div class="col-6" style="text-align: center">年级: {{ Grade }}</div>
        </div>
      </q-card-section>
      <q-card-section style="margin-top: 20pt">
        <div class="row" style="font-size: 20px">
          <div class="col-6">主修专业: {{ Major }}</div>
          <div class="col-6" style="text-align: center">
            学历: {{ Degree }}
          </div>
        </div>
      </q-card-section>

      <q-separator />

      <q-card-actions>
        <q-btn style="margin: 0 auto">
          <router-link :to="{ name: 'SelfInfoModify', params: { userid: userInfo.userid } }">
            修改个人信息
          </router-link> 
        </q-btn>
      </q-card-actions>
    </q-card>
    <CourseInfo />
    <TeacherInfo />
    <CommentInfo />
    <br />
    <br />
    <br />
    <br />
  </div>
</template>

<script>
import TeacherInfo from "../components/homepage/TeacherInfo";
import CourseInfo from "../components/homepage/CourseInfo";
import CommentInfo from "../components/homepage/CommentInfo";
import {mapState} from 'vuex'

export default {
  components: {
    TeacherInfo,
    CommentInfo,
    CourseInfo,
  },
  

  data() {
    return {
      inputSearch: "",
      logoPath: require("../assets/TJU.png"),
      avatarPath: require("../assets/boy-avatar.png"),
      avatarBGPath: require("../assets/material.png"),
      drawer: false,
      active: -1,
      Grade: '',
      Major: '',
      Gender:'',
      Degree:''
    };
  },

  computed:mapState('userInfo', ['userInfo']),
  created(){
    console.log('in homepage created', this.userInfo)

    switch(this.userInfo.gender)
    {
      case 0: 
        this.Gender='男';
        break;
      case 1: 
        this.Gender='女';
        break;
    }
    switch(this.userInfo.majorid)
    {
      case '1': 
        this.Major='软件工程';
        break;
      case '2': 
        this.Major='土木工程';
        break;
      case '3': 
        this.Major='经济与管理';
        break;
    }
    switch(this.userInfo.year)
    {
      case 1: 
        this.Grade='大一';
        break;
      case 2: 
        this.Grade='大二';
        break;
      case 3: 
        this.Grade='大三';
        break;
      case 4: 
        this.Grade='大四';
        break;
    }
    switch(this.userInfo.degree)
    {
      case 1: 
        this.Degree='本科生';
        break;
      case 2: 
        this.Degree='研究生';
        break;
      case 3: 
        this.Degreer='博士生';
        break;
    }

    

  },

  



};
</script>

<style scoped>
.card {
  margin-top: 50pt;
  height: 400pt;
}
.text-subtitle2 {
  margin-top: 40pt;
  margin-left: 50pt;
}
.Information {
  display: inline-block;
}
.button {
  margin-top: 20pt;
  margin-left: 50pt;
  margin-bottom: 50pt;
}
</style>