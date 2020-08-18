<template>
    <q-card elevated class="course-detail">
      <img :src="path" style="width:50px">

      <q-card-section horizontal>
        <q-list>
            <q-item>
            <q-item-section avatar>
                <q-icon color="primary" name="local_library" />
            </q-item-section>
            <q-item-section>
                <q-item-label>课程名称</q-item-label>
                <q-item-label caption>{{courseInfo.title}}</q-item-label>
            </q-item-section>
            </q-item>

            <q-item >
            <q-item-section avatar>
                <q-icon color="red" name="people" />
            </q-item-section>

            <q-item-section>
                <q-item-label>授课教师</q-item-label>
                <q-item-label caption>{{courseInfo.teacher}}</q-item-label>
            </q-item-section>
            </q-item>

            <q-item >
            <q-item-section avatar>
                <q-icon color="amber" name="near_me" />
            </q-item-section>

            <q-item-section>
                <q-item-label>课程编号</q-item-label>
                <q-item-label caption>{{courseInfo.id}}</q-item-label>
            </q-item-section>
            </q-item>

            <q-item >
            <q-item-section avatar>
                <q-icon color="green" name="today" />
            </q-item-section>

            <q-item-section>
                <q-item-label>开课时间</q-item-label>
                <q-item-label caption>{{courseInfo.section}}</q-item-label>
            </q-item-section>
            </q-item>

            <q-item >
            <q-item-section avatar>
                <q-icon color="grey" name="place" />
            </q-item-section>
            <q-item-section>
                <q-item-label>上课地点</q-item-label>
                <q-item-label caption>{{courseInfo.building}}</q-item-label>
            </q-item-section>
            </q-item>
        </q-list>
      </q-card-section>

      <q-card-section>
        <course-statistic />
      </q-card-section>






    </q-card>
</template>

<script>

export default {
    
    props:{
        courseInfo:{
            type: Object,
            default:()=>{
                return {
                    title:"数据库原理与应用",
                    teacher:"袁时金",
                    id:"420244",
                    section:"周一 1-2节 周三 1-2节",
                    building:"嘉定 B101",
                }
            }
        }
    },
    data(){
        return {
            path: require("../assets/TJU.png")
        }
    }

}
</script>

<style>

</style>