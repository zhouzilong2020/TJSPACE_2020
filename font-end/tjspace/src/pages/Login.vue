<template>
    <div class="container row justify-center">">
       <img :src="bgPath" alt="">
        <login/>
    </div>
</template>

<script>
import login from '../components/userInfo/login'

export default {
  data(){
    return {
      bgPath : require('../assets/school.jpeg')
    }
  },
  
  components: {
    login,
  },

  mounted(){


  },
  beforeDestroy(){

  }
}
</script>

<style scoped>
img{
  position: absolute;
  height: 100%;
  width: 100%;
  margin-top: -90px;
  padding:0;
}
.container{
    margin-top: 90px;
}
</style>