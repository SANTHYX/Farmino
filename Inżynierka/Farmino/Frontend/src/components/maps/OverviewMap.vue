<template>
  <div>
    <div id="delivers-map">
      <MglMap
        :accessToken="accessToken"
        :mapStyle.sync="mapStyle"
        :center="[user.profile.address.node.lon, user.profile.address.node.lat]"
        :zoom="zoom"
      >
        <MglMarker
          :coordinates="[user.profile.address.node.lon, user.profile.address.node.lat]"
          color="red"
        />

        <MglMarker
          v-for="deliverOrder in deliveryOrders"
          :key="deliverOrder.id"
          :coordinates="[
            deliverOrder.orderDetails.address.node.lon,
            deliverOrder.orderDetails.address.node.lat,
          ]"
        />
        <MglGeojsonLayer
          :sourceId="geoJsonSource.data.id"
          :source="geoJsonSource"
          layerId="myLayer"
          :layer="geoJsonLayer"
        />
      </MglMap>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import { MglMap, MglMarker, MglGeojsonLayer } from 'vue-mapbox';

export default {
  name: 'delivers-map',

  components: {
    MglMap,
    MglMarker,
    MglGeojsonLayer,
  },

  data() {
    return {
      accessToken:
        'pk.eyJ1Ijoic2FudGh5eCIsImEiOiJja2sxaXU5ejAwcng4Mm5wY2xhOXlicDZsIn0.1Ur47k0QWf9nIulyzO6zOQ',
      mapStyle: 'mapbox://styles/mapbox/streets-v11',
      zoom: 7,

      geoJsonLayer: {
        id: 'route',
        type: 'line',
        layout: {
          'line-join': 'round',
          'line-cap': 'round',
        },
        paint: {
          'line-color': '#888',
          'line-width': 4,
        },
      },
    };
  },

  computed: {
    ...mapGetters({
      deliveryOrders: 'order/GET_DELIVERY_ORDERS',
      user: 'user/GET_STATE_USER',
      geoJsonSource: 'direction/GET_CLIENT_GEONODE',
    }),
  },

  async created() {
    await this.$store.dispatch('direction/GET_ROUTE_NODES');
  },
};
</script>

<style lang="scss" scoped>
#delivers-map {
  display: flex;
  flex-direction: column;
  border: 1px solid rgb(216, 216, 216);
  width: 40vw;
  height: 70vh;
  box-shadow: 1px 1px 6px rgba(187, 187, 187, 0.746);
}

@media screen and(max-width: 845px) {
  #delivers-map {
    width: 80vw;
    height: 50vh;
  }
}
</style>
