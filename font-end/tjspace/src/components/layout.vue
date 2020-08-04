<template>
  <q-layout view="hHh lpR fFf">

    <q-header reveal bordered class="bg-primary text-white" height-hint="98">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="left = !left" />
        
        <q-toolbar-title>
          <q-avatar>
            <img :src="logoPath">
          </q-avatar>
          TJSPACE·同济大学社群
        </q-toolbar-title>

      </q-toolbar>

      <!-- <q-tabs align="left">
        <q-route-tab to="/page1" label="Page One" />
        <q-route-tab to="/page2" label="Page Two" />
        <q-route-tab to="/page3" label="Page Three" />
      </q-tabs> -->
    </q-header>

    <q-drawer show-if-above v-model="left" side="left" bordered>
      <!-- drawer content -->
      some content
    </q-drawer>


    <q-page-container>
       <div>
            <q-btn @click="doSomething" label="Do something" />
        </div>
      <div class="row">
        <div>First column</div>
        <div>Second column</div>
        <div>Third column</div>
      </div>



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
export default {
  data () {
    return {
        logoPath : require("../assets/TJU.png"),
        left : false,
    }
  }
}
</script>

