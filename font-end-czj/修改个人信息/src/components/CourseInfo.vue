<template>
  <div class="course-info">
	  <q-card dark bordered class="bg-grey-9 my-card">
      <q-card-section>
        <div class="text-h6">课程内容</div>
        <div class="text-subtitle2">by {{author}}</div>
      </q-card-section>
      <q-separator dark inset />
      <q-card-section>
        <ol>
            <li class="text"></li>
            <li></li>
        </ol>
      </q-card-section>
    </q-card>

    <q-card flat bordered class="my-card">
      <q-card-section>
        <div class="text-h6">Our Changing Planet</div>
      </q-card-section>
      <q-card-section class="q-pt-none">
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua.
      </q-card-section>
      <q-separator inset />
      <q-card-section>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua.
      </q-card-section>
    </q-card>

    
	</div>
</template>

<script>
export default {
    name:"CourseInfo",
    props:{
       
    },
    computed: {
       
    }
}
</script>

<style>



</style>