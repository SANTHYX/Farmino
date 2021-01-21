import { api } from '@/plugins/axios';

const order = {
  namespaced: true,

  state: {
    order: {},
    ordersAll: [],
  },

  getters: {
    GET_ORDER(state) {
      return state.order;
    },

    GET_ORDERS(state) {
      return state.ordersAll;
    },
  },

  mutations: {
    SET_ORDER(state, orderObj) {
      state.order = orderObj;
    },

    SET_ORDERS(state, ordersList) {
      state.ordersAll = ordersList;
    },
  },

  actions: {
    async GET_ORDER({ commit }, offerId, customerId) {
      try {
        const response = await api.get(`/orders/${offerId}, ${customerId}`);
        commit('SET_ORDER', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async GET_ORDERS({ commit }, {
      offerId, farmerName, customerName, released, byDate,
    }) {
      try {
        const response = await api.get('/orders', {
          params: {
            offerId,
            farmerName,
            customerName,
            released,
            byDate,
          },
        });
        commit('SET_ORDERS', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
};

export default order;
