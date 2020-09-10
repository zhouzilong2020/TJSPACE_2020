<template>
  <div>
    <img :src="bgPath" alt="" />
    <div class="container justify-center row">
      <index-rotate-card class="index-card col-7" />
      <login class="login-card" />
    </div>
  </div>
</template>

<script>
import login from "../components/userInfo/login";
import indexRotateCard from "../components/indexRotateCard";

export default {
  components: {
    login,
    indexRotateCard,
  },

  data() {
    return {
      bgPath: require("../assets/school.jpeg"),
    };
  },
};
</script>

<style scoped>
img {
  position: fixed;
  height: 100%;
  width: 100%;
  margin-top: -120px;
  padding: 0;
  z-index: -1;
}

.container {
  margin-top: 100px;
}
.index-card {
  opacity: 0.9;
  /* height: 520px; */
  /* margin-left: px; */
}
.login-card {
  opacity: 0.9;
  /* height: 520px; */
}
</style>