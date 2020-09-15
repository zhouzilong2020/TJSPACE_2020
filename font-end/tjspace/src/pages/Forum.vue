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
                  class="col-auto q-ma-xs q-px-sm q-py-xs"
                  flat
                  :style= "recommend.color"
                >
                  {{ i + 1 }}
                </q-card>
                <router-link
                  class="col-auto"
                  style="text-decoration: none"
                  :to="{
                    name: 'Forum',
                    params: { postId: recommend.posetId },
                  }"
                  @click.native="Reload()"
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
     <q-spinner-dots v-if="0" class="fixed-center" color="primary" size="40px" />
    </div> 
</template>

<script>
import Post from "../components/forum/Post";
import axios from "axios";
const recommendData = [
  {
    title: "舒服了",
    posetId: "2abee334-495f-481d-860e-ad31be83de0d",
    color:'background:#ffd700'
  },
  {
    title: "如何评价post终于可以调了",
    posetId: "05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b",
    color:'background: 	#F5F5F5'
  },
  {
    title: "如何评价post终于可以调了",
    posetId: "05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b",
    color: 'background:	#D2691E'
  },
  {
    title: "如何评价post终于可以调了",
    posetId: "05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b",
    color: 'background:	#C0C0C0'
  },
  {
    title: "如何评价post终于可以调了",
    posetId: "05dfc0d8-9b42-4f4a-947e-a0ac28dfe99b",
    color: 'background:	#C0C0C0'
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
      postData: {},
      replyData: [],
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
      token:"Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjkzNTMwMzY3ZDI0OTFiMzQ0MTEzODYwZGUyN2QzNzdlIiwidHlwIjoiSldUIn0.eyJuYmYiOjE2MDAxNjIwMjksImV4cCI6MTYwMDE2NTYyOSwiaXNzIjoiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAiLCJhdWQiOlsiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAvcmVzb3VyY2VzIiwiYXBpMSJdLCJjbGllbnRfaWQiOiJjbGllbnQyIiwic3ViIjoiMTExIiwiYXV0aF90aW1lIjoxNjAwMTYyMDI5LCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJhcGkxIl0sImFtciI6WyJjdXN0b20iXX0.MLJ9f3K5lgSeiEuxE89gDMUYdLs6g2zcCepqulSI05XZGfHsfil3LGdXH_6XLazq0B7DBBLo7BiG8SsWZNyeUZvVvNCt1nJ0hcDhfSmiu-6r7Rh_8v2Wi-mvX4V3zGWHuFQOCDb73Qev9mEV7oKqKq8mxYYTQzwn41f2GpekQCg_fC6r_IVaY6aBgKC5jdf_8IARzd170utW8ZV7prQDkCD459ouIRhHNFtogLaadPJrzOrU78H7C7PJJwP66w4jp591ogWhsgh_4TBSZKLoYAerhUgzCwWt_CxFniHN-3KWOLh5luvVYLQMNXx5gzfetsHkSDhvNVOs1XTKRC48-Q",
      inputSearch: "",
      text: "",
      recommendData: recommendData,
      onlyMaster: false,
      onlyMasterText: "只看楼主",
      jump: false
    };
  },
  methods: {
    Reload() {
      window.location.reload();
    },
    ShiftPage() {
      this.displays=[]
      var data =[]
      if (!this.onlyMaster) {
        if(this.currentPage == 1){
          this.displays.push({
            userId:this.postData.userId,
            content:this.postData.content,
            date: this.postData.date,
            nickName: this.postData.nickName,
            replys:[]
          })
          data = this.replyData.slice(0,9)
        } else {
          data = this.replyData.slice(this.currentPage*10-11,this.currentPage*10-1)
        }
      } else {
         if(this.currentPage == 1){
          this.displays.push({
            userId:this.postData.userId,
            content:this.postData.content,
            date: this.postData.date,
            nickName: this.postData.nickName,
            replys:[]
          })
          data = this.masterData.slice(0,9)
        } else {
          data = this.masterData.slice(this.currentPage*10-11,this.currentPage*10-1)
        }
      }
        var str = ''
        data.forEach(reply => {
          str += reply.replyId + ',';
          reply.replys.forEach( r => {
            str += r.replyId + ','
          })
        })
        str = str.slice(0,-1)
        axios
        .get("http://175.24.115.240:8080/api/Show/reply", {
          headers: {
            Authorization: this.token,
          },
          params: {
            str: str
          },
        }).then( response =>{
          var map = []
          response.data.data.forEach( reply => {
            map[reply[0].replyid]={
              userId:reply[0].userid,
              content:reply[0].content,
              date:reply[0].date,
            }
          })
          data.forEach(reply => {
          this.displays.push({
            userId:map[reply.replyId].userId,
            content:map[reply.replyId].content,
            date: map[reply.replyId].date,
            nickName: reply.nickName,
            replys:[]
          })
          reply.replys.forEach( r => {
            this.displays[this.displays.length-1].replys.push({
              userId:map[r.replyId].userId,
              content:map[r.replyId].content,
              date: map[r.replyId].date,
              nickName: r.nickName,
            })
          })
          this.displays[this.displays.length-1].replys.sort(function (a, b) {
            return a.date > b.date ? 1 : -1;
          });
        })
        })
      this.ToTop();
    },
    OnlyMaster() {
      this.onlyMaster = !this.onlyMaster;
      if (this.onlyMaster) {
        this.maxPage = Math.ceil(this.masterData.length / 10);
        this.onlyMasterText = "取消只看楼主";
      } else {
        this.maxPage = Math.ceil(this.replyData.length / 10);
        this.onlyMasterText = "只看楼主";
      }
      this.currentPage = 1;
      this.ShiftPage();
    },
    ToBottom() {
      this.jump = true;
      document.documentElement.scrollTo(
        undefined,
        document.documentElement.offsetHeight
      );
      this.$refs.bottom.focus();
      document.getElementById("title").style.top = document.documentElement.scrollTop -50 +'px';
      document.getElementById("toTop").style.top =
        document.documentElement.scrollTop+ 
        document.documentElement.clientHeight -
        document.getElementById("toTop").offsetHeight -
        100 +
        "px";
    },
    ToTop() {
      this.jump = true;
      document.documentElement.scrollTo(undefined, 0);
      document.getElementById("title").style.top = 0;
      document.getElementById("toTop").style.top = 
      document.documentElement.clientHeight -
      document.getElementById("toTop").offsetHeight -
      100 +
      "px";
    },
    Follow(position) {
      if(this.jump){
        this.jump = false;
        return
      }
      var title = document.getElementById("title");
      var toTop = document.getElementById("toTop");
      if ( document.getElementsByTagName('header')[0].getAttribute('class').indexOf('q-header--hidden') != -1) {
        title.style.top = position - 50 + "px";
      } else {
        title.style.top = position + "px";
      }
      if ( document.getElementsByTagName('footer')[0].getAttribute('class').indexOf('q-footer--hidden') != -1) {
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
            this.Reload();
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
        axios
      .get("http://175.24.115.240:8080/api/Show/post", {
        headers: {
          Authorization: this.token,
        },
        params: {
          postId: this.postId,
        },
      })
      .then((response) => {
        this.title = response.data.data1[0].title;
        this.totalFloor = response.data.data1[0].floor;
        this.thumbUpNum = response.data.data1[0].usefulnum;
        this.postData = {
          userId: response.data.data1[0].userid,
          content: response.data.data1[0].content,
          date: response.data.data1[0].date,
          nickName: response.data.data2,
          replys: [],
        }
        response.data.data3.sort(function (a, b) {
          if (a.floor !== b.floor) {
            return a.floor - b.floor;
          } else if (a.type !== b.type) {
            return a.type - b.type;
          }
        });
        response.data.data3.forEach((data) => {
          if (data.type === 0) {
            this.replyData.push({
              replyId: data.replyId,
              nickName: data.name,
              replys: [],
            });
          } else {
            this.replyData[data.floor-1].replys.push({
              replyId: data.replyId,
              nickName: data.name
            });
          }
        });
        
        this.replyData.forEach((data) => {
          if (data.nickName == this.postData.nickName) {
            this.masterData.push(data);
          }
        });
        this.maxPage = Math.ceil(this.replyData.length / 10);
        this.currentPage = 1;
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
    }
  }
  };
</script>
