<template>
  <layout>
    <template v-slot:main>

      <div class="row justify-center">
      <div class="col-auto">
        <q-card class="row q-mb-xs z-top" style="width:750px" id='title' v-scroll="Follow">
          <q-banner class="col white">
            {{title}}
          </q-banner>
          <div class="col-auto">
          <q-btn class="column-auto q-ma-md shadow-2"  flat dense size="md" color="white" text-color="black" label="只看楼主" />
          </div>
        </q-card>
      <div style="width:750px">
      <div v-for="(post,i) in postData" :key="i">
        <Post :nickName="post.nickName" :floor="i+1"  :content="tcontent" @focusBottom = "ToBottom"/>
      </div>
      <q-card class="q-my-lg" >
        <q-editor ref="bottom" v-model="editor" min-height="5rem"/>
        <div class="row justify-end">
          <q-btn class="q-ma-sm" text-color="black" label="发表" />
        </div>
      </q-card>
      <div class="row justify-start q-pb-lg">
        <q-pagination v-model="current" @click="shiftPage" :max="10" :direction-links="true"></q-pagination>
      </div>
      
      </div>
      </div>
      <div class="col-auto">
        <q-card class="q-ml-xs" id='toTop' style="width:60px">
           <q-btn @click="ToTop" class="bg-primary q-py-sm" style="width:60px" color="white" icon="keyboard_arrow_up" flat>
             <q-tooltip>返回顶部</q-tooltip>
           </q-btn>
        </q-card>
      </div>
      </div>

    </template>
    
  </layout>
</template>

<script>
import Post from '../components/forum/Post'
import layout from '../components/layout'
var postData = [
  {
    nickName: 'AiAi'
  },
  {
    nickName: 'BiBi'
  },
  {
    nickName: 'CiCi'
  },
  {
    nickName: 'AiAi'
  },
  {
    nickName: 'BiBi'
  },
  {
    nickName: 'CiCi'
  },
  {
    nickName: 'AiAi'
  },
  {
    nickName: 'BiBi'
  },
  {
    nickName: 'CiCi'
  },
  {
    nickName: 'CiCi'
  }
]
var testData = [
  {
    title: 'AiAiAiAiAiAiAiAiAiAiAiAiA'
  },
  {
    title: 'BiBiBiBiBiBiBiBiBiBiBiBiBiBiBiBi'
  },
  {
    title: 'CiCiCiCiCiCiCiCiCiCiCiCiCiiiiii'
  },
  {
    title: 'AiAi'
  },
  {
    title: 'BiBi'
  },
  {
    title: 'CiCi'
  },
  {
    title: 'AiAi'
  },
  {
    title: 'BiBi'
  },
  {
    title: 'CiCi'
  }
]
export default {
  name: 'MainLayout',
  components: {
    Post,
    layout,
  },
  data () {
    return {
      expanded: false,
      title: 'Title',
      postData,
      testData,
      current: 1,
      editor: '',
      update: false,
      tcontent: 'a',
      inputSearch: '',
      logoPath: '',
      avatarPath: 'https://cdn.quasar.dev/img/avatar.png',
      avatarBGPath: '',
      drawer: false,
      active: -1,
      courseInfo: {
      },
      userInfo: {
        nickName: 'lili',
        eMail: '1888888@tongji.edu.cn'
      },
    }
  },

  methods: {
    shiftPage () {
      console.log(window.innerWidth)
      this.$q.loading.show()
      this.timer = setTimeout(() => {
        this.$q.loading.hide()
        var temp = postData[0]
        for (var i = 0; i < postData.length - 1; i++) {
          postData[i] = postData[i + 1]
        }
        postData[postData.length - 1] = temp
        this.timer = undefined
      }, 3000)
    },
    ToBottom () {
      document.documentElement.scrollTo(undefined, document.documentElement.offsetHeight)
      this.$refs.bottom.focus()
    },
    ToTop () {
      document.documentElement.scrollTo(undefined, 0)
    },
    Follow (position) {
      var title = document.getElementById('title')
      var nav = document.getElementById('nav')
      var toTop = document.getElementById('toTop')
      if (position > nav.offsetHeight) {
        title.style.top = position - nav.offsetHeight + 'px'
      } else {
        title.style.top = 0
      }
      toTop.style.top = position + document.documentElement.clientHeight - toTop.offsetHeight - nav.offsetHeight + 'px'
    }
  },
  mounted: function () {
    this.$nextTick(() => {
      this.Follow(0)
    })
  }
/* filters: {
    ellipsis (content) {
      if (!content) {
        return ''
      } else if (content.length > 30) {
        return content.slice(0, 28) + '...'
      } else {
        return content
      }
    }
  } */
}
</script>
<style>
.body{width: 100%;}
.drawer-btn-penal{position:absolute; left:-40px;}
.body .body-left{position: fixed; left:15px; top:15px;}
.body .body-right{position: absolute; right:15px; top:0; padding:0; left:245px; }
.body .body-right .course-head{margin-top:15px;}
.body .body-right .course-comment{margin-top:15px;}
.body .body-right .option-group{margin-top:15px}
::-webkit-scrollbar {
  width: 0 !important;
}
::-webkit-scrollbar {
  width: 0 !important;height: 0;
}
.text-wrapper {
  word-break: break-all;
  word-wrap: break-word
}
</style>
