<template>
  <div class="card" style="width:800pt" >


    <q-card class="my-card" style="width:600pt; margin-left:100pt">
      <q-card-section >
        <div class="text-h6">个人信息</div>
      </q-card-section>

      <q-separator />

      <q-card-section style="margin-top:20pt">
        <div class='row' style="font-size:20px" >
          <div class="col-6" >昵称:   {{Nickname}}</div>
          <div class="col-6" style="text-align: center">姓名:   {{Name}}</div>
        </div>
      </q-card-section>

      <q-card-section style="margin-top:20pt">
        <div class='row' style="font-size:20px">
          <div class="col-6" >学号:   {{ID}}</div>
          <div class="col-6" style="text-align: center">年级:   {{Grade}}</div>
        </div>
      </q-card-section>
      <q-card-section style="margin-top:20pt">
        <div class='row' style="font-size:20px">
          <div class="col-6" >主修专业:   {{Major}}</div>
          <div class="col-6" style="text-align: center">辅修专业:   {{Minor}}</div>
        </div>
      </q-card-section>

      <q-card-section>
        {{ lorem }}
      </q-card-section>

      <q-separator  />

      <q-card-actions >
        <q-btn style="margin:0 auto">修改个人信息</q-btn>
      </q-card-actions>
    </q-card>


    <CourseInfo />

    <TeacherInfo />

    <CommentInfo />

    <br>
    <br>
    <br>
    <br>

      
  </div>
</template>




<script>
import TeacherInfo from './TeacherInfo';
import CourseInfo from './CourseInfo';
import CommentInfo from './CommentInfo';
export default {
    components:{
      TeacherInfo,
      CourseInfo,
      CommentInfo
    },
    name:"SelfInfoModify",
    props:{
        SelfInfo:{
            type: Object,
            default:()=>{
                return {
                    
                }
            }
        }
    },

    data () {
    return {
        Nickname:'lili',
        Grade:'大二',
        Major:'软件工程',
        Minor:'无',
        Name:'黎力',
        ID:'1853549',

      
      
    }
  }

}
</script>

<style>
.card{
  margin-top: 50pt;
  margin-left: 200pt;
  height: 400pt;
}
.text-subtitle2{
  margin-top: 40pt;
  margin-left: 50pt;
}
.Information{
  display: inline-block;
}
.button{
  margin-top: 20pt;
  margin-left: 50pt;
  margin-bottom: 50pt;
}
</style>