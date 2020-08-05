<template>
  <q-drawer
  v-model="drawer"
  show-if-above
  :width="250"
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
</template>

<script>
export default {
  name:"LeftDrawer",
  props:{
      drawer:{
        type: Boolean,
        default: false,
      },
      userInfo:{
        type: Object,
        default: function(){
          return{
            nickName : "default name",
            eMail : "DefaultEmail@tongji.edu.cn",

          }
        }
      }
  },
  data (){
    return{
      active: -1,
    }
  },
  methods:{

  }
}
</script>

<style>

</style>