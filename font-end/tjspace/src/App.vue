<template>
  <div id="app">
    <layout>
      <template v-slot:main>
        <router-view></router-view>
      </template>
    </layout>
  </div>
</template>

<script>
import layout from "./components/layout"
export default {


  name: 'APP',
  components: {
    layout,
  },
  data () {
    return{}
  },
  methods:{
  }
}
</script>

<style>
  @import '~@/styles/global.css';
</style>
