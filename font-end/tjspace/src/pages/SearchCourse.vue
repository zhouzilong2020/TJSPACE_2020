<template>
  <div class="main">
    <q-page-container class="body-right row">
      <div class="left col-8" style>
        <div class="q-pa-md" style="max-width: 780px">
          <div class="q-gutter-md">
            <div style="text-align: center">
              <span class="word">开启你的</span>
              <img
                :src="path1"
                style="
                  height: 130px;
                  width: 130px;
                  margin-left: 25px;
                  margin-right: 25px;
                "
              />
              <span class="word">奇妙旅程</span>
            </div>
            <div class="search-bar">
              <input
                type="text"
                value
                id="textId"
                class="textClass"
                placeholder="请输入希望搜索的课程名称"
                name="textName"
              />
              <button
                @click="btnclick()"
                style="border: none; width: 70px; max-height: 50px"
              >
                <q-icon name="search"></q-icon>
              </button>
            </div>
          </div>
        </div>

        <div v-if="isShow">
          <div class="choose">
            <q-select
              standout="bg-teal text-white"
              v-model="model"
              :options="department"
              label="学院"
            ></q-select>
          </div>
          <div
            class="content"
            v-for="item in newcourseInfo"
            :key="item.label"
            :value="item.value"
          >
            <q-card
              clickable
              v-ripple
              class="my-cardinfo"
              flat
              bordered
              @click="click(item)"
            >
              <q-item>
                <q-item-section avatar>
                  <q-avatar>
                    <img :src="path" />
                  </q-avatar>
                </q-item-section>

                <q-item-section>
                  <q-item-label>{{ item.courseName }}</q-item-label>
                  <q-item-label caption>{{ item.courseCredit }}</q-item-label>
                </q-item-section>
              </q-item>

              <q-separator />

              <q-card-section horizontal>
                <q-card-section>{{ item.courseIntro }}</q-card-section>

                <q-separator vertical />

                <q-card-section class="col-4">分数：0.0</q-card-section>
              </q-card-section>
            </q-card>
          </div>
        </div>

        <div v-else>
          <div class="wordrec">recommendations</div>

          <q-separator />

          <div
            class="content"
            style="margin-top: 5px; display: flex"
            v-for="item in courseInfo"
            :key="item.label"
            :value="item.value"
          >
            <div>
              <q-card class="my-cardrec" @click="click(item)">
                <q-img src="https://cdn.quasar.dev/img/parallax2.jpg" basic>
                  <div class="absolute-bottom text-h6">{{ item.name }}</div>
                </q-img>

                <q-card-section>{{ item.intro }}</q-card-section>
              </q-card>
            </div>
          </div>
        </div>
      </div>
    </q-page-container>
  </div>
</template>

<script>
import { mapState } from "vuex";
import { search } from "../services/search";
export default {
  components: {},
  data() {
    return {
      model:'',
      isShow: 0,
      path1: require("../assets/TJU.png"),
      path: require("../assets/zhuzi.jpeg"),
      inputSearch: "",
      department: [
        "软件学院",
        "电信学院",
        "汽车学院",
        "交运学院",
        "还有什么学院",
      ],
      courseInfo: [
        {
          name: "数据库原理与应用",
          teacher: "袁时金",
          intro:
            "这是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程",
          courseId: "420244",
        },
        {
          name: "计算机系统结构",
          teacher: "张晨曦",
          intro:
            "这是仍然是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程",
        },
        {
          name: "操作系统",
          teacher: "张慧娟",
          intro:
            "这是还是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程",
        },
        {
          name: "系统分析与设计",
          teacher: "孙萍",
          intro:
            "这是仍然是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程",
        },
      ],
      newcourseInfo: [],
      text: "",
      active: -1,
      drawer: false,
      logoPath: require("../assets/TJU.png"),
      avatarPath: require("../assets/boy-avatar.png"),
      avatarBGPath: require("../assets/material.png"),
      userInfo: {
        email: "1",
        nickname: "1",
      },
    };
  },
  methods: {
    click(data) {
      console.log("click card", data);
      this.$router.push({
        name: "courseInfo",
        params: {
          courseId: data.courseId,
        },
      });
    },
    btnclick() {
      this.$nextTick(async function () {
        this.value = document.getElementById("textId").value;
        console.log("search", this.value);

        console.log('in serach course', this.token)
        var resp1 = await search({
          searchKey: this.value,
          token: this.token,
        });
        this.newcourseInfo = resp1;
        this.isShow = 1;
        console.log("result", this.newcourseInfo);
      });
    },
  },
  props: {},
  computed: {
    ...mapState("userInfo", ["isLoading", "token"]),
  },
};
</script>

<style scoped>
.header {
  background-color: #0025abcc;
}
.body {
  width: 100%;
  margin: 0 auto;
}

.drawer-btn-penal {
  position: absolute;
  left: -40px;
}
.header .header-search {
  color: aliceblue;
}
.page-footer .footer-name {
  margin-left: 10px;
  font-size: 16px;
}
.page-footer .footer-id {
  position: absolute;
  right: 10px;
  font-size: 16px;
}

.content {
  width: 800px;
}

.choose {
  max-width: 200px;
  /* margin-left: 14px; */
}
.my-cardinfo {
  width: 100%;
  max-width: 720px;
  margin-top: 50px;
  background-color: rgb(245, 245, 245);
  box-shadow: darkgrey 10px 10px 30px 5px;
  /* margin-left: 70px; */
}

.search-bar {
  display: flex;
  width: 1000px;
}
.search-bar input {
  width: 710px;
  height: 50px;
  /* margin-left: 0px; */
  border-color: grey;
  border-radius: 1px;
}

.my-cardrec {
  max-width: 340px;
  max-height: 340px;
}
@font-face {
  font-family: maoyeye;
  src: url("../assets/shufa.ttf");
}
@font-face {
  font-family: reccom;
  src: url("../assets/Amazing sound.ttf");
}
.word {
  font-family: maoyeye;
  font-style: oblique;
  font-size: 50px;
  font-weight: 900;
  color: rgb(100, 149, 237);
}
.wordrec {
  font-family: reccom;
  text-align: center;
  font-style: oblique;
  font-size: 50px;
  font-weight: 900;
  color: rgb(100, 149, 237);
}
</style>