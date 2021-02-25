import Vue from 'vue';
import Vuex from 'vuex';
import auth from './modules/auth';
import user from './modules/user';
import order from './modules/order';
import offer from './modules/offer';
import auction from './modules/auction';
import direction from './modules/direction';

Vue.use(Vuex);
const store = new Vuex.Store({
  modules: {
    direction,
    offer,
    auction,
    order,
    auth,
    user,
  },
});

export default store;
