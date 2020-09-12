<template>
  <div class="card" style="width:600pt; margin:0 auto; margin-top:50pt">

    <q-card class="my-card" >

      <q-card-section>
        <div class="text-h6">个人信息</div>
      </q-card-section>

      <q-separator />

      <q-card-section>
        
        <div class="text-subtitle2">
          <div class='row items-center'>
            <div class="col-6 justify-evenly" style="text-align: center">昵称</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-input rounded outlined v-model="Nickname" label="Nickname" value="name" style="width:150pt"/></div>
          </div>
        </div>
        
        <div class="text-subtitle2" >
          <div class='row items-center'>
            <div class="col-6 justify-evenly" style="text-align: center">姓名</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-input rounded outlined v-model="Name" :options="Name" label="Name" style="width:150pt"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row items-center'>
            <div class="col-6 justify-evenly" style="text-align: center">学号</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-input rounded outlined v-model="ID" :options="ID" label="ID" style="width:150pt"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row items-center'>
            <div class="col-6 justify-evenly" style="text-align: center">年级</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-select rounded outlined v-model="Grade" :options="OptionGrade" label="Grade" style="width:150pt"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row items-center'>
            <div class="col-6 justify-evenly" style="text-align: center">主修专业</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-select rounded outlined v-model="Major" :options="OptionMajor" label="Major" style="width:150pt" value="OptionMajor"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row items-center'>
            <div class="col-6 justify-evenly" style="text-align: center">辅修专业</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-select rounded outlined v-model="Minor" :options="OptionMinor" label="Minor" style="width:150pt"/></div>
          </div>
        </div>
      
      </q-card-section>
      <q-card-section>
        {{ lorem }}
      </q-card-section>


      <q-separator />

      <div class='row'>
        <q-btn label="Submit" type="submit" color="primary" class='col-6' />
        <q-btn label="Reset" type="reset" color="primary" flat class="q-ml-sm col-5" />
      </div>
      
    </q-card>
    <br>
    <br>
    <br>
    <br>

      
  </div>
</template>




<script>
import Vue from 'vue'
import VueResource from 'vue-resource'
Vue.use(VueResource);
export default {
    name:"SelfInfoModify",
    props:{
        SelfInfo:{
            type: Object,
            default:()=>{
                return {
                    
                }
            }
        }
    },
    data () {
    return {
        Nickname:'lili',
        OptionGrade:['大一','大二','大三','大四','研一','研二','博士'],
        OptionMajor:['软件工程','城市规划','工业设计','土木工程'],
        OptionMinor:['软件工程','城市规划','工业设计','土木工程'],
        Name:'黎力',
        ID:'1853549',
    }
  },





}
</script>


<style scoped>
.text-subtitle2{
  margin-top: 40pt;
}

</style>