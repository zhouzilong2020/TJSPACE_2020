import Vue from 'vue'
import App from './App.vue'
import './quasar'

Vue.config.productionTip = false

// import { 
//   Quasar,
//   QBanner
// } from 'quasar'

// Vue.use(Quasar, {
//   components: {
//     QBanner
//   }
// })


new Vue({
  render: h => h(App),
}).$mount('#app')
