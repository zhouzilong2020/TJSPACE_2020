<template>
  <div class="row justify-center">
    <q-card class="col-md-4 col-xs-6">
      <q-card-section>
        <h5 id="title">注册TJSPACE账号</h5>
        <q-form
          @submit="onSubmit"
          @reset="onReset"
          class="q-gutter-md"
        > 
         <q-input
            v-model="model.nickname"
            label="昵称:"
            hint="设置你的昵称，最长10位"
            lazy-rules
            :rules="[ 
                val => (val && val.length > 0) || '请输入你的昵称',
                val => val.length <= 10 || '昵称长度不能超过10位'
            ]"
         />

         <q-input
            v-model="model.username"
            label="邮箱："
            hint="请输入本人正确的同济邮箱，将作为您的登陆用户名"
            :rules="[
                val => (val && val.length > 0) || '请输入您的同济邮箱',
                val => (val.includes('@tongji.edu.cn')) || '请输入正确的同济邮箱'
            ]"
         >
            <template v-slot:after>
                <q-btn
                  dense 
                  flat
                  color="primary"
                  icon="send" 
                  label="发送验证码" 
                  @click="onClick" 
                />
            </template>
         </q-input>


         <q-input
            v-model="model.authCode"
            label="邮箱验证码："
            lazy-rules
            :rules="[
                val => val !== null && val !== '' || '请输入验证码',
            ]"
         />

         <q-input 
            v-model="model.password" 
            :type="isPwd ? 'password' : 'text'" 
            label="密码："
            :rules="[
                val => (val !== null && val !== '') || '密码不能为空',
                val => val.length >= 6 || '密码的长度不能少于6位',
            ]"
         >
            <template v-slot:append>
                <q-icon
                    :name="isPwd ? 'visibility_off' : 'visibility'"
                    class="cursor-pointer"
                    @click="isPwd = !isPwd"
                />
            </template>
         </q-input>

         <q-input 
            v-model="password" 
            :type="isRPwd ? 'password' : 'text'" 
            label="再次输入密码："
            :rules="[
                val => (val === this.model.password) || '两次密码不同',
            ]"
         >
            <template v-slot:append>
                <q-icon
                    :name="isRPwd ? 'visibility_off' : 'visibility'"
                    class="cursor-pointer"
                    @click="isRPwd = !isRPwd"
                />
            </template>
         </q-input>

         <div>
            <q-btn id="queren-btn" label="注册" type="submit" color="primary"/>
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
      isRPwd: true,
      password: null,
      model: {
        username: null,
        nickname: null,
        authCode: null,
        password: null,
      },

      accept: false
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

    onReset () {
      this.name = null
      this.age = null
      this.accept = false
    }
  }

}
</script>

<style>
#title{
    text-align: center;
}

#queren-btn{
    width: 100%;
}

</style>