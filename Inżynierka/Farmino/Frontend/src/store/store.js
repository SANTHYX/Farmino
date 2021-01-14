import Vue from 'vue';
import Vuex from 'vuex';
import search from './modules/search';
import auth from './modules/auth';
import user from './modules/user';
import order from './modules/order';
import offer from './modules/offer';
import auction from './modules/auction';

Vue.use(Vuex);
const store = new Vuex.Store({
  modules: {
    offer,
    auction,
    order,
    search,
    auth,
    user,
  },
});

export default store;
