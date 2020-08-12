<template>
   <q-card bordered flat class="course-detail-head row">

        <!-- 课程信息   -->
        <q-card-section  class="course-detail-head-overall">
            <div class="text-h6">{{courseInfo.title}}</div>
            <q-badge class="text-subtitle1" color="marine" multi-line>{{courseInfo.credit}}学分</q-badge>
            <div class="text-subtitle2">{{courseInfo.teacher}}</div>
            <div class="text-subtitle2">{{courseInfo.section}}</div>
        </q-card-section>
        
        <q-separator vertical />

        <!-- 按钮组 收藏，喜欢，分享等功能 -->
        <q-card-actions q-card-actions vertical class="option justify-start q-px-md">
            <q-btn flat round color="red" icon="favorite" />
            <q-btn flat round color="accent" icon="bookmark" />
            <q-btn flat round color="primary" icon="share" />
        </q-card-actions>

        <q-separator  />

        <!-- 课程大纲 -->
        <q-card-section  class="syllabus">
            <div class="text-h6">课程大纲</div>
            <div class="text-subtitle2">
                {{courseInfo.syllabus}}
            </div>
        </q-card-section>
    </q-card>
</template>

<script>
export default {
    props:{
        courseInfo:{
            type: Object,
            default:()=> {
                return {
                    title: "数据库原理与应用",
                    teacher:"袁时金",
                    credit:"4",
                    section:"2005-秋 2006-春 2006-秋 2007-春 2007-秋 2008-春 2008-秋 2009-春 2009-秋 2010-春 2010-秋 2011-春 2011-秋 2012-春 2012-秋 2013-春 2013-秋 2014-春 2014-秋 2015-春 2015-秋 2016-春 2016-秋 2017-春 2017-秋 2018-春 2018-秋 2018-春 2019-秋 2019-春 2019-秋 2020-春",
                    syllabus:"Chapter 1: Introduction Chapter 2: Introducation to the Relational Model Chapter 3: Intoduction to SQL Chapter 4: Intermediate SQLChapter 5: Advanced SQL Sections 5.4 onwards omitted. Chapter 6: Other Relational Languages Section 6.1 (Relational Algebra) covered in brief，Sections 6.2 and 6.3 omitted Chapter 7: Entity-Relationship Model  Chapter 8: Relational Database Design  Chapter 9: Application Design and Development  Chapter 10: Storage and File Structure  Sections 10.3, 10.4 and 10.8 omitted Chapter 11: Indexing and Hashing  Cover only Sections 11.1 through 11.3，with a brief outline of Section 11.5 and 11.6 Chapter 12: Query Processing  Cover only Section 12.1 (Overview)  Chapter 14: Transactions  Transaction Concept, Transaction State, Concurrent Executions, Conflict Serializability Introduction to major database products: Oracle",
                }
            }
        }
    }

}
</script>

<style>
.course-detail-head .option{padding:0px;margin:auto auto;}
.course-detail-head .syllabus{margin:0 auto;}
.course-detail-head .course-detail-head-overall{width:90%}
</style>