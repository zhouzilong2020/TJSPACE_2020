<template>
  <q-layout view="hHh lpR fFf">

    <q-header reveal bordered class="bg-primary text-white" height-hint="98">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="drawer = !drawer" />
        <q-toolbar-title>
          <q-avatar>
            <img :src="logoPath">
          </q-avatar>
          TJSPACE·同济大学社群{{drawer == false}}
        </q-toolbar-title>
      </q-toolbar>
    </q-header>
    
    <LeftDrawer :drawer="drawer"/>

    <q-page-container>
      <div>
            <q-btn @click="doSomething" label="Do something" />
      </div>

      <CourseStatistic />
    </q-page-container>

    <q-footer reveal elevated class="bg-grey-8 text-white">
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
import LeftDrawer from "./LeftDrawer"
import CourseStatistic from "./CourseStatistic"
export default {
  components:{
    LeftDrawer,
    CourseStatistic,
  },

  data () {
    return {
        logoPath : require("../assets/TJU.png"),
        drawer : false,
    }
  }
}
</script>

