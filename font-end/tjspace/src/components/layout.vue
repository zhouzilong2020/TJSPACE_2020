<template>
  <q-layout view="hHh lpR fFf">
    <q-header reveal bordered class="bg-primary text-white" height-hint="98">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="drawer = !drawer" />
        <q-toolbar-title> TJSPACE · 同济大学社群 </q-toolbar-title>

        <!-- 登录|注册 -->
        <!-- 三种情况！ -->
        <!-- 1.正在登录中 加载 -->
        <!-- 2.登录成功 -->
        <template v-if="token">
          <div class="text-caption">欢迎您！{{ userInfo.nickname }}</div>
          <q-input
            dark
            dense
            standout
            v-model="text"
            input-class="text-left"
            class="q-ml-md"
            placeholder="发现更多课程"
          >
            <template v-slot:append>
              <q-icon v-if="text === ''" name="search" />
              <q-icon
                v-else
                name="clear"
                class="cursor-pointer"
                @click="text = ''"
              />
            </template>
          </q-input>
          <q-btn
            class="logout-btn"
            flat
            @click="handleLogout()"
            label="退出登录"
          />
        </template>

        <template v-else>
          <q-btn-group class="top-option" flat>
            <q-btn label="现在登录" :to="{ name: 'login' }" />
            <q-btn label="马上注册" :to="{ name: 'register' }" />
          </q-btn-group>
        </template>
      </q-toolbar>
    </q-header>

    <!-- 侧边栏 -->
    <q-drawer
      class="drawer"
      show-if-above
      flat
      v-model="drawer"
      :width="225"
      :breakpoint="99999"
    >
      <q-scroll-area
        style="
          height: calc(100% - 150px);
          margin-top: 150px;
          border-right: 1px solid #ddd;
        "
      >
        <q-list padding>
          <q-item :active="active == 0" @click="active = 0" clickable v-ripple>
            <q-item-section avatar>
              <q-icon name="home" />
            </q-item-section>
            <q-item-section>
              <!-- 如何写路由！！！ -->

              <router-link
                :to="{ name: 'Homepage', params: { userid: 'lutianyi' } }"
                >个人主页</router-link
              >
            </q-item-section>
          </q-item>

          <q-item :active="active == 1" @click="active = 1" clickable v-ripple>
            <q-item-section avatar>
              <q-icon name="star" />
            </q-item-section>
            <q-item-section> 我的收藏 </q-item-section>
          </q-item>

          <q-item :active="active == 2" @click="active = 2" clickable v-ripple>
            <q-item-section avatar>
              <q-icon name="drafts" />
            </q-item-section>
            <q-item-section> 我的消息 </q-item-section>
          </q-item>

          <div class="drawer-btn-penal">
            <drawer-btn-penal />
          </div>
        </q-list>
      </q-scroll-area>
      <!-- 头部的背景图片和用户信息、头像 -->
      <q-img class="absolute-top" :src="avatarBGPath" style="height: 160px">
        <div class="absolute-bottom bg-transparent">
          <q-avatar size="56px" class="q-mb-sm">
            <img :src="avatarPath" />
          </q-avatar>
          <template v-if="userInfo">
            <div class="text-weight-bold">欢迎你！ {{ userInfo.nickname }}</div>
            <!-- 这个没存user的Email啊 -->
            <!-- <div>{{ userInfo.eMail }}</div> -->
            <div>这里我觉得要有邮箱？</div>
          </template>
          <template v-else>
            <div class="text-weight-bold">请先登录</div>
          </template>
        </div>
      </q-img>
    </q-drawer>

    <q-page-container class="body">
      <!-- 你的内容将会被插入在这里 -->
      <slot name="main"></slot>
    </q-page-container>

    <!-- footer -->
    <q-footer reveal bordered class="bg-grey-8 text-white page-footer">
      <q-toolbar>
        <q-toolbar-title>
          <span class="footer-name">TJSPACE·同济大学社群</span>
          <span class="footer-id">津ICP备20006438号</span>
        </q-toolbar-title>
      </q-toolbar>
    </q-footer>
  </q-layout>
</template>

<script>
import DrawerBtnPenal from "./DrawerBtnPenal";
import { mapState } from "vuex";
export default {
  components: {
    DrawerBtnPenal,
  },
  data() {
    return {
      text: "",
      active: -1,
      drawer: false,
      logoPath: require("../assets/TJU.png"),
      avatarPath: require("../assets/boy-avatar.png"),
      avatarBGPath: require("../assets/material.png"),
    };
  },
  props: {},
  computed: {
    ...mapState("userInfo", ["isLoading", "token", "userInfo"]),
  },
  methods: {
    async handleLogout() {
      console.log("click logout btn");
      await this.$store.dispatch("userInfo/logoutUser");
      // 成功退出
      if (this.token == null) {
        console.log("logout user successfully");
        this.$router.push({
          name: "index",
        });
      }
    },
  },
};
</script>

<style scoped>
.header {
  background-color: #0025abcc;
}
.body {
  width: 100%;
  margin: 0 auto;
}

.logout-btn {
  margin-left: 10px;
}
.drawer-btn-penal {
  position: absolute;
  left: -40px;
}
.header .header-search {
  color: aliceblue;
}
.page-footer .footer-name {
  margin-left: 10px;
  font-size: 16px;
}
.page-footer .footer-id {
  position: absolute;
  right: 10px;
  font-size: 16px;
}
</style>

