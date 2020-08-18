<template>
  <div class="card" style="width:800pt">
    <div class="text-h5">个人信息</div>

    <q-card class="my-card">
      <q-card-section>
        
        <div class="text-subtitle2">
          <div class='row'>
            <div class="col-4 items-center">昵称</div>
            <div class="col-4 items-center"><q-input rounded outlined v-model="Nickname" label="Nickname" value="name" style="width:150pt"/></div>
          </div>
        </div>
        
        <div class="text-subtitle2" >
          <div class='row'>
            <div class="col-4 items-center">姓名</div>
            <div class="col-4 items-center"><q-input rounded outlined v-model="Name" :options="Name" label="Name" style="width:150pt"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row'>
            <div class="col-4 items-center">学号</div>
            <div class="col-4 items-center"><q-input rounded outlined v-model="ID" :options="ID" label="ID" style="width:150pt"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row'>
            <div class="col-4 items-center">年级</div>
            <div class="col-4 items-center"><q-select rounded outlined v-model="Grade" :options="OptionGrade" label="Grade" style="width:150pt"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row'>
            <div class="col-4 items-center">主修专业</div>
            <div class="col-4 items-center"><q-select rounded outlined v-model="Major" :options="OptionMajor" label="Major" style="width:150pt"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row'>
            <div class="col-4 items-center">辅修专业</div>
            <div class="col-4 items-center"><q-select rounded outlined v-model="Minor" :options="OptionMinor" label="Minor" style="width:150pt"/></div>
          </div>
        </div>
      
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
  }

}
</script>

<style>
.card{
  margin-top: 50pt;
  margin-left: 200pt;
  height: 400pt;
}
.text-subtitle2{
  margin-top: 40pt;
  margin-left: 200pt;
}
.Information{
  display: inline-block;
}

</style>