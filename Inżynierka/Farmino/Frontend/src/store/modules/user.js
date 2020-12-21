import userService from '@/service/userService';

const user = {
  namespaced: true,
  state: {
    user: {},
    token: '',
  },
  mutations: {
    CLEAR_STATE: (state) => {
      state.user = {};
    },
    SET_USER: (state, userObj) => {
      state.user.login = userObj.login;
      state.user.email = userObj.email;
    },
    SET_ADDRESS: (state, addressObj) => {
      state.user.profile.address = addressObj;
    },
    SET_PROFILE: (state, profileObj) => {
      state.user.profile = profileObj;
    },
    SET_TOKEN: (state, tokenModel) => {
      state.token = tokenModel;
    },
  },
  actions: {
    REGISTER: async ({ login, password, email }) => {
      await userService.register({ login, password, email });
    },
    LOGIN: async ({ commit }, { login, password }) => {
      const { token, userObj } = await userService.login({ login, password });
      commit('SET_TOKEN', token);
      commit('SET_USER', userObj);
    },
  },
};

export default user;
