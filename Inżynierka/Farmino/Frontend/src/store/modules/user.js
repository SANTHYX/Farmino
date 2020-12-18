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
        await api.post('/login', { login, password });
        state.user = await api.get(`/user/${login}`).data;
      } catch (error) {
        console.log(error.message);
      }
    },
    async CREATE_PROFILE(state, { firstName, lastName, phoneNumber }) {},
    async EDIT_PROFILE(state, { firstName, lastName, phoneNumber }) {},
    async ADD_ADDRESS(state, { city, street, postalCode, houseNumber }) {},
    async EDIT_ADDRESS(state, { city, street, postalCode, houseNumber }) {},
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
