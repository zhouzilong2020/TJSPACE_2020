<template>
  <q-layout view="hHh lpR fFf">

    <q-header reveal bordered class="bg-primary text-white" height-hint="98">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="drawer = !drawer" />
        <q-toolbar-title>
          TJSPACE · 同济大学社群
        </q-toolbar-title>
      </q-toolbar>
    </q-header>
    
    <div>
      <HomePage />
    </div>



    <q-drawer
    v-model="drawer"
    show-if-above
    :width="200"
    :breakpoint="400"
    >
    <q-scroll-area style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd">
      <q-list padding>

        <q-item :active="active == 0" @click="active=0" clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="inbox" />
          </q-item-section>
          <q-item-section>
            Inbox
          </q-item-section>
        </q-item>

        <q-item :active="active == 1" @click="active=1" clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="star" />
          </q-item-section>

          <q-item-section>
            Star
          </q-item-section>
        </q-item>

        <q-item :active="active == 2" @click="active=2" clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="send" />
          </q-item-section>

          <q-item-section>
            Send
          </q-item-section>
        </q-item>

        <q-item :active="active == 3" @click="active=3" clickable v-ripple>
          <q-item-section avatar>
            <q-icon name="drafts" />
          </q-item-section>

          <q-item-section>
            Drafts
          </q-item-section>
        </q-item>
      </q-list>
    </q-scroll-area>

    <q-img class="absolute-top" src="https://cdn.quasar.dev/img/material.png" style="height: 150px">
      <div class="absolute-bottom bg-transparent">
        <q-avatar size="56px" class="q-mb-sm">
          <img src="https://cdn.quasar.dev/img/boy-avatar.png">
        </q-avatar>
        <div class="text-weight-bold">{{userInfo.nickName}}</div>
        <div>{{userInfo.eMail}}</div>
      </div>
    </q-img>
    </q-drawer>
  


    <q-page-container class="body row justify-evenly">

      <q-page-container class="detail">
        <course-detail />
      </q-page-container>

      <q-page-container class="comment">
        <course-comment />
        <course-comment />
        <course-comment />
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
import HomePage from './HomePage'

export default {
  components:{
    HomePage,
  },

  data () {
    return {
      logoPath : require("../assets/TJU.png"),
      drawer : false,
      active : -1,
      courseInfo:{
        
      },
      userInfo:{
        nickName: "a name",
        eMail:"a eMail"
      }
    }
  }
}
</script>

<style>
.header{background-color:#0025abcc}
.body{width: 100%;}

.body .comment{margin-right:20px; position: absolute; left:280px}
.body .detail{position: fixed; left:20px}

.body .statistic{ margin: 0 auto;}

</style>


// <style lang="scss">
// .header{color: $blue-10;}
// </style>