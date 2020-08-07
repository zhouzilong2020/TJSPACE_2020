<template>
  <q-layout view="hHh lpR fFf">

    <q-header reveal bordered class="bg-primary text-white" height-hint="98">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="drawer = !drawer" />
        <q-toolbar-title>
          TJSPACE · 同济大学社群
        </q-toolbar-title>

        <!-- 搜索栏 -->
        <q-input dark dense standout v-model="inputSearch" input-class="text-left" class="q-ml-md" placeholder="发现更多课程">
          <template v-slot:append>
            <q-icon v-if="text === ''" name="search" />
            <q-icon v-else name="clear" class="cursor-pointer" @click="text = ''" />
          </template>
        </q-input>

      </q-toolbar>
    </q-header>  

    <!-- 侧边栏 -->
    <q-drawer
    class="drawer"
    show-if-above
    flat
    v-model="drawer"
    :width="200"
    :breakpoint="1000"
    >
    <q-scroll-area style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd">
      <q-list padding>

        <q-item :active="active == 0" @click="active=0" clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="home" />
          </q-item-section>
          <q-item-section>
            个人主页
          </q-item-section>
        </q-item>

        <q-item :active="active == 1" @click="active=1" clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="star" />
          </q-item-section>
          <q-item-section>
            我的收藏
          </q-item-section>
        </q-item>

        <q-item :active="active == 2" @click="active=2" clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="drafts" />
          </q-item-section>
          <q-item-section>
            我的消息
          </q-item-section>
        </q-item>

        

      </q-list>
    </q-scroll-area>
    <!-- 头部的背景图片和用户信息、头像 -->
    <q-img class="absolute-top" :src="avatarBGPath" style="height: 160px">
      <div class="absolute-bottom bg-transparent">
        <q-avatar size="56px" class="q-mb-sm">
          <img :src="avatarPath">
        </q-avatar>
        <div class="text-weight-bold">  欢迎你！  {{userInfo.nickName}}</div>
        <div>{{userInfo.eMail}}</div>
      </div>
    </q-img>
    </q-drawer>
  

    <q-page-container class="body row justify-evenly">
      
      
      <q-page-container class="detail body-left">
        <course-detail   />
      </q-page-container>

      <q-page-container class="body-right">
        <div class="course-head" >
          <course-head />
        </div>

        <div class="option-group row justify-between">
            <q-select
              v-model="model"
              label="选择排序方式"
              :options="stringOptions"
              style="width: 250px"
              behavior="menu"
            />
            <q-select
              v-model="model"
              label="选择其他学院"
              :options="stringOptions"
              style="width: 250px"
              behavior="menu"
            />
            <q-btn color="primary" icon-right="comment" label="撰写评论" unelevated />
          </div>
      
        <div class="course-comment">
          <course-comment />
          <course-comment />
          <course-comment />
        </div>

      </q-page-container>


    </q-page-container>

    <q-footer reveal bordered class="bg-grey-8 text-white">
      <q-toolbar>
        <q-toolbar-title>
          <q-avatar>
            <img :src="logoPath">
          </q-avatar>
          TJSPACE·同济大学社群 2020
        </q-toolbar-title>
      </q-toolbar>
    </q-footer>

  </q-layout>
</template>

<script>
import CourseHead from './CourseHead'
import CourseDetail from './CourseDetail'
import CourseComment from './CourseComment'
export default {
  components:{
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
  }
}
</script>

<style>
.header{background-color:#0025abcc}
.body{width: 100%;}

.header .header-search{color: aliceblue;}
.body .body-left{position: fixed; left:15px; top:15px;}
.body .body-right{position: absolute; right:15px; top:0; padding:0; left:245px; }

.body .body-right .course-head{margin-top:15px;}
.body .body-right .course-comment{margin-top:15px;}
.body .body-right .option-group{margin-top:15px}


</style>


// <style lang="scss">
// .header{color: $blue-10;}
// </style>