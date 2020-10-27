import Vue from 'vue';
import Vuelidate from 'vuelidate';
import axios from 'axios';
import App from './App.vue';
import router from './router';
import store from './store/store';

Vue.use(Vuelidate);
Vue.config.productionTip = false;

new Vue({
  store,
  router,
  render: (h) => h(App),
}).$mount('#app');
