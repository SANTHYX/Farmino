import { api } from '@/plugins/axios';

const user = {
  namespaced: true,

  state: {
    user: {
      profile: null,
    },
  },

  getters: {
    GET_STATE_USER(state) {
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

    SET_ADDRESS(state, addressObj) {
      state.user.profile.address = addressObj;
    },
    CLEAR_STATE(state) {
      state.user = {};
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

    async CREATE_ADDRESS({ commit }, {
      userName, city, street, postalCode, houseNumber,
    }) {
      try {
        await api.post('/address', {
          userName,
          city,
          street,
          postalCode,
          houseNumber,
        });
        commit('SET_ADDRESS', {
          city,
          street,
          postalCode,
          houseNumber,
        });
      } catch (err) {
        console.log(err);
      }
    },

    async UPDATE_ADDRESS({ commit }, {
      userName, city, street, postalCode, houseNumber,
    }) {
      try {
        await api.put('/address', {
          userName,
          city,
          street,
          postalCode,
          houseNumber,
        });
        commit('SET_ADDRESS', {
          city,
          street,
          postalCode,
          houseNumber,
        });
      } catch (err) {
        console.log(err);
      }
    },
  },
};

export default user;
