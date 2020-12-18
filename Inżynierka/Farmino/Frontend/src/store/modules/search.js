const search = {
  namespaced: true,
  state: {
    phrase: '',
    type: '',
    region: '',
    filters: {},
  },
  getters: {
    GET_PHRASE(state) {
      return state.phrase;
    },
  },
  mutations: {
    SET_PHRASE(state, phrase) {
      state.phrase = phrase;
    },
  },
};

export default search;
