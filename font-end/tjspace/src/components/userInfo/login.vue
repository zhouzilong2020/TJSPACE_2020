<template>
  <div class="row justify-center">
    <q-card class="col-md-4 col-xs-6">
      <q-card-section>
        <div class="title">
          <h5>欢迎使用</h5>
          <h5 class="title-name">TJSPACE· 同济大学社群</h5>
        </div>
        <q-form class="q-gutter-md">
          <q-input
            class="email"
            clearable
            clear-icon="close"
            v-model="userInfo.email"
            label="邮箱:"
            suffix="@tongji.edu.cn"
            hint="请输入注册时使用的同济邮箱"
          />

          <q-input
            v-model="userInfo.password"
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
            <q-btn
              :loading="isLoading"
              :disable="isDisabled"
              class="queren-btn"
              label="登录"
              color="primary"
              @click="handleLogin()"
            />
          </div>
          <q-btn-group flat spread>
            <q-btn flat color="primary" label="忘记密码" />
            <q-btn
              flat
              color="primary"
              :to="{ name: 'register' }"
              label="现在注册"
            />
          </q-btn-group>
        </q-form>
      </q-card-section>
    </q-card>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  data() {
    return {
      isPwd: true,
      remember: false,
      userInfo: {
        email: "",
        password: "",
      },
    };
  },
  computed: {
    ...mapState("userInfo", ["isLoading", "token"]),
    isDisabled() {
      if (this.userInfo.email && this.userInfo.password) return false;
      return true;
    },
  },

  methods: {
    async handleLogin() {
      await this.$store.dispatch("userInfo/loginUser", this.userInfo);
      if (this.token) {
        // 成功获取token 表示成功登录
        console.log("asdsa")
        this.$router.push({
          name: "Homepage",
          params: {
            userid: this.token,
          },
        });
      }
    },
  },
};
</script>

<style scoped>
.title {
  text-align: center;
}

.title-name {
  font-weight: bold;
  font-size: 27px;
  line-height: -2;
}

.queren-btn {
  width: 100%;
}
</style>
