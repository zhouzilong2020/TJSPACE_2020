<template>
  <q-page>
    <!-- title -->
    <div class="row justify-center" id="bbsTitle">
      <div class="col-12">
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
    <!-- 发布主题贴 -->
    <div v-show="isMakingPost">
      <q-input
        v-model="postContent"
        label="输入你的想法"
        type="textarea"
        filled
      />
    </div>
    <!-- 交互控件 -->
    <div style="height:3rem">
      <div style="float:right">
        <q-btn-group v-if="isMakingPost">
          <q-btn color="primary" label="取消" @click="cancelPost" />
          <q-btn color="primary" label="确定" @click="submitPost" />
        </q-btn-group>
        <q-btn-group v-else>
          <q-btn color="primary" label="按主题发布时间排序" />
          <q-btn color="primary" label="按最新评论时间排序" />
          <q-btn
            color="primary"
            icon="add_comment"
            label="发布"
            @click="makeNewPost"
          />
        </q-btn-group>
      </div>
    </div>
    <!-- 帖子  放在list中显示-->
    <div>
      <q-list separator bordered>
        <q-item v-for="(post, index) in postInfo" :key="post.id">
          <!-- 主要内容 -->
          <q-item-section clickable @click="jumpToPost(index)">
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
                flat
                color="black"
                icon="thumb_up"
                @click="thumbUp(index)"
              />
              {{ post.agreeAccount }}
              <q-btn
                flat
                color="black"
                icon="thumb_down"
                @click="thumbDown(index)"
              />
            </q-item-label>
          </q-item-section>
        </q-item>
      </q-list>
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
      userId: "u1001",
      //this.token应该由login传递过来
      token:
        "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjkzNTMwMzY3ZDI0OTFiMzQ0MTEzODYwZGUyN2QzNzdlIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1OTk0ODg4ODAsImV4cCI6MTU5OTQ5MjQ4MCwiaXNzIjoiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAiLCJhdWQiOlsiaHR0cDovLzE3NS4yNC4xMTUuMjQwOjUwMDAvcmVzb3VyY2VzIiwiYXBpMSJdLCJjbGllbnRfaWQiOiJjbGllbnQyIiwic3ViIjoiMTExIiwiYXV0aF90aW1lIjoxNTk5NDg4ODgwLCJpZHAiOiJsb2NhbCIsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJhcGkxIl0sImFtciI6WyJjdXN0b20iXX0.aTfqL1JfqJD2udVrn2IhbOYBZuTYppsWBSsPYx5w1N5GDi6ubcfj90g3W7FbTh7CFztdC-NL9fnr74UzbgopONywiHSx2OzHMPOhqKV5WK5LDC6EsJrje1Y-dPUUBFe1MZ3QXTQbWcvfdXT3d2zN_8UKtVZhM9DGwXZwKsC_AiKrcK2ffPCI7lKAauNcXU0q3MyZdV5YfR1GOzI7qzSy1Q8SG6THfPNlqI_nNHfQiuCUqo3w7hytngqaYLgsTB0ZtOCdRrhrhDBYmPl3cTkl0lq57KbzxkTwP9y90MW_U5t5Vn3hI_pyCsLFFWG6Jm0CYWp18_WX3LLzpiyQdvynyw",
    };
  },
  methods: {
    initUserInfo: function() {
      //未实现，占位
      //等待login实现
      console.log("get user info");
    },
    makeNewPost: function() {
      this.isMakingPost = true;
    },
    cancelPost: function() {
      this.isMakingPost = false;
      this.postContent = "";
    },
    submitPost: function() {
      var resp = axios.post(
        URL + `Post/post`,
        {},
        {
          headers: {
            Authorization: this.token,
          },
          params: {
            title: this.postContent,
            content: "不评价",
            userId: this.userId,
          },
        }
      );
      console.log(resp);
      this.isMakingPost = false;
      this.postContent = "";
      this.getPosts();
    },
    jumpToPost: function(index) {
      //未实现，占位
      alert(this.postInfo[index].postId);
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
    },
    getPosts: function() {
      axios
        .get(URL + `Show/getPosts`, {
          headers: {
            Authorization: this.token,
          },
          params: {
            orderType: 0,
            startPosition: 0,
            userId: this.userId,
          },
        })
        .then((resp) => {
          console.log(resp.data.posts);
          this.postInfo.length = 0;
          var posts = resp.data.posts;
          for (var i = 0; i < posts.length; i++) {
            var tempPost = {
              posterName: posts[i].nickName,
              postContent: posts[i].title,
              agreeAccount: posts[i].usefulNum - posts[i].uselessNum,
              latestCommentTime: posts[i].latestReply.replace("T", "/"),
              commentAccount: posts[i].numOfReply,
              postId: posts[i].postId,
              canStep: posts[i].canStep,
              canThumb: posts[i].canThumbs,
            };
            this.postInfo.push(tempPost);
          }
        });
    }, //end get post
  },
  mounted() {
    this.initUserInfo();
    this.getPosts();
  },
};
</script>
