<template>
    <div class="q-pa-md">
      <q-table 
      title="收藏课程"
      :data="CourseData"
      :columns="CourseColumns"
      row-key="CourseName"
      table-style="max-height: 400px"
      virtual-scroll
      :pagination.sync="pagination"
      :rows-per-page-options="[0]"
      />
    </div>
</template>

<script>
export default {
    data () {
    return {
        CourseColumns: [
        {
          name: 'name',
          required: true,
          label: '课程名称',
          align: 'left',
          field: row => row.name,
          format: val => `${val}`,
        },
        { name: 'CourseID', align: 'center', label: '课程序号', field: 'CourseID', sortable: true,sort: (a, b) => parseInt(a, 10) - parseInt(b, 10) },
        { name: 'College', label: '开设学院', field: 'College' },
        { name: 'Semester', label: '开设年级', field: 'Semester' },
        { name: 'Credit', label: '学分', field: 'Credit',sortable: true, sort: (a, b) => parseInt(a, 10) - parseInt(b, 10)},
        { name: 'Teacher', label: '任课老师', field: 'Teacher'},
        ],
      CourseData: [
        {
          name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
        },
        {
          name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
        },
        {
          name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
        },
        {
          name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
        },
        {
          name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
        },
        {
          name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
        },
        {
          name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
        },
        {
          name: '数据库原理与应用',
          CourseID:42024403,
          College:'软件学院',
          Semester:'大二下',
          Credit:'4.0',
          Teacher:'袁时金'
        },
      ],
    }
    }

}
</script>

<style>

</style>