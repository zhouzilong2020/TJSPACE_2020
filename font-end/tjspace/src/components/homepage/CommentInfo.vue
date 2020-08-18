<template>

  <div class="q-pa-md" style="max-width: 100%">
    <q-list bordered separator>

      <q-item >
        <q-item-section>
            <q-item-label >历史评价</q-item-label>
        </q-item-section>
      </q-item>


      <q-item clickable v-ripple class="row">
        <q-item-section class="justify-evenly" style="margin-left:30px">评价课程</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">评价序号</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">点赞数</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">回复数</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">评价时间</q-item-section>
      </q-item>

      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CommentID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Like}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Reply}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Time}}</q-item-section>
      </q-item>

      <q-item clickable v-ripple class="row" @click="click">
        <q-item-section class="justify-evenly" style="margin-left:30px">{{Name}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{CommentID}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Like}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Reply}}</q-item-section>
        <q-item-section class="justify-evenly" style="text-align: center">{{Time}}</q-item-section>
      </q-item>    
    </q-list>
  </div>  
</template>

<script>
export default {
    data () {
    return {
          Name: '数据库原理与应用',
          CommentID:1000000,
          Like:100,
          Reply:5,
          Time:'2020.8.31'
       
    }
    },

}
</script>

<style>

</style>