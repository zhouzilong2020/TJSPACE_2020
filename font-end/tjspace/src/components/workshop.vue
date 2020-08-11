<template>

  <div>
      <script src="https://cdn.staticfile.org/axios/0.18.0/axios.min.js"></script>
      <!-- <drawer-btn-penal /> -->
      {{info}}
  </div>
</template>

<script>
// import DrawerBtnPenal from "./DrawerBtnPenal"
export default {
    components:{
        // DrawerBtnPenal,
    },
    data (){
        return {
            info:'',
        }
    },

    mounted(){
        axois
            .post('http://tjspace.com/api/Comment/PostComment')
            .then(res => (this.info = res))
            .catch(function(error){
                console.log(error);
            });
    }

}
</script>

<style>

</style>