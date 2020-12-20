import api from '@/plugins/axios';

const user = {
  namespaced: true,
  state: {
    user: {},
  },
  mutations: {
    REGISTER(state, { login, email, password }) {
      try {
        api.post('/users', { login, email, password });
      } catch (error) {
        console.log(error.message);
      }
    },
    LOGIN(state, { login, password }) {
      try {
        const response = api.post('/auth/login/', { login, password });
        console.log(response.data);
      } catch (error) {
        console.log(error.message);
      }
    },
    CREATE_PROFILE(state, { firstName, lastName, phoneNumber }) {
      try {
        api.post('/profiles', {
          login: state.user.login,
          firstName,
          lastName,
          phoneNumber,
        });
        state.user.profile = {
          firstName,
          lastName,
          phoneNumber,
        };
      } catch (error) {
        console.log(error.message);
      }
    },
    EDIT_PROFILE(state, { firstName, lastName, phoneNumber }) {
      try {
        api.put('/profiles', {
          login: state.user.login,
          firstName,
          lastName,
          phoneNumber,
        });
        state.user.profile = {
          firstName,
          lastName,
          phoneNumber,
        };
      } catch (error) {
        console.log(error.message);
      }
    },
    ADD_ADDRESS(state, { city, street, postalCode, houseNumber }) {
      try {
        api.post('/address', {
          login: state.user.login,
          city,
          street,
          postalCode,
          houseNumber,
        });
        state.user.profile.address = {
          city,
          street,
          postalCode,
          houseNumber,
        };
      } catch (error) {
        console.log(error.message);
      }
    },
    EDIT_ADDRESS(state, { city, street, postalCode, houseNumber }) {
      try {
        api.put('/address', {
          login: state.user.login,
          city,
          street,
          postalCode,
          houseNumber,
        });
        state.user.profile.address = {
          city,
          street,
          postalCode,
          houseNumber,
        };
      } catch (error) {
        console.log(error.message);
      }
    },
    LOGOUT(state) {
      state.user = {};
    },
  },
  actions: {
    async REGISTER({ commit }, { login, email, password }) {
      await commit('REGISTER', { login, email, password });
    },
    LOGIN({ commit }, { login, password }) {
      commit('LOGIN', { login, password });
    },
    CREATE_PROFILE({ commit }, { firstName, lastName, phoneNumber }) {
      commit('CREATE_PROFILE', { firstName, lastName, phoneNumber });
    },
    EDIT_PROFILE({ commit }, { firstName, lastName, phoneNumber }) {
      commit('EDIT_PROFILE', { firstName, lastName, phoneNumber });
    },
    ADD_ADDRESS({ commit }, { city, street, postalCode, houseNumber }) {
      commit('ADD_ADDRESS', {
        city,
        street,
        postalCode,
        houseNumber,
      });
    },
    EDIT_ADDRESS({ commit }, { city, street, postalCode, houseNumber }) {
      commit('EDIT_ADDRESS', {
        city,
        street,
        postalCode,
        houseNumber,
      });
    },
  },
};

export default user;
