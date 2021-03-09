<template>
  <div>
    <div id="delivers-map">
      <MglMap
        :accessToken="accessToken"
        :mapStyle.sync="mapStyle"
        :center="[user.profile.address.node.lon, user.profile.address.node.lat]"
        :zoom="zoom"
        v-if="user.profile"
      >
        <MglMarker
          :coordinates="[user.profile.address.node.lon, user.profile.address.node.lat]"
          color="red"
          v-if="user.profile"
        />

        <MglMarker
          :coordinates="[order.orderDetails.address.node.lon, order.orderDetails.address.node.lat]"
          v-if="order.orderDetails"
        />

        <MglGeojsonLayer
          :sourceId="geoJsonSource.data.id"
          :source="geoJsonSource"
          layerId="route"
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
      zoom: 10,

      geoJsonLayer: {
        id: 'route',
        type: 'line',
        layout: {
          'line-join': 'round',
          'line-cap': 'round',
        },
        paint: {
          'line-color': 'red',
          'line-width': 4,
        },
      },
    };
  },

  computed: {
    ...mapGetters({
      order: 'order/GET_ORDER',
      user: 'user/GET_STATE_USER',
      geoJsonSource: 'direction/GET_CLIENT_GEONODE',
    }),
  },
};
</script>

<style lang="scss" scoped>
#delivers-map {
  display: flex;
  flex-direction: column;
  border: 1px solid rgb(216, 216, 216);
  width: 40vw;
  height: 72vh;
  box-shadow: 1px 1px 6px rgba(187, 187, 187, 0.746);
}

@media screen and(max-width: 845px) {
  #delivers-map {
    width: 80vw;
    height: 60vh;
  }
}
</style>
