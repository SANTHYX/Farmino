import Vue from 'vue';
import Vuelidate from 'vuelidate';
import VueMoment from 'vue-moment';
import Unicons from 'vue-unicons';
import {
  uniInfoCircle,
  uniEnvelope,
  uniAngleDown,
  uniEdit,
  uniPlusCircle,
} from 'vue-unicons/src/icons';
import App from './App.vue';
import router from './router';
import store from './store/store';

Unicons.add([uniInfoCircle, uniEnvelope, uniAngleDown, uniEdit, uniPlusCircle]);
Vue.use(Vuelidate);
Vue.use(Unicons);
Vue.use(VueMoment);
Vue.config.productionTip = false;

new Vue({
  store,
  router,
  render: (h) => h(App),
}).$mount('#app');
