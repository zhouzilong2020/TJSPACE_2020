<template>
  <div class="q-pa-md" style="max-width: 100%">
    <q-list bordered separator>
      <q-item style="background: #315ca1">
        <q-item-section>
          <q-item-label class="text-white">收藏课程</q-item-label>
        </q-item-section>
      </q-item>

      <q-item class="row">
        <q-item-section class="justify-evenly col-4" style="text-align: center"
          >课程名称</q-item-section
        >
        <q-item-section class="justify-evenly" style="text-align: left"
          >课程编号</q-item-section
        >
        <q-item-section class="justify-evenly" style="text-align: left"
          >开设学院</q-item-section
        >
        <q-item-section class="justify-evenly" style="text-align: left"
          >学分</q-item-section
        >
        <q-item-section class="justify-evenly" style="text-align: left"
          >教师名称</q-item-section
        >
        <q-item-section
          class="col-1"
          style="text-align: center"
        ></q-item-section>
      </q-item>

      <q-scroll-area style="height: 200px">
        <q-item class="row" v-for="(i, index) in collectedcourse" :key="index">
          <q-item-section class="justify-evenly col-4" style="text-align: left">
            <q-btn
              flat
              :to="{ name: 'courseInfo', params: { courseId: i.courseId } }"
              style="text-align: left"
            >
              {{ i.courseName }}
            </q-btn>
          </q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{
            i.courseId
          }}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{
            i.deptName
          }}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{
            i.credit
          }}</q-item-section>
          <q-item-section class="justify-evenly" style="text-align: left">{{
            i.teacherName
          }}</q-item-section>
          <q-btn
            class="col-1"
            size="12px"
            flat
            dense
            round
            icon="delete"
            @click="cancelCollect(i.courseId, i.teacherId)"
          />
        </q-item>
      </q-scroll-area>
    </q-list>
  </div>
</template>

<script>
import axios from "axios";
import { mapState } from "vuex";
import { token } from "../../services/config";
export default {
  data() {
    return {
      Name: "数据库原理与应用",
      CourseID: 42024403,
      College: "软件学院",
      Semester: "大二下",
      Credit: "4.0",
      Teacher: "袁时金",
      // collectedcourse: [],
    };
  },
  computed: {
    ...mapState("userInfo", ["userInfo", "collectedCourse"]),
    collectedcourse() {
      return this.collectedCourse;
    },
  },
  methods: {
    click() {
      alert("ok!");
    },

    async cancelCollect(courseId, teacherId) {
      let res = await axios.post(
        "http://175.24.115.240:8080/api/Course/CancelCollectCourse",
        {},
        {
          headers: {
            Authorization: token,
          },
          params: {
            userId: this.userInfo.userid,
            courseId: courseId,
            teacherId: teacherId,
          },
        }
      );
      this.msg = res.data;
      console.log("data in courseInfo:", this.msg);
      // this.getCollectedCourse();
      //  console.log('data in courseInfo:' , this.userInfo.userid,courseId,teacherId)
    },
  },

  created() {
    
  },
};
</script>

<style>
</style>