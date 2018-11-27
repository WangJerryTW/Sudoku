import Vue from 'vue'
//import './plugins/axios'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from 'axios'
import VueAxios from 'vue-axios'

import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './assets/main.css';

Vue.use(VueAxios, axios)
axios.defaults.baseURL = 'https://api.pureday.life'
axios.defaults.withCredentials=true

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
