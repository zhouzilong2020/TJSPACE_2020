<template>
  <div>
    <img :src="bgPath" alt="" />
    <div class="container justify-center row">
      <indexCard class="index-card col-md-8" />
      <login class="login-card col-md-4" />
    </div>
  </div>
</template>

<script>
import login from "../components/userInfo/login";
import indexCard from "../components/indexCard";

export default {
  components: {
    login,
    indexCard,
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
}

.container {
  margin-top: 100px;
}
.index-card {
  max-width: 800px;
  height: 520px;
  /* margin-left: px; */
}
.login-card {
  height: 520px;
  margin-left: 40px;
}
</style>