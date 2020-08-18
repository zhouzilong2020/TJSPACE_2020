<template>
    <layout>
        <template v-slot:main>
            <q-page-container class="detail body-left">
                <course-detail   :courseInfo="courseInfo" :reviewStatistic="reviewStatistic"/>
            </q-page-container>

            <q-page-container class="body-right">
                <div class="course-head" >
                    <course-head :courseInfo="courseInfo" />
                </div>

                <!-- 搜索栏 -->
                <!-- <div class="option-group row justify-between">
                    <q-select
                    v-model="order"
                    label="选择排序方式"
                    :options="stringOptions"
                    style="width: 250px"
                    behavior="menu"
                    />
                    <q-select
                    v-model="model"
                    label="选择其他学院"
                    :options="stringOptions"
                    style="width: 250px"
                    behavior="menu"
                    />
                    <q-btn color="primary" icon-right="comment" label="撰写评论" unelevated />
                </div> -->
        
                <div class="course-comment">
                    <course-comment v-for="(review, i) in reviews" :key="i" :reviewInfo="review"/>
                    
                </div>
                
            </q-page-container>
        </template>
    </layout>
  
</template>

<script>
import layout from '../components/layout'
import CourseComment from '../components/courseInfo/CourseComment'
import CourseDetail from '../components/courseInfo/CourseDetail'
import CourseHead from '../components/courseInfo/CourseHead'

export default {
    name:"courseInfoPage",
    components:{
        layout,
        CourseComment,
        CourseDetail,
        CourseHead,
    },
    computed:{
        reviewStatistic(){
            let statistic = {   
                    reveiwCnt:0,
                    content:0,
                    teaching:0,
                    grading:0,
                    workload:0
                };
            statistic.reveiwCnt = this.reviews.length;
            for(let i = 0; i < statistic.reveiwCnt; i++){
                statistic.content += +this.reviews[i].courseStatistic.content;
                statistic.teaching += +this.reviews[i].courseStatistic.teaching;
                statistic.grading += +this.reviews[i].courseStatistic.grading;
                statistic.workload += +this.reviews[i].courseStatistic.content;
            }
            statistic.content /= statistic.reveiwCnt;
            statistic.teaching /= statistic.reveiwCnt;
            statistic.grading /= statistic.reveiwCnt;
            statistic.workload /= statistic.reveiwCnt;
            console.log(statistic);
            return statistic;
        },
    },
    data () {
        return {
            text:'',
            logoPath : require("../assets/TJU.png"),
            avatarPath: require("../assets/boy-avatar.png"),
            avatarBGPath: require("../assets/material.png"),
            drawer : false,
            active : -1,
            courseInfo:{
                title:"数据库原理与应用",
                teacher:"袁时金",
                id:"420244",
                section:"2020 春",
                department:"软件学院",
                credit:"4",
                sections:['2017-春', '2017-秋', '2018-春', '2018-秋', '2018-春', '2019-秋', '2019-春' ,'2019-秋' ,'2020-春'],
                syllabus:"Chapter 1: Introduction Chapter 2: Introducation to the Relational Model Chapter 3: Intoduction to SQL Chapter 4: Intermediate SQLChapter 5: Advanced SQL Sections 5.4 onwards omitted. Chapter 6: Other Relational Languages Section 6.1 (Relational Algebra) covered in brief，Sections 6.2 and 6.3 omitted Chapter 7: Entity-Relationship Model  Chapter 8: Relational Database Design  Chapter 9: Application Design and Development  Chapter 10: Storage and File Structure  Sections 10.3, 10.4 and 10.8 omitted Chapter 11: Indexing and Hashing  Cover only Sections 11.1 through 11.3，with a brief outline of Section 11.5 and 11.6 Chapter 12: Query Processing  Cover only Section 12.1 (Overview)  Chapter 14: Transactions  Transaction Concept, Transaction State, Concurrent Executions, Conflict Serializability Introduction to major database products: Oracle",
            },
            userInfo:{
                nickName: "lili",
                eMail:"1888888@tongji.edu.cn",
            },
            reviews:[
            {
                courseStatistic:{
                    content:"10",
                    teaching:"10",
                    grading:"10",
                    workload:"10",
                },userInfro:{
                    nickname:"lutianyi",
                    photoPath:require("../assets/touxiang.jpg"),
                    grade:"2018级",
                    major:"软件工程",
                },courseDetail:{
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
                },commentDetail:{
                    content:"这是我上过的最好的一门课，上课内容有趣，生动丰富，不知道为什么我们学校竟然有这么好的一门课，我收获良多，无论是理论还是应用都让我获益匪浅;",
                    teaching:"袁时金老师的教学水平真的太强啦，上课的时候风趣幽默，讲解知识到位，理论体系完善丰富，极大的开阔了学生们的视野，让我们领会到了世界一流大学一流老师的教学水平，早在高考的时候就久闻袁时金老师的大名，这是我来同济大学的重要原因之一，不然我就去清华了",
                    grading:"这门课太容易了，导致我随随便便就拿了个优",
                    workload:"这门课的作业一点也不多，我一下子就能写完",
                    date:"2020.08.06",
                    useful:230,
                    useless:7
                }
            },{
                courseStatistic:{
                    content:"2",
                    teaching:"0",
                    grading:"0",
                    workload:"2",
                },userInfro:{
                    nickname:"lutianyi",
                    photoPath:require("../assets/touxiang.jpg"),
                    grade:"2018级",
                    major:"软件工程",
                },courseDetail:{
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
                },commentDetail:{
                    content:"这是我上过的最好的一门课，上课内容有趣，生动丰富，不知道为什么我们学校竟然有这么好的一门课，我收获良多，无论是理论还是应用都让我获益匪浅;",
                    teaching:"袁时金老师的教学水平真的太强啦，上课的时候风趣幽默，讲解知识到位，理论体系完善丰富，极大的开阔了学生们的视野，让我们领会到了世界一流大学一流老师的教学水平，早在高考的时候就久闻袁时金老师的大名，这是我来同济大学的重要原因之一，不然我就去清华了",
                    grading:"这门课太容易了，导致我随随便便就拿了个优",
                    workload:"这门课的作业一点也不多，我一下子就能写完",
                    date:"2020.08.06",
                    useful:0,
                    useless:237
                }
            }],
        }
    },
}
</script>

<style>
.course-head{margin-top:15px;}
.body-left{position: fixed; left:15px; top:15px;}
.body-right{position: absolute; right:15px; top:0; padding:0; left:245px; }

.body-right .course-head{margin-top:15px;}
.body-right .course-comment{margin-top:15px;}
.body-right .option-group{margin-top:15px}
</style>