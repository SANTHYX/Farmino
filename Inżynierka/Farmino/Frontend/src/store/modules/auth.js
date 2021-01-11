import api from '@/plugins/axios';
import localStorageManager from '@/plugins/localStorageManager';

const auth = {
  namespaced: true,

  state: {
    userName: localStorageManager.getUserName(),
    expiresAt: localStorageManager.getExpiresAt(),
    isAuthorized: localStorageManager.isAuthorized(),
  },

  getters: {
    IS_AUTHORIZED(state) {
      return state.isAuthorized;
    },
    GET_USERNAME(state) {
      return state.userName;
    },
  },

  mutations: {
    SET_AUTHORIZATION(state, boolean) {
      state.isAuthorized = boolean;
    },
    SET_USERNAME(state, userName) {
      state.userName = userName;
    },
    CLEAR_STORE(state) {
      state.userName = '';
      state.isAuthorized = false;
      state.userName = '';
    },
  },

  actions: {
    async LOGIN({ commit }, { userName, password }) {
      try {
        const response = await api.post('/auth/login', { userName, password });
        localStorageManager.storeTokens(
          response.data.token,
          response.data.refresh,
          response.data.expiresAt,
          userName,
        );
        commit('SET_USERNAME', userName);
        commit('SET_AUTHORIZATION', true);
      } catch (err) {
        throw new Error(err);
      }
    },
    async LOGOUT({ commit }) {
      commit('CLEAR_STORE');
      try {
        const refresh = localStorageManager.getRefresh();
        await api.post('/auth/revoke', { refresh });
        localStorageManager.clearStorage();
      } catch (err) {
        throw new Error(err);
      }
    },
  },
};

export default auth;
