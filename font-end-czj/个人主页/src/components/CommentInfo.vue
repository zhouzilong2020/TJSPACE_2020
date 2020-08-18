<template>
    <div class="q-pa-md" >
      <q-table 
      title="历史评价"
      :data="CommentData"
      :columns="CommentColumns"
      row-key="CommentID"
      table-style="max-height: 400px"
      selection="single"
      :selected.sync="selected"
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
        selected: [],
        CommentColumns: [
        {
          name: 'name',
          required: true,
          label: '评价课程',
          align: 'left',
          field: row => row.name,
          format: val => `${val}`
        },
        { name: 'CommentID', align: 'center', label: '评价序号', field: 'CommentID', sortable: true,sort: (a, b) => parseInt(a, 10) - parseInt(b, 10) },
        { name: 'Like', label: '点赞数', field: 'Like' , sortable: true,sort: (a, b) => parseInt(a, 10) - parseInt(b, 10)},
        { name: 'Reply', label: '回复数', field: 'Reply',sortable: true, sort: (a, b) => parseInt(a, 10) - parseInt(b, 10)},
        { name: 'Time', label: '评价时间', field: 'Time'},
        ],
      CommentData: [
        {
          name: '数据库原理与应用',
          CommentID:1000000,
          Like:100,
          Reply:5,
          Time:'2020.8.31'
        },
        {
          name: '数据库原理与应用',
          CommentID:1000001,
          Like:100,
          Reply:5,
          Time:'2020.8.31'
        },
        {
          name: '数据库原理与应用',
          CommentID:1000001,
          Like:100,
          Reply:5,
          Time:'2020.8.31'
        },
        {
          name: '数据库原理与应用',
          CommentID:1000001,
          Like:100,
          Reply:5,
          Time:'2020.8.31'
        },
        {
          name: '数据库原理与应用',
          CommentID:1000001,
          Like:100,
          Reply:5,
          Time:'2020.8.31'
        },
        {
          name: '数据库原理与应用',
          CommentID:1000001,
          Like:100,
          Reply:5,
          Time:'2020.8.31'
        },
      ],
    }
    },

}
</script>

<style>

</style>