<template>
    <q-card class="course-review" flat bordered>
        <q-item :class="topColor">
            <div class="user-infro col-auto row inline justify-evenly">
                <q-item-section class="avatar" avatar>
                    <q-avatar>
                        <img :src="reviewInfro.teacherInfro.photoPath">
                    </q-avatar>
                    <q-item-label class="nickname" horizontal>{{reviewInfro.teacherInfro.nickname}}</q-item-label>
                </q-item-section>
                <q-item-section class="user-infro-detail">

                    <q-item-label class="major" caption>
                        {{reviewInfro.teacherInfro.major}}
                    </q-item-label>
                </q-item-section>
            </div>
            <q-separator vertical />
            <!-- 课程开设时间 -->
            <q-item-section class="course-detail col-auto">
                <q-item-label class="course-year">
                    {{reviewInfro.courseDetail.name}}
                </q-item-label>
                <q-item-label class="course-semester">   
                    {{reviewInfro.courseDetail.semester}}
                </q-item-label>
            </q-item-section>
            <q-separator vertical/>
            <!-- 课程评分情况 -->
            <q-item-section class="user-infro-detail">
                    <q-item-label class="nickname" horizontal>current user:<b>{{reviewInfro.userInfro.nickname}}</b></q-item-label>
                </q-item-section>
            <q-item-section class="course-review-statistic">    
            </q-item-section>
        </q-item>

        <q-separator />
        

        <q-item class="course-review-body" horizontal>
            <q-item class="course-review-body" horizontal>
                <div class="col-5">
                    <q-label class="text-h6">课程测验</q-label>
                    <div class="q-gutter-sm">   
                        <q-checkbox dense v-model="test1" label="期中考试" color="teal" />
                        <q-checkbox dense v-model="test2" label="期末考试" color="orange" />
                        <q-checkbox dense v-model="test3" label="课堂小测" color="red" />
                    </div>
                </div>
                <div class="col-5">
                    <q-label class="text-h6">课程任务</q-label>
                    <div class="q-gutter-sm">   
                        <q-checkbox dense v-model="task1" label="课程作业" color="teal" />
                        <q-checkbox dense v-model="task2" label="课程论文" color="orange" />
                        <q-checkbox dense v-model="task3" label="课程项目" color="red" />
                    </div>
                </div>
                <div class="col-5">
                    <q-label class="text-h6">其他课程内容</q-label>
                    <div class="q-gutter-sm">   
                        <q-checkbox dense v-model="other1" label="课堂考勤" color="teal" />
                        <q-checkbox dense v-model="other2" label="阅读材料" color="orange" />
                        <q-checkbox dense v-model="other3" label="个人展示" color="red" />
                    </div>
                </div>
            </q-item>
        </q-item>
        <q-item class="course-review-body" horizontal>
            <div class="col-6">
                <q-item class="course-review-body" horizontal>
                    <q-label class="text-h6">课程质量</q-label>
                </q-item>
                <q-item class="course-review-body" horizontal>
                <div class="col-8">
                <q-slider
                        v-model="value1"
                        :min="0"
                        :max="10"
                        :step="1"
                        snap
                        label
                        color="blue"
                />
                </div>
                </q-item>

                <q-item class="course-review-body" horizontal>
                <q-label class="text-h6">课程难度</q-label>
                </q-item>
                <q-item class="course-review-body" horizontal>
                <div class="col-8">
                    <q-slider
                        v-model="value2"
                        :min="0"
                        :max="10"
                        :step="1"
                        snap
                        label
                        color="blue"
                    />
                </div>
                </q-item>
            </div>

            <div class="col-6">
                <q-item class="course-review-body" horizontal>
                    <q-label class="text-h6">教学水平</q-label>
                </q-item>
                <q-item class="course-review-body" horizontal>
                <div class="col-8">
                        <q-slider
                         v-model="value3"
                        :min="0"
                        :max="10"
                        :step="1"
                         snap
                         label
                        color="blue"
                      />
                </div>
                </q-item>

                <q-item class="course-review-body" horizontal>
                    <q-label class="text-h6">总体评价</q-label>
                </q-item>
                <q-item class="course-review-body" horizontal>
                <div class="col-8">
                     <q-slider
                        v-model="value4"
                        :min="0"
                        :max="10"
                        :step="1"
                        snap
                        label
                        color="blue"
                    />
                </div>
                </q-item>
            </div>
        </q-item>
        <!-- 具体内容 -->
        <q-item class="course-review-body" horizontal>
            <div class="col-6">
                <q-card-section>
                    <q-label class="text-h6">课程内容</q-label>
                    <q-input filled v-model="text1" label="课程质量" />
                </q-card-section>

                <q-card-section>
                    <q-label class="text-h6">教学水平</q-label>
                    <q-input filled v-model="text2" label="教学水平" />
                </q-card-section>
            </div>
            <div class="col-6">
                <q-card-section>
                    <q-label class="text-h6"> 评分情况</q-label>
                    <q-input filled v-model="text3" label="评分情况" />
                </q-card-section>
                <q-card-section>
                    <q-label class="text-h6">课程作业</q-label>
                    <q-input filled v-model="text4" label="课程作业" />
                </q-card-section>
            </div>
        </q-item>

        <q-item class="course-review-body" horizontal>
            <q-btn color="blue" class="full-width" label="提交" />
        </q-item>
       
    </q-card>
</template>

<script>
export default {
    components:{
    },
    data:()=>{
        return {
            zan:require('../../assets/zan.png'),
            zanFocus:require('../../assets/zan-focus.png'),
            cai:require('../../assets/cai.png'),
            caiFocus:require('../../assets/cai-focus.png'),
            inputText:'请在此输入对该评价的看法',
            expanded:false,  
            test1:false,
            test2:false,
            test3:false,
            task1:false,
            task2:false,
            task3:false,
            other1:false,
            other2:false,
            other3:false,
            value1:5,
            value2:5,
            value3:5,
            value4:5,
            text1:'',
            text2:'',
            text3:'',
            text4:''
        }
    },
    props:{
        reviewInfro:{
            type: Object,
            default: ()=>{
                return {
                    courseStatistic:{
                        reveiwCnt:100,
                        content:"A+",
                        teaching:"A+",
                        grading:"A+",
                        workload:"A+",
                    },
                    teacherInfro:{
                        nickname:"袁时金",
                        photoPath:require("../../assets/teacher.jpg"),
                        grade:"2018级",
                        major:"软件工程",
                    },
                    userInfro:{
                        nickname:"lili",
                        photoPath:require("../../assets/touxiang.jpg")
                    },
                    courseDetail:{
                        name: "数据库原理与应用",
                        year:"2020-2021",
                        semester:"春",
                        midTerm: false,
                        final: true,
                        quiz: false,
                        assignment:true,
                        essay: false,
                        project: false,
                        attendance: true,
                        reading: false,
                        presentation: false,
                    },
                    commentDetail:{
                        content:"这是我上过的最好的一门课，上课内容有趣，生动丰富，不知道为什么我们学校竟然有这么好的一门课，我收获良多，无论是理论还是应用都让我获益匪浅;",
                        teaching:"袁时金老师的教学水平真的太强啦，上课的时候风趣幽默，讲解知识到位，理论体系完善丰富，极大的开阔了学生们的视野，让我们领会到了世界一流大学一流老师的教学水平，早在高考的时候就久闻袁时金老师的大名，这是我来同济大学的重要原因之一，不然我就去清华了",
                        grading:"这门课太容易了，导致我随随便便就拿了个优",
                        workload:"这门课的作业一点也不多，我一下子就能写完",
                        date:"2020.08.06",
                        useful:230,
                        useless:7
                    }
                }
            }
        }
    },
    computed: {
        topColor(){
          return "top-rating-5";  
        },
        getRate(){
            return (grade) =>{
                switch(grade[0]){
                    case "A": return "rating-5";
                    case "B": return "rating-4";
                    case "C": return "rating-3";
                    case "D": return "rating-2";
                    case "F": return "rating-1";
                }
            }
        },
    },
    methods: {
        
    }

}
</script>

<style>

.course-review{margin-bottom: 20px; }

.course-review-body{ padding:0px; margin : 0px; border:0px;}
.nickname{ margin-top:10px}
.user-infro-detail{ margin-right: 10px;}

.course-detail{margin:0 auto; }
.course-detail .course-year{text-align: center; margin: 0 auto; padding:8px}
.course-detail .course-semester{text-align: center; margin-bottom:10px;}

.rating-container {padding: 0; overflow: hidden; list-style: none;}
.rating-container strong {margin-bottom: 5px;}
.rating-container li .rating {
    display: inline-block;
    width: 40px;
    line-height: 30px;
    color: #fff;
    font-weight: 700;
    font-size: 16px;
    margin: 0 auto;
    border-radius: 6px;
    overflow: hidden;
    text-align: center;
}
.rating-1 {background: #fb1420;}
.rating-2 {background: #ff7800;}
.rating-3 {background: #ffba00;}
.rating-4 {background: #afc732;}
.rating-5 {background: #5a5;}


.top-rating-5{background: #f1f8f1;}
.top-rating-4{background: #f7faea;}
.top-rating-3{background: #ffe59e;}
.top-rating-2{background: #ffe1c7;}
.top-rating-1{background: #ffe1c7;}


.course-requirement {color:grey}
.course-requirement ul{ list-style: none; margin:0 auto;}
.course-requirement ul li{line-height: 25px; color:grey; font-weight:800;}
.course-requirement ul .active{color:green;}
.course-requirement ul .iconfont{margin-right:5px;}


.footer{margin: 0 auto; padding: 0; line-height: 0px;}
.footer q-label{font-size: 5px; color:grey; font-weight: 800; }
.footer .course-review-detail{position: absolute; right: 140px;}
.footer .course-review-option{ line-height:0px; height:0px; color:grey; position: relative; bottom: 21px; right:-10px;}
.footer .course-review-option .iconfont{font-size: 14px;}


.review-for-comment q-editor{background-color: wight;}
</style>