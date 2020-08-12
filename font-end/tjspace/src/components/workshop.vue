/* eslint-disable no-undef */
<template>

  <div>
       <course-comment />
  </div>
</template>

<script>
// import DrawerBtnPenal from "./DrawerBtnPenal"
import CourseComment from "./CourseComment"
export default {
    components:{
        CourseComment
        // DrawerBtnPenal,
    },
    data (){
        return {
            info:'',
        }
    },

    mounted(){
    }

}
</script>

<style>

</style>