<template>
   
  <div class="q-pa-md" style="max-width: 100%">
    <q-list bordered separator>

      <q-item >
        <q-item-section>
            <q-item-label >收藏教师</q-item-label>
        </q-item-section>
      </q-item>


      <q-item clickable v-ripple class="row">
        <q-item-section class="col-3">教师名称</q-item-section>
        <q-item-section class="col-2">教师序号</q-item-section>
        <q-item-section class="col-2">所属学院</q-item-section>
        <q-item-section class="col-3">开设课程数量</q-item-section>
        <q-item-section class="col-2">评分</q-item-section>
      </q-item>

      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="col-3">{{Name}}</q-item-section>
        <q-item-section class="col-2">{{TeacherID}}</q-item-section>
        <q-item-section class="col-2">{{College}}</q-item-section>
        <q-item-section class="col-3">{{CourseNum}}</q-item-section>
        <q-item-section class="col-2">{{Score}}</q-item-section>
      </q-item>

      <q-item clickable v-ripple class="row">
        <q-item-section class="col-3">{{Name}}</q-item-section>
        <q-item-section class="col-2">{{TeacherID}}</q-item-section>
        <q-item-section class="col-2">{{College}}</q-item-section>
        <q-item-section class="col-3">{{CourseNum}}</q-item-section>
        <q-item-section class="col-2">{{Score}}</q-item-section>
      </q-item>

      
    </q-list>
  </div>
    
</template>

<script>
export default {
    data () {
    return {
      Name: '袁时金',
      TeacherID:10000001,
      College:'软件学院',
      CourseNum:2,
      Score:'0.1',
    }
    },
    methods:{
      click(){
        alert("ok!")  
      }
    }

}
</script>

<style>

</style>