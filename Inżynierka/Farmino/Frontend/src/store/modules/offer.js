import api from '@/plugins/axios';

const offer = {
  namespaced: true,

  state: {
    offer: {},
    offersAll: [],
  },

  getters: {},

  mutations: {
    SET_DESCRIPTION(state, description) {
      state.offer.description = description;
    },
    SET_TITLE(state, title) {
      state.offer.title = title;
    },
    SET_OFFER(state, offerObj) {
      state.offer = offerObj;
    },
    SET_OFFERS(state, offersList) {
      state.offersAll = offersList;
    },
  },

  actions: {
    async CREATE_FARMER({ commit }, { userName }) {
      try {
        await api.post('/farmers', { userName });
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CREATE_OFFER({ commit }, {
      userName, title, description, product,
    }) {
      try {
        await api.post('/offers', {
          userName,
          title,
          description,
          product,
        });
        commit('SET_OFFER', {
          title,
          description,
          product,
        });
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
  async GET_OFFER({ commit }, offerId) {
    try {
      const response = await api.get(`/offers/${offerId}`);
      commit('SET_OFFER', response.data);
    } catch (err) {
      throw new Error(err.message);
    }
  },
  async GET_OFFERS({ commit }) {
    try {
      const response = await api.get('/offers');
      commit('SET_OFFERS', response.data);
    } catch (err) {
      throw new Error(err.message);
    }
  },
};

export default offer;
