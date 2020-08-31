<template>
    <div class="container">
      <img :src="bgPath" alt="">
      <register/>
    </div>
</template>

<script>
import register from '../components/userInfo/register'

export default {
  data(){
    return {
      bgPath : require('../assets/school.jpeg')
    }
  },

  
  components: {
    register
  },

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