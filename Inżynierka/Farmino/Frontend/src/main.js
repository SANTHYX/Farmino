import Vue from 'vue';
import Vuelidate from 'vuelidate';
import Unicons from 'vue-unicons';
import {
  uniInfoCircle,
  uniEnvelope,
  uniAngleDown,
  uniEdit,
  uniPlusCircle,
  uniMapMarkerInfo,
  uniSearch,
  uniDropbox,
  uniBookReader,
  uniMoneyBillSlash,
} from 'vue-unicons/src/icons';
import App from './App.vue';
import router from './router';
import store from './store/store';

Unicons.add([
  uniInfoCircle,
  uniEnvelope,
  uniAngleDown,
  uniEdit,
  uniPlusCircle,
  uniMapMarkerInfo,
  uniSearch,
  uniDropbox,
  uniBookReader,
  uniMoneyBillSlash,
]);
Vue.use(Vuelidate);
Vue.use(Unicons);
Vue.config.productionTip = false;

new Vue({
  store,
  router,
  render: (h) => h(App),
}).$mount('#app');
