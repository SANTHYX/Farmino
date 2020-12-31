import api from '@/plugins/axios';

const user = {
  namespaced: true,

  state: {
    user: {},
  },

  getters: {
    GET_USER(state) {
      return state.user;
    },
  },

  mutations: {
    SET_USER(state, userObj) {
      state.user = userObj;
    },

    SET_PROFILE(state, profileObj) {
      state.user.profile = profileObj;
    },
  },
  actions: {
    async GET_USER({ commit }, userName) {
      try {
        const response = await api.get(`/users/${userName}`);
        commit('SET_USER', response.data);
      } catch (err) {
        console.log(err);
      }
    },
    async CREATE_PROFILE({ commit }, {
      userName, firstName, lastName, phoneNumber,
    }) {
      try {
        await api.post('/profiles', {
          userName,
          firstName,
          lastName,
          phoneNumber,
        });
        commit('SET_PROFILE', { firstName, lastName, phoneNumber });
      } catch (err) {
        throw new Error(err);
      }
    },
    async EDIT_PROFILE({ commit }, {
      userName, firstName, lastName, phoneNumber,
    }) {
      try {
        await api.put('/profiles', {
          userName,
          firstName,
          lastName,
          phoneNumber,
        });
        commit('SET_PROFILE', { firstName, lastName, phoneNumber });
      } catch (err) {
        throw new Error(err);
      }
    },
  },
};

export default user;
