<template>
  <div class="card" style="width:800pt">
    <div class="text-h5">个人信息</div>

    <q-card class="my-card">
      <q-card-section>
        
        <div class="text-subtitle2">
          <div class='row' style="font-size:20px">
            <div class="col-4 ">昵称:   {{Nickname}}</div>
            <div class="col-4 ">姓名:   {{Name}}</div>
            <div class="col-4 ">学号:   {{ID}}</div>
          </div>
        </div>

        <div class="text-subtitle2">
          <div class='row' style="font-size:20px">
            <div class="col-4 ">年级:   {{Grade}}</div>
            <div class="col-4 ">主修专业:   {{Major}}</div>
            <div class="col-4 ">辅修专业:   {{Minor}}</div>
          </div>
        </div>

      
      </q-card-section>

      <q-separator />

    </q-card>

    <q-btn color="white" text-color="black" label="修改信息" class='button'/>

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
    // computed: {
    //   clickaction(){
    //     console.log("clickhere!");
    //     return console.log("clickhere!")
    //   }
    // },
    data () {
    return {
        Nickname:'lili',
        Grade:'大二',
        Major:'软件工程',
        Minor:'',
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