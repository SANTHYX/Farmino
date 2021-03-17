import { api } from '../../plugins/axios';
import localStorageManager from '../../plugins/localStorageManager';

const order = {
  namespaced: true,

  state: {
    order: {},
    ordersAll: {},
    deliveryOrders: {},
  },

  getters: {
    GET_ORDER(state) {
      return state.order;
    },

    GET_ORDERS(state) {
      return state.ordersAll.data;
    },

    GET_DELIVERY_ORDERS(state) {
      return state.deliveryOrders.data;
    },

    GET_PAGES_NUMBER(state) {
      return state.ordersAll.pagesNumber;
    },
  },

  mutations: {
    SET_ORDER(state, orderObj) {
      state.order = orderObj;
    },

    SET_ORDERS(state, ordersList) {
      state.ordersAll = ordersList;
    },

    SET_DELIVERY_ORDERS(state, deliveryOrdersList) {
      state.deliveryOrders = deliveryOrdersList;
    },

    RELEASE_ORDER(state, payload) {
      const index = state.ordersAll.data.findIndex((x) => x.id === payload.orderId);
      state.ordersAll.data[index].releaseDate = payload.realisationDate;
      state.ordersAll.data[index].orderStatus = 'Przyjeta';
    },

    CANCEL_ORDER(state, payload) {
      const index = state.ordersAll.data.findIndex((x) => x.id === payload.orderId);
      state.ordersAll.data[index].orderStatus = 'Odrzucona';
    },

    DELIVER_ORDER(state, payload) {
      const index = state.ordersAll.data.findIndex((x) => x.id === payload.orderId);
      state.ordersAll.data[index].orderStatus = 'Dostarczona';
    },

    CLEAR_ORDERS(state) {
      state.ordersAll.date = [];
    },
  },

  actions: {
    async GET_ORDER({ commit }, orderId) {
      try {
        const response = await api.get(`/orders/${orderId}`, {
          headers: { Authorization: `Bearer ${localStorageManager.getToken()}` },
        });
        commit('SET_ORDER', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async GET_ORDERS(
      { commit },
      {
        offerId, farmerName, customerName, orderStatus, date, page, results = 8,
      },
    ) {
      try {
        const response = await api.get('/orders', {
          params: {
            offerId,
            farmerName,
            customerName,
            orderStatus,
            date,
            page,
            results,
          },
          headers: { Authorization: `Bearer ${localStorageManager.getToken()}` },
        });
        commit('SET_ORDERS', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async GET_DELIVERY_ORDERS({ commit }, { date, userName }) {
      try {
        const response = await api.get(`/orders/delivery-orders/${date},${userName}`, {
          headers: { Authorization: `Bearer ${localStorageManager.getToken()}` },
        });
        commit('SET_DELIVERY_ORDERS', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CANCEL_ORDER({ commit }, { orderId }) {
      try {
        await api.put(
          '/orders/cancel',
          { orderId },
          { headers: { Authorization: `Bearer ${localStorageManager.getToken()}` } },
        );
        commit('CANCEL_ORDER', { orderId });
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async RELEASE_ORDER({ commit }, { orderId, realisationDate }) {
      try {
        await api.put(
          '/orders',
          { orderId, realisationDate },
          { headers: { Authorization: `Bearer ${localStorageManager.getToken()}` } },
        );
        commit('RELEASE_ORDER', { orderId, realisationDate });
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async DELIVER_ORDER({ commit }, { orderId }) {
      try {
        await api.put(
          '/orders/release',
          { orderId },
          { headers: { Authorization: `Bearer ${localStorageManager.getToken()}` } },
        );
        commit('DELIVER_ORDER', { orderId });
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
};

export default order;
