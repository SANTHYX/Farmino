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
    async GET_ORDER({ commit }, orderId) {
      try {
        const response = await api.get(`/orders/${orderId}`);
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

    async CANCEL_ORDER({ commit }, { orderId }) {
      try {
        await api.put('/orders/cancel', { orderId });
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async RELEASE_ORDER({ commit }, { orderId, realisationDate }) {
      try {
        await api.put('/orders', { orderId, realisationDate });
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
};

export default order;
