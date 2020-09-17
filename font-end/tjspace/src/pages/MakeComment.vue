<template>
  <div class="row q-gutter-lg q-pa-md flex-center no-wrap items-stretch">
    <course-detail :courseInfo="courseInfo.courseInfo" :commentStatistic="courseInfo.statistic" class="detail q-gutter-sm"/>
    <make-comment :courseInfo="courseInfo.courseInfo" class="makeComment"/>
  </div>
</template>

<script>
import makeComment from "../components/makeComment/makeComment";
import CourseDetail from "../components/courseInfo/CourseDetail";
import {mapState} from 'vuex'
export default {
  components: {
    makeComment,
    CourseDetail,
  },
  computed:mapState('courseInfo' ,['courseInfo']),
  data() {
    return {
    };
  },


  mounted() {
    console.log("in mounted", this.courseInfo)
  },
};
</script>

<style>
.detail{
  height:100%;
}
.makeComment{
  width:100%
}
</style>

