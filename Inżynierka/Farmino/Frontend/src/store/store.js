import Vue from 'vue';
import Vuex from 'vuex';
import search from './modules/search';
import auth from './modules/auth';
import user from './modules/user';
import offer from './modules/offer';

Vue.use(Vuex);
const store = new Vuex.Store({
  modules: {
    offer,
    search,
    auth,
    user,
  },
});

export default store;
