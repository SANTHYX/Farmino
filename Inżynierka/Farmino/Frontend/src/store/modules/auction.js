import api from '@/plugins/axios';

const auction = {
  namespaced: true,
  state: {
    auction: {},
    auctionsAll: [],
  },

  mutations: {
    SET_AUCTION(state, auctionObj) {
      state.action = auctionObj;
    },
    SET_AUCTIONS(state, auctionsList) {
      state.auctionsAll = auctionsList;
    },
  },

  actions: {
    async GET_AUCTION({ commit }, auctionId) {
      try {
        const response = await api.get(`/auctions/${auctionId}`);
        commit('SET_AUCTION', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },
    async GET_AUCTIONS({ commit }) {
      try {
        const response = await api.get('/offers');
        commit('SET_AUCTIONS', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
};

export default auction;
