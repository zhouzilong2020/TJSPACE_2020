<template>
  <div class="row justify-center">
    <div class="col-auto">
      <q-card class="q-ml-xs" style="width: 230px" />
    </div>
    <div class="col-auto">
      <q-card
        class="row q-mb-xs z-top"
        style="width: 750px"
        id="title"
        v-scroll="Follow"
      >
        <q-banner class="col white">
          <div class="text-h6">{{ title | ellipsis(60) }}</div>
          <q-tooltip content-class="text-h6">{{ title }}</q-tooltip>
        </q-banner>
        <div class="col-auto">
          <q-btn
            class="column-auto q-ma-md shadow-2"
            flat
            dense
            size="md"
            color="white"
            text-color="black"
            :label="onlyMasterText"
            @click="OnlyMaster()"
          />
        </div>
      </q-card>
      <div style="width: 750px">
        <div v-for="(post, i) in displays" :key="i">
          <Post
            :userId="post.userId"
            :nickName="post.nickName"
            :thumbUpNum="thumbUpNum"
            :thumbUp="thumbUp"
            :thumbDown="thumbDown"
            :date="post.date"
            :floor="(currentPage - 1) * 10 + i + 1"
            :content="post.content"
            :replys="post.replys"
            @focusBottom="ToBottom"
            @publish="Publish"
            @evaluate="Evaluate"
          />
        </div>
        <q-card class="q-my-lg">
          <q-editor ref="bottom" v-model="editorContent" min-height="5rem" />
          <div class="row justify-end">
            <q-btn
              class="q-ma-sm"
              text-color="black"
              label="发表"
              @click="Publish(editorContent, totalFloor + 1, 0)"
            />
          </div>
        </q-card>
        <div class="row justify-start q-pb-lg">
          <q-pagination
            v-model="currentPage"
            @click="ShiftPage()"
            :max="maxPage"
            :direction-links="true"
          ></q-pagination>
        </div>
      </div>
    </div>
    <div class="col-auto">
      <q-card class="q-ml-xs" id="toTop" style="width: 230px">
        <q-card class="text-weight-bold q-pt-sm q-ml-md"> 最新推荐 </q-card>
        <div v-for="(recommend, i) in recommendData" :key="i">
          <template>
            <div class="row items-center">
              <q-card
                class="col-auto q-ma-xs q-px-sm q-py-xs"
                flat
                :style="recommend.color"
              >
                {{ i + 1 }}
              </q-card>
              <router-link
                class="col-auto"
                style="text-decoration: none"
                :to="{
                  name: 'Forum',
                  params: { postId: recommend.postId },
                }"
              >
                {{ recommend.title | ellipsis(24) }}
                <q-tooltip>{{ recommend.title }}</q-tooltip>
              </router-link>
            </div>
          </template>
        </div>
        <q-btn
          @click="ToTop"
          class="q-py-sm"
          style="width: 230px"
          color="black"
          icon="keyboard_arrow_up"
          flat
        >
          <q-tooltip>返回顶部</q-tooltip>
        </q-btn>
      </q-card>
    </div>
  </div>
</template>

<script>
import Post from "../components/forum/Post";
import axios from "axios";
import { URL } from "../services/config";
import { mapState } from "vuex";
export default {
  name: "Forum",
  components: {
    Post,
  },
  data() {
    return {
      postId: "",
      title: "",
      postData: {},
      replysData: [],
      masterData: [],
      recommendData: [],
      displays: [],
      maxPage: 1,
      editorContent: "",
      currentPage: 1,
      totalFloor: 1,
      thumbUp: false,
      thumbDown: false,
      thumbUpNum: 0,
      onlyMaster: false,
      onlyMasterText: "只看楼主",
      jump: false,
      isLoading: 0,
      readyCount: 0,
    };
  },
  computed: {
    ...mapState("userInfo", ["userInfo", "token"]),
  },
  watch: {
    $route() {
      this.postId = this.$route.params.postId;
      this.Load();
    },
    displays() {
      this.readyCount = 0;
    },
  },
  methods: {
    Get(api, params) {
      this.SetLoading();
      return new Promise((resolve) => {
        axios
          .get(`${URL}` + api, {
            headers: {
              Authorization: this.token,
            },
            params: params,
          })
          .then((response) => {
            resolve(response.data);
            this.UnsetLoading();
          })
          .catch(async () => {
            await this.$store.dispatch("userInfo/logoutUser");
            this.$router.push({
              name: "index",
            });
          });
      });
    },
    Post(api, params) {
      this.SetLoading();
      return new Promise((resolve, reject) => {
        axios
          .post(
            `${URL}` + api,
            {},
            {
              headers: {
                Authorization: this.token,
              },
              params: params,
            }
          )
          .then((response) => {
            resolve(response.data);
            this.UnsetLoading();
          })
          .catch((error) => {
            reject(error.data);
          });
      });
    },
    SetLoading() {
      if (this.isLoading == 0) {
        this.$q.loading.show();
        this.timer = setTimeout(() => {
          if (this.isLoading > 0) {
            this.$q.notify({
              message: "请求超时，请重试",
              position: "center",
              timeout: "2000",
            });
            this.isLoading = 0;
          }
          this.$q.loading.hide();
          this.timer = void 0;
        }, 5000);
      }
      this.isLoading++;
    },
    UnsetLoading() {
      this.isLoading--;
      if (this.isLoading <= 0) {
        this.$q.loading.hide();
        this.isLoading = 0;
        if (this.timer !== void 0) {
          clearTimeout(this.timer);
          this.$q.loading.hide();
        }
      }
    },
    Load() {
      this.jump = true;
      window.scrollTo({
        top: 0,
      });
      this.replysData = [];
      this.masterData = [];
      if (!this.postId) {
        this.$router.push("/BBSHomepage");
      }
      this.Get("Show/post", {
        postId: this.postId,
      }).then((response) => {
        this.title = response.data1[0].title;
        this.totalFloor = response.data1[0].floor;
        this.thumbUpNum = response.data1[0].usefulnum;
        this.postData = {
          userId: response.data1[0].userid,
          content: response.data1[0].content,
          date: response.data1[0].date,
          nickName: response.data2,
          replys: [],
        };
        response.data3.sort((a, b) => {
          if (a.floor !== b.floor) {
            return a.floor - b.floor;
          } else {
            return a.type - b.type;
          }
        });
        response.data3.forEach((data) => {
          if (data.type === 0) {
            this.replysData.push({
              replyId: data.replyId,
              nickName: data.name,
              replys: [],
            });
          } else {
            this.replysData[data.floor - 1].replys.push({
              replyId: data.replyId,
              nickName: data.name,
            });
          }
        });
        this.replysData.forEach((data) => {
          if (data.nickName == this.postData.nickName) {
            this.masterData.push(data);
          }
        });
        this.maxPage = Math.ceil((this.replysData.length + 1) / 10);
        this.currentPage = 1;
        this.ShiftPage();
      });

      this.Get("Post/CanEvaluate", {
        userId: this.userInfo.userid,
        postId: this.postId,
      }).then((response) => {
        if (!response.canEvaluate) {
          this.thumbUp = Boolean(response.type);
          this.thumbDown = !this.thumbUp;
        } else {
          this.thumbUp = false;
          this.thumbDown = false;
        }
      });
    },
    ShiftPage() {
      this.jump = true;
      window.scrollTo({
        top: 0,
      });
      var temp = [];
      var index = 0;
      var data;
      var fullData;
      if (!this.onlyMaster) {
        fullData = this.replysData;
      } else {
        fullData = this.masterData;
      }

      if (this.currentPage == 1) {
        temp[index] = {
          userId: this.postData.userId,
          content: this.postData.content,
          date: this.postData.date,
          nickName: this.postData.nickName,
          replys: [],
        };
        index++;
        data = fullData.slice(0, 9);
      } else {
        data = fullData.slice(
          this.currentPage * 10 - 11,
          this.currentPage * 10 - 1
        );
      }
      var replyIds = "";
      data.forEach((reply) => {
        replyIds += reply.replyId + ",";
        reply.replys.forEach((replyToReply) => {
          replyIds += replyToReply.replyId + ",";
        });
      });
      replyIds = replyIds.slice(0, -1);
      if (replyIds === "") {
        this.displays = temp.slice(0, index);
        return;
      }
      this.Get("Show/reply", {
        str: replyIds,
      }).then((response) => {
        var replyIdMap = [];
        response.data.forEach((reply) => {
          replyIdMap[reply[0].replyid] = {
            userId: reply[0].userid,
            content: reply[0].content,
            date: reply[0].date,
          };
        });
        data.forEach((reply) => {
          var replyData = replyIdMap[reply.replyId];
          temp[index] = {
            userId: replyData.userId,
            content: replyData.content,
            date: replyData.date,
            nickName: reply.nickName,
            replys: [],
          };
          reply.replys.forEach((replyToReply) => {
            var replyToReplyData = replyIdMap[replyToReply.replyId];
            temp[index].replys.push({
              userId: replyToReplyData.userId,
              content: replyToReplyData.content,
              date: replyToReplyData.date,
              nickName: replyToReply.nickName,
            });
          });
          temp[index].replys.sort(function (a, b) {
            return a.date > b.date ? 1 : -1;
          });
          index++;
        });
        this.displays = temp.slice(0, index);
      });
    },
    Publish(content, floor, type) {
      this.Post("Post/reply", {
        content: content,
        userId: this.userInfo.userid,
        postId: this.postId,
        floor: floor,
        type: type,
      }).then(() => {
        this.$q.notify({
          message: "回帖成功",
          position: "center",
          timeout: "2000",
        });
        this.Load();
      });
    },
    DoEvaluate(type) {
      this.Post("Post/evaluate", {
        userId: this.userInfo.userid,
        postId: this.postId,
        type: type,
      }).then((response) => {
        if (response.status) {
          if (type) {
            this.thumbUp = true;
            this.thumbUpNum++;
          } else {
            this.thumbDown = true;
          }
        }
      });
    },
    Evaluate(type) {
      this.Get("Post/CanEvaluate", {
        userId: this.userInfo.userid,
        postId: this.postId,
      }).then((evaluateInfo) => {
        if (!evaluateInfo.canEvaluate || evaluateInfo.type !== type) {
          this.Post("Post/CancelEvaluation", {
            userId: this.userInfo.userid,
            postId: this.postId,
          }).then((response) => {
            if (response.status) {
              if (evaluateInfo.type) {
                this.thumbUp = false;
                this.thumbUpNum--;
              } else {
                this.thumbDown = false;
              }
            }
            if (evaluateInfo.type !== type) {
              this.DoEvaluate(type);
            }
          });
        } else {
          this.DoEvaluate(type);
        }
      });
    },
    OnlyMaster() {
      this.onlyMaster = !this.onlyMaster;
      if (this.onlyMaster) {
        this.maxPage = Math.ceil((this.masterData.length + 1) / 10);
        this.onlyMasterText = "取消只看楼主";
      } else {
        this.maxPage = Math.ceil((this.replysData.length + 1) / 10);
        this.onlyMasterText = "只看楼主";
      }
      this.currentPage = 1;
      this.ShiftPage();
    },
    ToBottom() {
      window.scrollTo({
        top: document.documentElement.offsetHeight,
        behavior: "smooth",
      });
    },
    ToTop() {
      window.scrollTo({
        top: 0,
        behavior: "smooth",
      });
    },
    Follow(position) {
      var title = document.getElementById("title");
      var toTop = document.getElementById("toTop");
      if (
        !this.jump &&
        document
          .getElementsByTagName("header")[0]
          .getAttribute("class")
          .indexOf("q-header--hidden") != -1
      ) {
        title.style.top = position - 50 + "px";
      } else {
        title.style.top = position + "px";
      }
      if (
        document
          .getElementsByTagName("footer")[0]
          .getAttribute("class")
          .indexOf("q-footer--hidden") != -1
      ) {
        toTop.style.top =
          position +
          document.documentElement.clientHeight -
          toTop.offsetHeight -
          50 +
          "px";
      } else {
        toTop.style.top =
          position +
          document.documentElement.clientHeight -
          toTop.offsetHeight -
          100 +
          "px";
      }
      this.jump = false;
    },
  },
  mounted() {
    this.postId = this.$route.params.postId;
    this.Load();
    this.Get("Show/getPosts", {
      orderType: 3,
      startPosition: 0,
      userId: "",
    }).then((response) => {
      response.posts.slice(0, 10).forEach((post) => {
        this.recommendData.push({
          title: post.title,
          postId: post.postId,
          color: "background:#C0C0C0",
        });
      });
      this.recommendData[0]["color"] = "background:#FFD700";
      this.recommendData[1]["color"] = "background:#F5F5F5";
      this.recommendData[2]["color"] = "background:#D2691E";
      /*this.$nextTick(() => {
                this.ToTop();
            });*/
    });
  },
  filters: {
    ellipsis(string, length) {
      for (var i = 0; i < string.length; i++) {
        if (string.charCodeAt(i) > 127 || string.charCodeAt(i) < 0) {
          length -= 2;
        } else {
          length -= 1;
        }
        if (length < 0) {
          return string.slice(0, i - 1) + "...";
        }
      }
      return string;
    },
  },
  beforeDestroy() {
    if (this.timer !== void 0) {
      clearTimeout(this.timer);
      this.$q.loading.hide();
    }
  },
};
</script>
