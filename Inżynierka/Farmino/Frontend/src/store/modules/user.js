import api from '../../plugins/axios';

const user = {
  namespaced: true,
  state: {
    user: {},
    token: '',
    isLogged: false,
  },
  getters: {
    isLogged(state) {
      return state.isLogged;
    },
  },
  mutations: {
    async LoginUser(state, { login, password }) {
      try {
        const loginResponse = await api.post('/auth/login', { login, password });
        const getUser = await api.get(`/users/${login}`);
        state.token = loginResponse.data.token;
        state.user = getUser.data;
        state.isLogged = true;
      } catch (err) {
        console.log(err);
      }
    },
  },
  actions: {
    LogUser({ commit }, { login, password }) {
      commit('LoginUser', { login, password });
    },
  },
};

export default user;
