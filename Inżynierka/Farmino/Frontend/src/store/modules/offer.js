import { api } from '../../plugins/axios';
import localStorageManager from '../../plugins/localStorageManager';

const offer = {
  namespaced: true,

  state: {
    offer: {},
    offersAll: {},
    order: {},
  },

  getters: {
    GET_OFFERS_ALL(state) {
      return state.offersAll.data;
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

    GET_PAGE_DETAILS(state) {
      return {
        pagesNumber: state.offersAll.pagesNumber,
        foundResults: state.offersAll.foundResults,
      };
    },
  },

  mutations: {
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

    async BROWSE_OFFERS(
      { commit },
      {
        phrase,
        priceFrom,
        priceTo,
        category,
        region,
        farmerName,
        page,
        city,
        results = 8,
        isActive = true,
      },
    ) {
      try {
        const response = await api.get('/offers', {
          params: {
            phrase,
            priceFrom,
            priceTo,
            farmerName,
            category,
            region,
            city,
            page,
            results,
            isActive,
          },
        });
        commit('SET_OFFERS', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CREATE_FARMER({ commit }, { userName }) {
      try {
        await api.post(
          '/farmers',
          { userName },
          { headers: { Authorization: `Bearer ${localStorageManager.getToken()}` } },
        );
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CREATE_CUSTOMER({ commit }, { userName }) {
      try {
        await api.post(
          '/customers',
          { userName },
          { headers: { Authorization: `Bearer ${localStorageManager.getToken()}` } },
        );
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CREATE_OFFER(
      { commit },
      {
        userName, title, description, minQuantity, image, product, category, region,
      },
    ) {
      const formFile = new FormData();
      formFile.append('userName', userName);
      formFile.append('title', title);
      formFile.append('description', description);
      formFile.append('minQuantity', minQuantity);
      formFile.append('image', image);
      formFile.append('category', category);
      formFile.append('region', region);
      formFile.append('product.basePrice', product.basePrice);
      formFile.append('product.baseWeightUnit', product.baseWeightUnit);

      try {
        await api.post('/offers', formFile, {
          headers: {
            'Content-Type': 'multipart/form-data',
            Authorization: `Bearer ${localStorageManager.getToken()}`,
          },
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
        await api.post(
          '/offers/make-order',
          {
            offerId,
            customerName,
            orderQuantity,
            customAddress,
            orderDetails,
          },
          { headers: { Authorization: `Bearer ${localStorageManager.getToken()}` } },
        );
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async GET_OBSERVED_OFFERS({ commit }, { userName, results = 8, page }) {
      try {
        const response = await api.get(`/offers/${userName}/observed`, {
          params: {
            results,
            page,
          },
          headers: { Authorization: `Bearer ${localStorageManager.getToken()}` },
        });
        commit('SET_OFFERS', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async OBSERVE_OFFER({ commit }, { userName, offerId }) {
      try {
        await api.post(
          '/observeds',
          { userName, offerId },
          { headers: { Authorization: `Bearer ${localStorageManager.getToken()}` } },
        );
        commit('');
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async DEACTIVATE_OFFER({ commit }, { id, userName }) {
      try {
        await api.post(
          '/offers/deactivate',
          { id, userName },
          { headers: { Authorization: `Bearer ${localStorageManager.getToken()}` } },
        );
        commit('');
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
};

export default offer;
