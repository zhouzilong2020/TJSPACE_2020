<template>
  <div>
      {{token}}
  </div>
</template>

<script>
import {mapState} from 'vuex'
export default {
    computed:{
        ...mapState('userInfo',['token'])
    }
}
</script>

<style>

</style>