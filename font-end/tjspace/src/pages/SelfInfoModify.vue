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
            <div class="col-6 justify-evenly" style="text-align: center"><q-input rounded outlined v-model="Nickname" label="Nickname" value="Nickname" style="width:150pt"/></div>
          </div>
        </div>
        
        <div class="text-subtitle2" >
          <div class='row items-center'>
            <div class="col-6 justify-evenly" style="text-align: center">性别</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-select rounded outlined v-model="Gender" :options="OptionGender" label="Gender" style="width:150pt"/></div>
          </div>
        </div>

        <div class="text-subtitle2" >
          <div class='row items-center'>
            <div class="col-6 justify-evenly" style="text-align: center">手机号</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-input rounded outlined v-model="phoneNumber" :options="phoneNumber" label="phoneNumber" style="width:150pt"/></div>
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
            <div class="col-6 justify-evenly" style="text-align: center">学历</div>
            <div class="col-6 justify-evenly" style="text-align: center"><q-select rounded outlined v-model="Degree" :options="OptionDegree" label="Degree" style="width:150pt"/></div>
          </div>
        </div>
      
      </q-card-section>

      <q-separator />

      <div class='row'>
        <q-btn label="Submit"  color="primary" class='col-6' @click='submit()'  />
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
import {mapState} from 'vuex'
import { token  } from '../services/config'
// import axios from 'axios'
export default {
    components:{
    },
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
        OptionGender:['男','女'],
        OptionGrade:['大一','大二','大三','大四','研一','研二','博士'],
        OptionMajor:['软件工程','土木工程','经济与管理'],
        OptionDegree:['本科生','研究生','博士生'],
        Nickname:'',
        Gender:'',
        phoneNumber:'',
        Grade:'',
        Major:'',
        Degree:'',
        information:{
          userId:'',
          nickname:'',
          gender:'',
          phoneNumber:'',
          majorId:'',
          year:'',
          degree:'',
        }
    }
  },
  methods:{
    submit(){
      console.log('token：',token)
      this.getInfo()
      this.changeInfo()
      console.log('in selfinfo',this.information)
      alert('Information Modified!')
    },
    getInfo(){
      this.information.userId = this.userInfo.userid
      this.information.nickname=this.Nickname
      switch(this.Gender)
      {
        case '男': 
          this.information.gender=0;
          break;
        case '女': 
          this.information.gender=1;
          break;
      }
      this.information.phoneNumber=this.phoneNumber
      switch(this.Major)
      {
        case '软件工程':
          this.information.majorId='1';
          break;
        case '土木工程':
          this.information.majorId='2';
          break;
        case '经济与管理':
          this.information.majorId='3';
          break;
      }
      switch(this.Grade)
      {
        case '大一':
          this.information.year=1;
          break;
        case '大二':
          this.information.year=2;
          break;
        case '大三':
          this.information.year=3;
          break;
        case '大四':
          this.information.year=4;
          break;
      }
      switch(this.Degree)
      {
        case '本科生':
          this.information.degree=1;
          break;
        case '研究生':
          this.information.degree=2;
          break;
        case '博士生':
          this.information.degree=3;
          break;

      }
    },
    async changeInfo() {
      await this.$store.dispatch("infoModify/infoModify", this.information);
    },
    // async changeInfo() {
    //     let res = await axios.put("http://175.24.115.240:8080/api/Modify/Info", {
    //         headers: {
    //           Authorization: token,
    //         },
    //         params: {
    //            userId:this.information.userId,
    //            nickname:this.information.nickname,
    //            gender:this.information.gender,
    //            phoneNumber:this.information.phoneNumber,
    //            majorId:this.information.majorId,
    //            year:this.information.year,
    //            degree:this.information.degree,
    //         }
    //     })
    //     this.researchList = res.data.retData.list
    // },
  },
  computed:mapState('userInfo', ['userInfo']),
  created(){
    this.Nickname=this.userInfo.nickname
    switch(this.userInfo.gender)
    {
      case 0: 
        this.Gender='男';
        break;
      case 1: 
        this.Gender='女';
        break;
    }
    this.phoneNumber=this.userInfo.phonenumber
    switch(this.userInfo.majorid)
    {
      case '1': 
        this.Major='软件工程';
        break;
      case '2': 
        this.Major='土木工程';
        break;
      case '3': 
        this.Major='经济与管理';
        break;
    }
    switch(this.userInfo.year)
    {
      case 1: 
        this.Grade='大一';
        break;
      case 2: 
        this.Grade='大二';
        break;
      case 3: 
        this.Grade='大三';
        break;
      case 4: 
        this.Grade='大四';
        break;
    }
    switch(this.userInfo.degree)
    {
      case 1: 
        this.Degree='本科生';
        break;
      case 2: 
        this.Degree='研究生';
        break;
      case 3: 
        this.Degreer='博士生';
        break;
    }

    

  },




}
</script>


<style >
.text-subtitle2{
  margin-top: 40pt;
}

</style>