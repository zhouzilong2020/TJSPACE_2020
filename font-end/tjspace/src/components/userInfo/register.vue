<template>
  <q-card class="q-my-md bg-grey-2 my-card col-md-4 col-xs-12">
    <q-card-section>
      <h5 class="title">注册TJSPACE账号</h5>
      <q-form class="q-gutter-md">
        <q-input
          v-model="model.nickname"
          label="昵称:"
          hint="设置你的昵称，最长10位"
          lazy-rules
          :rules="[
            (val) => (val && val.length > 0) || '请输入你的昵称',
            (val) => val.length <= 10 || '昵称长度不能超过10位',
          ]"
        />

        <q-input
          v-model="model.email"
          label="邮箱："
          hint="请输入本人正确的同济邮箱，将作为您的登陆用户名"
          lazy-rules
          :rules="[
            (val) => (val && val.length > 0) || '请输入您的同济邮箱',
            (val) => val.includes('@tongji.edu.cn') || '请输入正确的同济邮箱',
          ]"
        >
          <template v-slot:after>
            <q-btn
              dense
              flat
              color="primary"
              icon="send"
              :label="sentAuthCodeText"
              :disable="authCodeTextisDisabled"
              @click="handleAuthCode()"
            />
          </template>
        </q-input>

        <q-input
          v-model="model.authCode"
          label="邮箱验证码："
          lazy-rules
          :rules="[(val) => (val !== null && val !== '') || '请输入验证码']"
        />

        <q-input
          v-model="model.password"
          :type="isPwd ? 'password' : 'text'"
          label="密码："
          lazy-rules
          :rules="[
            (val) => (val !== null && val !== '') || '密码不能为空',
            (val) => val.length >= 6 || '密码的长度不能少于6位',
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
          lazy-rules
          :rules="[(val) => val === this.model.password || '两次密码不同']"
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
          <q-btn
            class="queren-btn"
            label="注册"
            color="primary"
            @click="handleRegister()"
          />
        </div>
      </q-form>
    </q-card-section>
  </q-card>
</template>

<script>
import { sentAuthCode } from "../../services/userService";
import { mapState } from "vuex";
export default {
  data() {
    return {
      isPwd: true,
      isRPwd: true,
      password: null,
      model: {
        email: null,
        nickname: null,
        authCode: null,
        password: null,
      },
      accept: false,
      sentAuthCodeText: "发送验证码",
      authCodeTextisDisabled: false,
    };
  },

  computed: {
    ...mapState("userInfo", ["token", "userInfo"]),
  },

  methods: {
    handleAuthCode() {
      sentAuthCode({
        email: this.model.username,
      });
    },

    async handleRegister() {
      await this.$store.dispatch("userInfo/registerUser", this.model);

      if (this.token) {
        // 成功获取token 表示成功登录
        // console.log("get user token")
        console.log(this.userInfo);
        this.$router.push({
          name: "Homepage",
          params: {
            userId: this.userInfo.userid,
          },
        });
      } else {
        //密码错误
        this.warning = true;
        setTimeout(() => {
          this.warning = false;
        }, 2000);
      }

      // if (this.token) {
      //   this.$router.push({
      //     name: "Homepage",
      //     params: {
      //       userId: this.userInfo.userid,
      //     },
      //   });
      // }
    },
  },
};
</script>

<style scoped>
.title {
  text-align: center;
}

.queren-btn {
  width: 100%;
}

.my-card {
  max-width: 420px;
}
</style>