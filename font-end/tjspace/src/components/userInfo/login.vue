<template>
  <div class="row justify-center">
    <q-card class="col-md-3 col-xs-12">
      <q-card-section>
        <div id="title">
          <h5>欢迎使用</h5>
          <h5 id="title-name"> TJSPACE· 同济大学社群</h5>
        </div>
        <q-form
          @submit="onSubmit"
          class="q-gutter-md"
        >
          <q-input 
            id="email"
            clearable
            clear-icon="close"
            v-model="model.username" 
            label="邮箱:"
            type="email" 
            suffix="@tongji.edu.cn"
            hint="请输入注册时使用的同济邮箱" 
          />
           
          <q-input 
            v-model="model.password" 
            label="密码:"
            :type="isPwd ? 'password' : 'text'" 
          >
            <template v-slot:append>
              <q-icon
                :name="isPwd ? 'visibility_off' : 'visibility'"
                class="cursor-pointer"
                @click="isPwd = !isPwd"
              />
            </template>
          </q-input>

          <q-toggle v-model="remember" label="记住邮箱" />

          <div>
            <q-btn id="queren-btn" label="登录" type="submit" color="primary"/>
          </div>
          <div>
            <a id=“forget”>忘记密码</a>
            <a id="register">马上注册</a>
          </div>
        </q-form>
      </q-card-section>
    </q-card>
  </div>
</template>



<script>
export default {
  data () {
    return {
      isPwd: true,
      remember: false,
      model:{
        username: '',
        password: '',
      }
    }
  },

  methods: {    
    onSubmit () {
      if (this.accept !== true) {
        this.$q.notify({
          color: 'red-5',
          textColor: 'white',
          icon: 'warning',
          message: 'You need to accept the license and terms first'
        })
      }
      else {
        this.$q.notify({
          color: 'green-4',
          textColor: 'white',
          icon: 'cloud_done',
          message: 'Submitted'
        })
      }
    },
  }
}
</script>


<style>
#title{
  text-align: center;
}

#title-name{
  font-weight: bold;
  font-size: 27px;
  line-height: -2;
}

#queren-btn{
  width: 100%;
}

#register{
  float: right;
}

/* #email{
  width: 90%;

} */

</style>