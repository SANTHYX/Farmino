import { api } from '../../plugins/axios';

const offer = {
  namespaced: true,

  state: {
    offer: {},
    offersAll: [],
    order: {},
  },

  getters: {
    GET_OFFERS_ALL(state) {
      return state.offersAll;
    },

    GET_OFFER(state) {
      return state.offer;
    },

    GET_MIN_QUANTITY(state) {
      return state.offer.minQuantity;
    },

    GET_ORDER(state) {
      return state.order;
    },
  },

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

    SET_ORDER_QUANTITY(state, orderQuantity) {
      state.order.orderQuantity = orderQuantity;
    },

    SET_CUSTOM_ADDRESS(state, customAddress) {
      state.order.customAddress = customAddress;
    },

    SET_CUSTOM_ORDER_DETAILS(state, orderDetails) {
      state.order.orderDetails = orderDetails;
    },
  },

  actions: {
    async GET_OFFER({ commit }, offerId) {
      try {
        const response = await api.get(`/offers/${offerId}`);
        commit('SET_OFFER', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async BROWSE_OFFERS({ commit }, { phrase, priceFrom, priceTo }) {
      try {
        const response = await api.get('/offers', {
          params: {
            phrase,
            priceFrom,
            priceTo,
          },
        });
        commit('SET_OFFERS', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CREATE_FARMER({ commit }, { userName }) {
      try {
        await api.post('/farmers', { userName });
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CREATE_CUSTOMER({ commit }, { userName }) {
      try {
        await api.post('/customers', { userName });
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CREATE_OFFER({ commit }, {
      userName, title, description, minQuantity, product,
    }) {
      try {
        await api.post('/offers', {
          userName,
          title,
          description,
          minQuantity,
          product,
        });
        commit('SET_OFFER', {
          title,
          description,
          minQuantity,
          product,
        });
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async MAKE_ORDER(
      { commit },
      {
        offerId, customerName, orderQuantity, customAddress, orderDetails = null,
      },
    ) {
      try {
        await api.post('/offers/make-order', {
          offerId,
          customerName,
          orderQuantity,
          customAddress,
          orderDetails,
        });
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
};

export default offer;
