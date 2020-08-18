<template>
    <div class="q-pa-md" style="max-width: 100%">
    <q-list bordered separator>

      <q-item >
        <q-item-section>
            <q-item-label >收藏课程</q-item-label>
        </q-item-section>
      </q-item>


      <q-item clickable v-ripple class="row">
        <q-item-section class="justify-evenly" style="margin-left:30px">课程名称</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">课程序号</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">开设学院</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">开设年级</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">学分</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">任课老师</q-item-section>
      </q-item>

      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item>

      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item> 

      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item> 

      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item>  

      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item>   
        
      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item>   
        
      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item>   
        
      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item>   
        
      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CourseID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{College}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Semester}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Credit}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Teacher}}</q-item-section>
      </q-item>    
    </q-list>
  </div>  
</template>

<script>
export default {
    data () {
    return {     
          Name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
    }
    }

}
</script>

<style>

</style>