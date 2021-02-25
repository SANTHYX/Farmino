import { directionsApi } from '@/plugins/axios';

const direction = {
  namespaced: true,

  state: {
    geoJsonSource: {
      type: 'geojson',
      data: {
        id: 'testData',
        type: 'Feature',
        properties: {},
        geometry: {
          type: 'LineString',
          coordinates: [],
        },
      },
    },
  },

  getters: {
    GET_CLIENT_GEONODE(state) {
      return state.geoJsonSource;
    },
  },

  mutations: {
    SET_CLIENT_GEONODE(state, node) {
      state.geoJsonSource.data.geometry.coordinates = node;
    },
  },

  actions: {
    async GET_ROUTE_NODES({ commit }, { farmerNodes, clientNodes }) {
      try {
        const response = await directionsApi.get(
          `/${farmerNodes.lon},${farmerNodes.lat};${clientNodes.lon},${clientNodes.lat}`,
          {
            params: {
              access_token: process.env.VUE_APP_MAPBOX_ACCESS_TOKEN,
              geometries: 'geojson',
            },
          },
        );
        commit('SET_CLIENT_GEONODE', response.data.routes[0].geometry.coordinates);
      } catch (err) {
        throw new Error(err.message);
      }
    },
  },
};

export default direction;
