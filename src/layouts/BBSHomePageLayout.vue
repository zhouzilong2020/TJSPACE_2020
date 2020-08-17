<template>
  <q-layout view="hHh lpR fFf">

    <q-header elevated class="bg-primary text-white" height-hint="98">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="left = !left" />

        <q-toolbar-title>
          <q-avatar>
            <img src="https://cdn.quasar.dev/logo/svg/quasar-logo.svg">
          </q-avatar>
          TJSPACE
        </q-toolbar-title>
      </q-toolbar>

      <q-tabs align="left">
        <q-route-tab to="/" label="一个页面" />
        <q-route-tab to="/" label="另一个页面" />
        <q-route-tab to="/BBSHomePage" label="BBS" />
      </q-tabs>

    </q-header>

    <q-drawer show-if-above v-model="left" side="left" bordered>
      <div id="userInfo">
        个人页面
      </div> 
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
    
  </q-layout>
</template>

<script>
export default {
  data () {
    return {
      left: false
    }
  }
}
</script>