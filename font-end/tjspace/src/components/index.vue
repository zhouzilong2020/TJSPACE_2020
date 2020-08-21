<template>
    <div id="container">
        <login/>
        <!-- <register/> -->
    </div>
</template>

<script>
import login from './userInfo/login'
// import register from './userInfo/register'

export default {
  
  components: {
    login,
    // register
  },

}
</script>

<style>
body{
    background-image: url('../assets/tongji.jpeg');
    background-size: 100% 100%;
    background-attachment: fixed;
}
#container{
    margin-top: 90px;
}


</style>