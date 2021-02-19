import { api } from '@/plugins/axios';

const auction = {
  namespaced: true,

  state: {
    auction: {},
    auctionsAll: [],
    winner: {},
  },

  getters: {
    GET_AUCTIONS_ALL(state) {
      return state.auctionsAll;
    },
  },

  mutations: {
    SET_AUCTION(state, auctionObj) {
      state.action = auctionObj;
    },

    SET_AUCTIONS(state, auctionsList) {
      state.auctionsAll = auctionsList;
    },

    SET_WINNER(state, winnerObj) {
      state.winner = winnerObj;
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

    async GET_AUCTIONS({ commit }, { phrase }) {
      try {
        const response = await api.get('/auctions', { params: { phrase } });
        commit('SET_AUCTIONS', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async CREATE_AUCTION(
      { commit },
      {
        userName, title, description, startDate, endDate, startingPrice,
      },
    ) {
      try {
        await api.post('/auctions', {
          userName,
          title,
          description,
          startDate,
          endDate,
          startingPrice,
        });
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async TO_AUCTION({ commit }, { userName, auctionId, proposedPrice }) {
      try {
        await api.post('/auctions/to-auction', {
          userName,
          auctionId,
          proposedPrice,
        });
        commit();
      } catch (err) {
        throw new Error(err.message);
      }
    },

    async GET_WINNER({ commit }, auctionId) {
      try {
        const response = await api.get(`/auctions/winner/${auctionId}`);
        commit('SET_WINNER', response.data);
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
};

export default auction;
