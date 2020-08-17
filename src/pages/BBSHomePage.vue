<template>
  <q-page>
    <!-- title -->
    <div class="row justify-center" id="bbsTitle">
      <div class="col-12">
        <q-img src="../assets/bbsBackground.png" style="width: 100%">
          <div class="absolute-bottom-left">
            <p>
              <q-img src="../assets/TJU.png" style="width:100%" />
              TJSPACE-BBS
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
      <q-btn color="primary" label="取消" @click="cancelPost"/>
      <q-btn color="primary" label="确定" @click="submitPost"/>
    </div>
    <!-- 交互控件 -->
    <div style="height:3rem">
      <div style="float:right">
        <q-btn-group>
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
        <q-item v-for="(post,index) in postInfo" :key="post.id">
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
              <q-btn flat color="black" icon="thumb_up" @click="thumbUp(index)" />
              {{ post.agreeAccount }}
              <q-btn flat color="black" icon="thumb_down" />
            </q-item-label>
          </q-item-section>
        </q-item>
      </q-list>
    </div>
  </q-page>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      isMakingPost: false,
      postContent: "",
      postInfo: [
        {
          posterName: "lili神",
          postContent: "如何评价ysj的数据库原理与应用是我上过最好的数据库",
          agreeAccount: 200,
          latestCommentTime: "8/5/15:32",
          commentAccount: 200
        },
        {
          posterName: "lili神",
          postContent: "如何评价1学分的课程设计事这么多",
          agreeAccount: 0,
          latestCommentTime: "8/5/15:32",
          commentAccount: 210
        },
        {
          posterName: "lili神",
          postContent: "如何评价如何评价",
          agreeAccount: -100,
          latestCommentTime: "8/5/15:32",
          commentAccount: 20
        }
      ]
    };
  },
  methods: {
    makeNewPost: function() {
      this.isMakingPost = true;
    },
    cancelPost:function(){
      this.isMakingPost=false;
      this.postContent='';
    },
    submitPost:function(){
      this.isMakingPost=false;
      alert(this.postContent);
      this.postContent='';
    },
    jumpToPost:function(index){
      alert(index);
    },
    thumbUp:function(index){
      this.postInfo[index].agreeAccount++;
    },
    thumbDown:function(index){
      this.postInfo[index].agreeAccount--;
    },
    getPosts: function() {
      //先拿天气接口测试
      var that = this;
      axios.get("http://wthrcdn.etouch.cn/weather_mini?city=" + "北京").then(
        function(response) {
          var dataString = response.data.data;
          var tempPost = {
            posterName: "lili神",
            postContent:
              "测试接口：如何评价" +
              dataString.city +
              "今天温度" +
              dataString.wendu,
            agreeAccount: 0,
            latestCommentTime: "8/5/15:32",
            commentAccount: 210
          };
          that.postInfo.push(tempPost);
        },
        function(err) {
          console.log("错了，憨批");
        }
      );
    },
  },
  mounted() {
    this.getPosts();
  }
};
</script>
