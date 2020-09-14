<template>
  <q-page-container>
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
            {{ title }}
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
          <q-card class="text-weight-bold q-pt-sm q-ml-md"> 热门推荐 </q-card>
          <div v-for="(recommend, i) in recommendData" :key="i">
            <template>
              <div class="row items-center">
                <q-card
                  v-if="i < 3"
                  class="col-auto q-ma-xs q-px-sm q-py-xs"
                  flat
                  style="background: orange"
                >
                  {{ i + 1 }}
                </q-card>
                <q-card v-else class="col-auto q-ma-xs q-px-sm q-py-xs" flat>
                  {{ i + 1 }}
                </q-card>
                <router-link
                  class="col-auto"
                  style="text-decoration: none"
                  :to="{
                    name: 'Forum',
                    params: { postId: recommend.posetId },
                  }"
                >
                  {{ recommend.title | ellipsis }}
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
  </q-page-container>
</template>

<script>
import Post from "../components/forum/Post";
import axios from "axios";
const recommendData = [
  {
    title: "舒服了",
    posetId: "2abee334-495f-481d-860e-ad31be83de0d",
  },
  {
    title: "如何评价post终于可以调了",
    posetId: "05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b",
  },
  {
    title: "如何评价post终于可以调了",
    posetId: "05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b",
  },
  {
    title: "如何评价post终于可以调了",
    posetId: "05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b",
  },
  {
    title: "如何评价post终于可以调了",
    posetId: "05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b",
  },
];
export default {
  name: "MainLayout",
  components: {
    Post,
  },
  data() {
    return {
      userId: "d1e3aec8-f1c2-47b5-8604-77192d3e3ab6",
      postId: "",
      title: "",
      content: "",
      postData: [],
      masterData: [],
      displays: [],
      maxPage: 1,
      editorContent: "",
      active: -1,
      currentPage: 1,
      totalFloor: 1,
      thumbUp: false,
      thumbDown: false,
      thumbUpNum: 0,
      token:"Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjkzNTMwMzY3ZDI0OTFiMzQ0MTEzODYwZGUyN2QzNzdlIiwidHlwIjoiSldUIn0.eyJuYmYiOjE2MDAwMDM2NjIsImV4cCI6MTYwMDAwNzI2MiwiaXNzIjoiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAiLCJhdWQiOlsiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAvcmVzb3VyY2VzIiwiYXBpMSJdLCJjbGllbnRfaWQiOiJjbGllbnQyIiwic3ViIjoiMTExIiwiYXV0aF90aW1lIjoxNjAwMDAzNjYyLCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJhcGkxIl0sImFtciI6WyJjdXN0b20iXX0.OpVHYPHiz_tB1IHM3M9qwUs1yHnsT6X6bnXwxVV8lTnKu3bWHud8fKkglIL2xXVYXNh1XkvAdOlN8zR4e_himLf6opNmrUEQE1e6oCslro5YKI29pJC_R9t-h24gRvAd9iXAB1LV6wHGXEPiBGZF3fiyooFKwfLqYCcGxF1qYgWO9HgQmEhpNvtEyYABGiP5Pf01rCkUTUOoFKAgeayAKHA1TbdRxtKmv3BXzmg-EJ6srLU5bOsDayaJcT5FfZdkwwZQx-y86IZDPcbcNzuLv3lbuJ-IDcRrXy9CxxzSBnjOS1U8QaSQ6g3K1C9rELcBn3S1Ho3lcEiwCbkFRe52qg",
      inputSearch: "",
      text: "",
      recommendData: recommendData,
      onlyMaster: false,
      onlyMasterText: "只看楼主",
    };
  },
  methods: {
    ShiftPage() {
      if (!this.onlyMaster) {
        this.displays = this.postData.slice(
          (this.currentPage - 1) * 10,
          this.currentPage * 10
        );
      } else {
        this.displays = this.masterData.slice(
          (this.currentPage - 1) * 10,
          this.currentPage * 10
        );
      }
      this.ToTop();
    },
    OnlyMaster() {
      this.onlyMaster = !this.onlyMaster;
      if (this.onlyMaster) {
        this.maxPage = Math.ceil(this.masterData.length / 10);
        this.onlyMasterText = "取消只看楼主";
      } else {
        this.maxPage = Math.ceil(this.postData.length / 10);
        this.onlyMasterText = "只看楼主";
      }
      this.currentPage = 1;
      this.ShiftPage();
    },
    ToBottom() {
      document.documentElement.scrollTo(
        undefined,
        document.documentElement.offsetHeight
      );
      this.$refs.bottom.focus();
    },
    ToTop() {
      document.documentElement.scrollTo(undefined, 0);
    },
    Follow(position) {
      var title = document.getElementById("title");
      var nav = document.getElementById("nav");
      var toTop = document.getElementById("toTop");
      if (position > nav.offsetHeight) {
        title.style.top = position - nav.offsetHeight + "px";
      } else {
        title.style.top = 0;
      }
      toTop.style.top =
        position +
        document.documentElement.clientHeight -
        toTop.offsetHeight -
        nav.offsetHeight +
        "px";
    },
    Publish(content, floor, type) {
      axios
        .post(
          "http://175.24.115.240:8080/api/Post/reply",
          {},
          {
            headers: {
              Authorization: this.token,
            },
            params: {
              content: content,
              userId: this.userId,
              postId: this.postId,
              floor: floor,
              type: type,
            },
          }
        )
        .then((response) => {
          alert(response.data.msg);
          if (response.data.status) {
            window.location.reload();
          }
        });
    },
    Evaluate(type) {
      axios
        .get("http://175.24.115.240:8080/api/Post/CanEvaluate", {
          headers: {
            Authorization: this.token,
          },
          params: {
            userId: this.userId,
            postId: this.postId,
          },
        })
        .then((evaluateInfo) => {
          if (
            !evaluateInfo.data.canEvaluate ||
            evaluateInfo.data.type !== type
          ) {
            axios
              .post(
                "http://175.24.115.240:8080/api/Post/CancelEvaluation",
                {},
                {
                  headers: {
                    Authorization: this.token,
                  },
                  params: {
                    userId: this.userId,
                    postId: this.postId,
                  },
                }
              )
              .then((response) => {
                if (response.data.status) {
                  if (evaluateInfo.data.type) {
                    this.thumbUp = false;
                    this.thumbUpNum--;
                  } else {
                    this.thumbDown = false;
                  }
                }
                if (evaluateInfo.data.type !== type) {
                  axios
                    .post(
                      "http://175.24.115.240:8080/api/Post/evaluate",
                      {},
                      {
                        headers: {
                          Authorization: this.token,
                        },
                        params: {
                          userId: this.userId,
                          postId: this.postId,
                          type: type,
                        },
                      }
                    )
                    .then((response) => {
                      if (response.data.status) {
                        if (type) {
                          this.thumbUp = true;
                          this.thumbUpNum++;
                        } else {
                          this.thumbDown = true;
                        }
                      }
                    });
                }
              });
          } else {
            axios
              .post(
                "http://175.24.115.240:8080/api/Post/evaluate",
                {},
                {
                  headers: {
                    Authorization: this.token,
                  },
                  params: {
                    userId: this.userId,
                    postId: this.postId,
                    type: type,
                  },
                }
              )
              .then((response) => {
                if (response.data.status) {
                  if (type) {
                    this.thumbUp = true;
                    this.thumbUpNum++;
                  } else {
                    this.thumbDown = true;
                  }
                }
              });
          }
        });
    },
  },
  mounted: function () {
    this.$nextTick(() => {
      this.Follow(0);
    });
    this.postId = this.$route.params.postId;
    console.log(this.postId)
    // this.postId = '05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b'
    axios
      .get("http://175.24.115.240:8080/api/Show/post", {
        headers: {
          Authorization: this.token,
        },
        params: {
          // userId: this.userId,
          userId: "u1001",
          postId: this.postId,
        },
      })
      .then((response) => {
        this.title = response.data.data1[0].title;
        this.totalFloor = response.data.data1[0].floor;
        this.thumbUpNum = response.data.data1[0].usefulnum;
        this.postData.push({
          userId: response.data.data1[0].userid,
          nickName: response.data.data1[0].userid,
          content: response.data.data1[0].content,
          date: response.data.data1[0].date,
          replys: [],
        });
        response.data.data2.sort(function (a, b) {
          if (a.floor !== b.floor) {
            return a.floor - b.floor;
          } else if (a.type !== b.type) {
            return a.type - b.type;
          } else {
            return a.date > b.date ? 1 : -1;
          }
        });
        response.data.data2.forEach((data) => {
          if (data.type === 0) {
            this.postData.push({
              userId: data.userid,
              nickName: data.userid,
              content: data.content,
              date: data.date,
              replys: [],
            });
          } else {
            this.postData[data.floor].replys.push({
              userId: data.userid,
              nickName: data.userid,
              content: data.content,
              date: data.date,
            });
          }
        });
        this.postData.forEach((data) => {
          if (data.userId === this.postData[0].userId) {
            this.masterData.push(data);
          }
        });
        this.maxPage = Math.ceil(this.postData.length / 10);
        this.ShiftPage();
      });
    axios
      .get("http://175.24.115.240:8080/api/Post/CanEvaluate", {
        headers: {
          Authorization: this.token,
        },
        params: {
          userId: this.userId,
          postId: this.postId,
        },
      })
      .then((response) => {
        if (!response.data.canEvaluate) {
          if (response.data.type) {
            this.thumbUp = true;
          } else {
            this.thumbDown = true;
          }
        }
      });
  },
  filters: {
    ellipsis(content) {
      if (!content) {
        return "";
      } else if (content.length > 30) {
        return content.slice(0, 28) + "...";
      } else {
        return content;
      }
    },
  },
};
</script>
