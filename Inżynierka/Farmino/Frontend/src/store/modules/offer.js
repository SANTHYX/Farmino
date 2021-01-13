const offer = {
  state: {
    offer: {},
  },
  getters: {},
  mutations: {
    SET_OFFER_STATE(state, offerObj) {
      state.offer = {
        ...offerObj,
      };
    },
  },
  actions: {},
};

export default offer;
