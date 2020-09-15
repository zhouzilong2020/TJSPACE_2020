<template>
  <q-card class="white q-mb-xs">
    <div class="row">
      <div class="col-auto">
        <div class="row q-mx-md q-my-md">
          <q-avatar size="100px">
            <img v-bind:src="headURL" />
          </q-avatar>
        </div>
        <a class="row justify-center h4" style="text-decoration: none" href="#">
          {{ nickName }}
        </a>
      </div>
      <div class="col q-mx-lg q-my-lg">
        <div class="row word-wrap:break-word">
          <div class="text-wrapper">{{ content }}</div>
        </div>
      </div>
    </div>
    <div class="row justify-end items-center">
      <div class="col-auto">
        <q-btn
          :class="{ activedColor: thumbUp }"
          class="q-mx-sm"
          @click="ThumbUP"
          icon="thumb_up"
          flat
          round
        >
          <div v-if="thumbUpNum !== 0">{{ thumbUpNum }}</div>
        </q-btn>
        <q-btn
          class="q-mx-sm"
          :class="{ activedColor: thumbDown }"
          @click="ThumbDown"
          icon="thumb_down"
          flat
          round
        />
        <q-btn class="q-mx-sm" @click="Expand" :label="buttonText" flat round>
          <div v-if="floor !== 1">({{ testData.length }})</div>
        </q-btn>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <q-expansion-item
          v-model="expanded"
          expand-separator
          expand-icon-toggle
          expand-icon-class="hidden"
          :label="floor + '楼 ' + date"
        >
          <div v-if="floor !== 1">
            <div v-for="(data, i) in testData" :key="i">
              <Reply
                :nickName="data.nickName"
                @changeReplyPrefix="ChangePrefix"
                :content="tcontent"
              />
            </div>
            <q-tabs
              v-model="replyPage"
              inline-label
              class="white q-mt-xs shadow-2"
            >
              <div v-for="(data, i) in testData" :key="i">
                <q-tab
                  :name="i + 1"
                  :label="i + 1"
                  color="white"
                  class="q-mx-xs"
                />
              </div>
            </q-tabs>
            <q-card class="white q-mt-xs justify-center">
              <div class="row justify-end">
                <div class="col-10">
                  <q-input outlined ref="reply" :prefix="repleyPrefix" />
                </div>
                <div class="col-auto q-pr-sm q-pl-lg q-py-sm">
                  <q-btn
                    class="q-mx-xs"
                    color="white"
                    text-color="black"
                    @click="Publish"
                    label="发表"
                  />
                </div>
              </div>
            </q-card>
          </div>
        </q-expansion-item>
      </div>
    </div>
  </q-card>
</template>
<script>
import Reply from "./Reply.vue";
const testData = [
  {
    nickName: "DiDi",
  },
  {
    nickName: "EiEi",
  },
  {
    nickName: "FiFi",
  },
];
export default {
  name: "Post",
  components: {
    Reply,
  },
  props: {
    headURL: {
      type: String,
      default: "https://cdn.quasar.dev/img/avatar.png",
    },
    nickName: {
      type: String,
      required: true,
    },
    content: {
      type: String,
      default: "",
    },
    floor: {
      type: Number,
      required: true,
    },
    propThumbUpNum: {
      type: Number,
      default: 0,
    },
    date: {
      type: String,
      default: "2020-8-11 21:42",
    },
  },
  data() {
    return {
      expanded: false,
      buttonText: "回复",
      testData,
      tcontent:
        "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT",
      replyPage: 1,
      repleyPrefix: "",
      thumbUp: false,
      thumbDown: false,
      thumbUpNum: this.propThumbUpNum,
    };
  },
  methods: {
    ChangePrefix(nickName) {
      this.repleyPrefix = "回复@" + nickName + ":";
      this.$refs.reply.focus();
    },
    Expand() {
      this.expanded = !this.expanded;
      if (this.floor === 1) {
        this.$emit("focusBottom");
        return;
      }
      if (this.expanded) {
        this.buttonText = "收起";
        this.$nextTick(() => {
          this.$refs.reply.focus();
        });
      } else {
        this.buttonText = "回复";
        this.replyPrefix = "";
      }
    },
    ThumbUP() {
      this.thumbUp = !this.thumbUp;
      this.thumbDown = false;
      if (this.thumbUp) {
        this.thumbUpNum++;
      } else {
        this.thumbUpNum--;
      }
    },
    ThumbDown() {
      this.thumbDown = !this.thumbDown;
      this.thumbUp = false;
      this.thumbUpNum--;
    },
    Publish() {
      this.repleyPrefix = "";
    },
  },
};
</script>
<style lang="sass">
.activedColor
  color: red;
</style>
