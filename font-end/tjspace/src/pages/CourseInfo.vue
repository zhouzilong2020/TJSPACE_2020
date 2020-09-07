<template>
  <div class="row justify-evenly">
    <q-page-container class="detail body-left">
      <course-detail
        :courseInfo="courseInfo"
        :commentStatistic="commentStatistic"
      />
    </q-page-container>

    <q-page-container class="body-right">
      <div class="course-head">
        <course-head :courseInfo="courseInfo" />
      </div>

      <!-- 搜索栏 -->
      <div class="option-group row justify-between">
        <q-select
          v-model="order"
          label="选择排序方式"
          :options="orderOptions"
          style="width: 250px"
          behavior="menu"
        />
        <q-select
          v-model="dept"
          label="选择其他学院"
          :options="deptsOptions"
          style="width: 250px"
          behavior="menu"
        />
        <q-btn
          class="btn"
          color="primary"
          icon-right="comment"
          label="撰写评论"
          unelevated
        />
      </div>

      <div class="course-comment">
        <course-comment
          v-for="(comment,i) in comments"
          :key="comment.commentid"
          :apiData="comment"
          :taker="commentor[i]"
        />
      </div>
    </q-page-container>
  </div>
</template>

<script>
import { getComment } from "../services/commentService";
import CourseComment from "../components/courseInfo/CourseComment";
import CourseDetail from "../components/courseInfo/CourseDetail";
import CourseHead from "../components/courseInfo/CourseHead";

export default {
  name: "CourseInfo",
  components: {
    CourseComment,
    CourseDetail,
    CourseHead,
  },
  computed: {
    commentStatistic() {
      let statistic = {
        reveiwCnt: 0,
        content: 0,
        teaching: 0,
        grading: 0,
        workload: 0,
      };
      statistic.reveiwCnt = this.comments.length;
      for (let i = 0; i < statistic.reveiwCnt; i++) {
        statistic.content += +this.comments[i].overall;
        statistic.teaching += +this.comments[i].instructor;
        statistic.grading += +this.comments[i].grading;
        statistic.workload += +this.comments[i].workload;
      }
      statistic.content /= statistic.reveiwCnt;
      statistic.teaching /= statistic.reveiwCnt;
      statistic.grading /= statistic.reveiwCnt;
      statistic.workload /= statistic.reveiwCnt;
      return statistic;
    },
  },
  data() {
    return {
      ID: 420244,
      order: "",
      dept: "",
      orderOptions: [],
      deptsOptions: [],
      text: "",
      logoPath: require("../assets/TJU.png"),
      avatarPath: require("../assets/boy-avatar.png"),
      avatarBGPath: require("../assets/material.png"),
      drawer: false,
      active: -1,

      courseInfo: {
        title: "数据库原理与应用",
        teacher: "袁时金",
        id: "420244",
        section: "2020 春",
        department: "软件学院",
        credit: "4",
        sections: [
          "2017-春",
          "2017-秋",
          "2018-春",
          "2018-秋",
          "2018-春",
          "2019-秋",
          "2019-春",
          "2019-秋",
          "2020-春",
        ],
        syllabus:
          "Chapter 1: Introduction Chapter 2: Introducation to the Relational Model Chapter 3: Intoduction to SQL Chapter 4: Intermediate SQLChapter 5: Advanced SQL Sections 5.4 onwards omitted. Chapter 6: Other Relational Languages Section 6.1 (Relational Algebra) covered in brief，Sections 6.2 and 6.3 omitted Chapter 7: Entity-Relationship Model  Chapter 8: Relational Database Design  Chapter 9: Application Design and Development  Chapter 10: Storage and File Structure  Sections 10.3, 10.4 and 10.8 omitted Chapter 11: Indexing and Hashing  Cover only Sections 11.1 through 11.3，with a brief outline of Section 11.5 and 11.6 Chapter 12: Query Processing  Cover only Section 12.1 (Overview)  Chapter 14: Transactions  Transaction Concept, Transaction State, Concurrent Executions, Conflict Serializability Introduction to major database products: Oracle",
      },
      userInfo: {
        nickName: "lili",
        eMail: "1888888@tongji.edu.cn",
      },
      comments: [],
    };
  },
  async created() {
    var resp = await getComment({ courseId: this.ID });
    this.comments = resp.data1;
    this.commentor = resp.data2;
  },
};
</script>

<style scoped>
.course-head {
  margin-top: 15px;
}

.body-left {
  position: fixed;
  left: 15px;
  top: 15px;
}

.body-right {
  position: absolute;
  right: 15px;
  top: 0;
  padding: 0;
  left: 245px;
}

.body-right .course-head {
  margin-top: 15px;
}
.body-right .course-comment {
  margin-top: 15px;
}
.body-right .option-group {
  margin-top: 15px;
  max-width: 800px;
}

.body-right .option-group .btn{
    margin-top: 10px;
}

</style>