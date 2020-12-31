import Vue from 'vue';
import Vuex from 'vuex';
import search from './modules/search';
import auth from './modules/auth';
import user from './modules/user';

Vue.use(Vuex);
const store = new Vuex.Store({
  modules: {
    search,
    auth,
    user,
  },
});

export default store;
