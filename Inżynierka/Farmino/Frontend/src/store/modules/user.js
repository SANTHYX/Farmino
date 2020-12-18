import api from '@/plugins/axios';

const user = {
  namespaced: true,
  state: {
    user: {},
  },
  mutations: {
    async REGISTER({ login, password, email }) {
      try {
        await api.post('/users', { login, password, email });
      } catch (error) {
        console.log(error.message);
      }
    },
    async LOGIN(state, { login, password }) {
      try {
        await api.post('/signin', { login, password });
        state.user = await api.get(`/user/${login}`).data;
      } catch (error) {
        console.log(error.message);
      }
    },
    LOGOUT(state) {
      state.user = {};
    },
  },
  actions: {
    async REGISTER({ commit }, { login, password, email }) {
      commit('REGISTER', { login, password, email });
    },
    async LOGIN({ commit }, { login, password }) {
      commit('LOGIN', { login, password });
    },
  },
};

export default user;
