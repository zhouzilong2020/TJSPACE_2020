<template>
  <q-card elevated class="course-detail">
    <img :src="path" class="course-detail-img" />

    <q-card-section horizontal>
      <q-list>
        <q-item>
          <q-item-section avatar>
            <q-icon color="primary" name="local_library" />
          </q-item-section>
          <q-item-section>
            <q-item-label>课程名称</q-item-label>
            <q-item-label caption>{{ courseInfo.title }}</q-item-label>
          </q-item-section>
        </q-item>

        <q-item>
          <q-item-section avatar>
            <q-icon color="red" name="people" />
          </q-item-section>

          <q-item-section>
            <q-item-label>授课教师</q-item-label>
            <q-item-label caption>{{ courseInfo.teacher }}</q-item-label>
          </q-item-section>
        </q-item>

        <q-item>
          <q-item-section avatar>
            <q-icon color="amber" name="near_me" />
          </q-item-section>

          <q-item-section>
            <q-item-label>课程编号</q-item-label>
            <q-item-label caption>{{ courseInfo.id }}</q-item-label>
          </q-item-section>
        </q-item>

        <q-item>
          <q-item-section avatar>
            <q-icon color="green" name="today" />
          </q-item-section>

          <q-item-section>
            <q-item-label>开课时间</q-item-label>
            <q-item-label caption>{{ courseInfo.section }}</q-item-label>
          </q-item-section>
        </q-item>

        <q-item>
          <q-item-section avatar>
            <q-icon color="grey" name="place" />
          </q-item-section>
          <q-item-section>
            <q-item-label>开设学院</q-item-label>
            <q-item-label caption>{{ courseInfo.department }}</q-item-label>
          </q-item-section>
        </q-item>
      </q-list>
    </q-card-section>

    <q-card-section>
      <course-statistic class="q-my-sm" :commentStatistic="commentStatistic" />
      <q-btn
        stretch
        class="full-width btn gt-sm"
        color="primary"
        icon-right="comment"
        :to="{
          name: 'MakeComment',
          params: {
            userId: this.userInfo.userId,
            courseId: this.courseInfo.id,
          },
        }"
        label="撰写评论"
        unelevated
      >
        <q-tooltip content-class="bg-accent">现在就撰写你的评论吧！</q-tooltip>
      </q-btn>
      <q-btn
        stretch
        class="full-width btn lt-md"
        color="primary"
        icon-right="comment"
        unelevated
      >
        <q-tooltip content-class="bg-accent">现在就撰写你的评论吧！</q-tooltip>
      </q-btn>
    </q-card-section>
  </q-card>
</template>

<script>
import CourseStatistic from "./CourseStatistic";
import { mapState } from "vuex";
export default {
  name: "CourseDetail",
  components: {
    CourseStatistic,
  },
  computed:{
    ...mapState('userInfo', ['userInfo'])
  },
  props: {
    courseInfo: {
      type: Object,
      default: () => {
        return {
          title: "数据库原理与应用",
          teacher: "袁时金",
          id: "420244",
          section: "2020 春",
          department: "软件学院",
        };
      },
    },
    commentStatistic: {
      type: Object,
    },
  },
  data() {
    return {
      path: require("../../assets/TJU.png"),
    };
  },
};
</script>

<style scoped>
.course-detail {
  max-width: 200px;
}
.course-detail .course-detail-img {
  max-width: 80px;
  padding: 10px;
  margin: 0 auto;
}
</style>
