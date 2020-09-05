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
      <course-statistic :commentStatistic="commentStatistic" />
    </q-card-section>
  </q-card>
</template>

<script>
import CourseStatistic from "./CourseStatistic";
export default {
  name: "CourseDetail",
  components: {
    CourseStatistic,
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
.course-detail .course-detail-img {
  max-width: 80px;
  padding: 10px;
  margin: 0 auto;
}
</style>
