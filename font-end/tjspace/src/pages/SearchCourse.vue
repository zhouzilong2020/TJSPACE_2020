<template>

  <q-page-container class="body-right row"  style="display:flex;">
    <div class="left">
      <div class="q-pa-md" style="max-width: 780px">
        <div class="q-gutter-md">
          <div>
            <q-badge color="teal">发现更多课程</q-badge>
          </div>
          <q-input v-model="search" debounce="500" filled placeholder="请输入希望搜索的课程名称">
              <template v-slot:append>
                <q-icon name="search" ></q-icon>
              </template>
          </q-input>
        </div>
      </div>

      <div class="choose">
        <q-select standout="bg-teal text-white" v-model="model" :options="department" label="学院" ></q-select>
      </div>
  
      <div class="content" v-for="item in courseInfo" :key="item.label" :value="item.value">
        <q-card class="my-card bg-secondary text-white">  
          <q-card-section>
            <div class="text-h6">{{item.name}}</div>
            <div class="text-subtitle2">{{item.teacher}}</div>
          </q-card-section>
        
          <q-card-section>
            {{ item.intro }}
          </q-card-section>

          <q-separator dark ></q-separator>

          <q-card-actions>
            <q-btn flat>详情</q-btn>
            <q-btn flat style="margin-left:100px;">打分</q-btn>
          </q-card-actions>
        </q-card>
      </div>
    </div>
    
    <div class="right">

      <div class="q-pa-md" style="width:292px;margin-top:213px;">
        <q-parallax :height="1160">
          <template v-slot:media>
          <!-- 这里的链接需要使用webpack的require -->
            <img :src="path">
          </template>

        <template v-slot:content="scope">
          <div
            class="absolute column items-center"
            :style="{
            opacity: 0.45 + (1 - scope.percentScrolled) * 0.55,
            top: (scope.percentScrolled * 60) + '%',
            left: 0,
            right: 0
            }"
          >
          <!-- 这里的链接需要使用webpack的require -->
          <img :src="path" style="width: 150px; height: 150px">
          <div class="text-h3 text-white text-center">TJspace</div>
          </div>
        </template>
        </q-parallax>
      </div>
    </div>
  </q-page-container>

</template>

<script>
export default {
  components:{
  },

  data () {
    return {
      path:require('../assets/tongji.jpeg'),
      inputSearch:'',
      drawer : false,
      active : -1,
      department: [
        '软件学院', '电信学院', '汽车学院', '交运学院', '还有什么学院'
      ],
      grade:[
        '一年级','二年级','三年级','四年级'
      ],
      courseInfo:[
          {name:"数据库原理与应用",teacher:"袁时金",intro:"这是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程"},
          {name:"计算机系统结构",teacher:"张晨曦",intro:"这是仍然是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程"},
          {name:"操作系统",teacher:"张慧娟",intro:"这是还是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程"},
          {name:"系统分析与设计",teacher:"孙萍",intro:"这是仍然是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程"},
          {name:"创新创业",teacher:"时东兵",intro:"这是仍然是一门辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡辣鸡课程"},
      ],
      userInfo:{
        nickName: "lili",
        eMail:"1888888@tongji.edu.cn",
      },
      
    }
  }
}
</script>

<style>
.content{margin-left:-58px;width:800px;}

.choose{width:200px;margin-left:14px;}
.my-card{ width: 100%;max-width: 720px;margin-top:50px;margin-left:70px;}




</style>
