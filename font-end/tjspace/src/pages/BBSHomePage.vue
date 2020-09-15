<template>
  <q-page>
    <!-- title -->
    <div class="row justify-center" id="bbsTitle">
      <div class="col-8">
        <q-img :src="bgPath" style="width: 100%">
          <div class="absolute-bottom-left">
            <p>
              <q-img :src="tjuLogo" style="width:100%" />
              TJ SPACE-BBS
            </p>
          </div>
        </q-img>
      </div>
    </div>
    <div class="row justify-center">
      <div class="col-8">
        <!-- 发布主题贴 -->
        <div v-show="isMakingPost">
          <q-input
            v-model="postContent"
            label="输入你的想法"
            type="textarea"
            maxlength="100"
            :dense="dense"
            counter
            filled
          >
          </q-input>
        </div>
        <!-- 交互控件 -->
        <div style="height:3rem">
          <div style="float:right">
            <q-btn-group v-if="isMakingPost">
              <q-btn color="primary" label="取消" @click="cancelPost" />
              <q-btn color="primary" label="确定" @click="submitPost" />
            </q-btn-group>
            <q-btn-group v-else>
              <q-btn
                color="primary"
                label="按主题发布时间排序"
                @click="
                  this.orderType = 3;
                  getPosts(this.orderType);
                "
              />
              <q-btn
                color="primary"
                label="按最新评论时间排序"
                @click="
                  this.orderType = 0;
                  getPosts(this.orderType);
                "
              />
              <q-btn
                color="primary"
                icon="add_comment"
                label="发布"
                @click="makeNewPost"
              />
            </q-btn-group>
          </div>
        </div>
      </div>
    </div>

    <!-- 帖子  放在list中显示-->
    <div class="row justify-center">
      <div class="col-8">
        <q-list bordered>
          <q-infinite-scroll @load="onLoad" :offset="10">
            <div v-for="(post, index) in postInfo" :key="post.id">
              <q-item clickable>
                <!-- 主要内容 -->
                <q-item-section v-ripple clickable @click="jumpToPost(index)">
                  <q-item-label>
                    {{ post.postContent }}
                  </q-item-label>
                  <q-item-label caption>
                    <q-icon name="person" />
                    {{ post.posterName }}
                  </q-item-label>
                  <q-item-label caption>
                    最新评论于{{ post.latestCommentTime }}
                    <br />
                    {{ post.commentAccount }}评论
                  </q-item-label>
                </q-item-section>
                <!-- 交互 -->
                <q-item-section side top>
                  <q-item-label>
                    <q-btn
                      v-if="post.canThumb"
                      flat
                      icon="thumb_up"
                      @click="thumbUp(index)"
                    />
                    <q-btn
                      v-else
                      flat
                      icon="thumb_up"
                      color="red"
                      @click="thumbUp(index)"
                    />
                    {{ post.agreeAccount }}
                    <q-btn
                      v-if="post.canStep"
                      flat
                      icon="thumb_down"
                      @click="thumbDown(index)"
                    />
                    <q-btn
                      v-else
                      flat
                      icon="thumb_down"
                      color="black"
                      @click="thumbDown(index)"
                    />
                  </q-item-label>
                </q-item-section>
              </q-item>
              <q-separator spaced inset />
            </div>
            <!-- 加载动画 -->
            <template v-slot:loading v-if="!this.isBottom">
              <div class="row justify-center q-my-md">
                <q-spinner-dots color="primary" size="40px" />
              </div>
            </template>
          </q-infinite-scroll>
        </q-list>
      </div>
    </div>
  </q-page>
</template>

<script>
import axios from "axios";

const URL = "http://175.24.115.240:8080/api/";
export default {
  components: {},
  data() {
    return {
      bgPath: require("../assets/bbsBackground.png"),
      tjuLogo: require("../assets/TJU.png"),
      isMakingPost: false,
      postContent: "",
      postInfo: [],
      //默认以发帖时间排序
      orderType: 3,
      currPage: 0,
      isBottom: false,
      userId: "",
      //this.token应该由login传递过来
      token:
        "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjkzNTMwMzY3ZDI0OTFiMzQ0MTEzODYwZGUyN2QzNzdlIiwidHlwIjoiSldUIn0.eyJuYmYiOjE2MDAxNTI4NzcsImV4cCI6MTYwMDE1NjQ3NywiaXNzIjoiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAiLCJhdWQiOlsiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAvcmVzb3VyY2VzIiwiYXBpMSJdLCJjbGllbnRfaWQiOiJjbGllbnQyIiwic3ViIjoiMTExIiwiYXV0aF90aW1lIjoxNjAwMTUyODc3LCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJhcGkxIl0sImFtciI6WyJjdXN0b20iXX0.T-bwvqS0AGRj3HGyYoIUbxqm_zuufNVB2GaDHh6GSXn2lWx_mDapDcHF_oyEIGxpMZAp5HpFLvs9UfX_mqpwnbG3wMd3wMNZ-RLKWmy41sEkGtRZ-_41kPM6WOR-IfUe0t61_zU2ULD7EMOkF_hAYLFFRZIi2-5Rmmk1A-o2-07yDO5PmIrRzeR5JBxeLA7i6IQd2BTLwKCJZC8654Riq-P83gzZGF4GJtTsNRM-lprQybNpiIgs957dDE5Uvzn3DOTlqrcYorY9JeaM-lprzePmfGdcQFTAhjmMOr9Ist5yvjX02igx_Qzk3yPtsBRjp2DhW-syzZ7BnXgs_sKqqQ",
    };
  },
  methods: {
    initUserInfo: function() {
      //未实现，占位
      //等待login实现
      this.userId = "u1001";
      console.log("get user info");
    },
    makeNewPost: function() {
      this.isMakingPost = true;
    },
    cancelPost: function() {
      this.isMakingPost = false;
      this.postContent = "";
    },
    submitPost: async function() {
      var resp = await axios.post(
        URL + `Post/post`,
        {},
        {
          headers: {
            Authorization: this.token,
          },
          params: {
            title: this.postContent,
            content: "null",
            userId: this.userId,
          },
        }
      );
      console.log(resp);
      this.isMakingPost = false;
      this.postContent = "";

      this.cleanPage();
      this.getPosts(this.orderType, this.currPage);
      this.currPage++;
    },
    jumpToPost: function(index) {
      this.$router.push({
        name: "Forum",
        params: { postId: this.postInfo[index].postId },
      });
    },
    thumbUp: async function(index) {
      var evaluatable = true;
      await axios
        .get(URL + `Post/CanEvaluate`, {
          headers: {
            Authorization: this.token,
          },
          params: {
            postId: this.postInfo[index].postId,
            userId: this.userId,
          },
        })
        .then((resp) => {
          console.log("return:" + resp.data.canEvaluate);
          if (!resp.data.canEvaluate) {
            evaluatable = false;
            return;
          }
        });
      if (!evaluatable) {
        return;
      }
      axios.post(
        URL + `Post/evaluate`,
        {},
        {
          headers: {
            Authorization: this.token,
          },
          params: {
            postId: this.postInfo[index].postId,
            userId: this.userId,
            type: 1,
          },
        }
      );
      this.postInfo[index].agreeAccount++;
      this.postInfo[index].canThumb = 0;
    },
    thumbDown: async function(index) {
      var evaluatable = true;
      await axios
        .get(URL + `Post/CanEvaluate`, {
          headers: {
            Authorization: this.token,
          },
          params: {
            postId: this.postInfo[index].postId,
            userId: this.userId,
          },
        })
        .then((resp) => {
          if (!resp.data.canEvaluate) {
            evaluatable = false;
            return;
          }
        });
      if (!evaluatable) {
        return;
      }
      var resp = axios.post(
        URL + `Post/evaluate`,
        {},
        {
          headers: {
            Authorization: this.token,
          },
          params: {
            postId: this.postInfo[index].postId,
            userId: this.userId,
            type: 0,
          },
        }
      );
      console.log(resp);
      this.postInfo[index].agreeAccount--;
      this.postInfo[index].canStep = 0;
    },
    cleanPage: function() {
      this.postInfo.length = 0;
      this.currPage = 0;
      this.isBottom = false;
    },
    getPosts: async function(type, page) {
      console.log(page);
      await axios
        .get(URL + `Show/getPosts`, {
          headers: {
            Authorization: this.token,
          },
          params: {
            orderType: type,
            startPosition: page * 12,
            userId: this.userId,
          },
        })
        .then((resp) => {
          console.log(resp.data.posts);
          var posts = resp.data.posts;
          if (posts.length == 0) {
            this.isBottom = true;
          }
          for (var i = 0; i < posts.length; i++) {
            var tempPost = {
              posterName: posts[i].nickname,
              postContent: posts[i].title,
              agreeAccount: posts[i].usefulNum - posts[i].uselessNum,
              latestCommentTime: posts[i].latestReply.replace("T", "/"),
              commentAccount: posts[i].numOfReply,
              postId: posts[i].postId,
              canStep: posts[i].canStep,
              canThumb: posts[i].canThumb,
            };
            this.postInfo.push(tempPost);
            //如果到底了
            if (posts.length < 12) {
              this.isBottom = true;
            }
          }
        });
    }, //end get post
    onLoad(index, done) {
      if (this.isBottom) {
        return;
      }
      setTimeout(() => {
        this.getPosts(this.orderType, this.currPage);
        this.currPage++;
        done();
      }, 2000);
    },
  },
  mounted() {
    this.initUserInfo();
  },
};
</script>
