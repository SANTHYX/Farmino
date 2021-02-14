<template>
  <div>
    <div id="city-widget" :lon="lon" :lat="lat">
      <MglMap
        :accessToken="accessToken"
        :mapStyle.sync="mapStyle"
        :center="[lon, lat]"
        :zoom="zoom"
      >
        <MglMarker :coordinates="[lon, lat]" color="red" />
      </MglMap>
    </div>
  </div>
</template>

<script>
import { MglMap, MglMarker } from 'vue-mapbox';

export default {
  name: 'city-widget',

  components: {
    MglMap,
    MglMarker,
  },

  props: {
    lon: {
      type: Number,
      required: true,
    },
    lat: {
      type: Number,
      required: true,
    },
  },

  data() {
    return {
      accessToken:
        'pk.eyJ1Ijoic2FudGh5eCIsImEiOiJja2sxaXU5ejAwcng4Mm5wY2xhOXlicDZsIn0.1Ur47k0QWf9nIulyzO6zOQ',
      mapStyle: 'mapbox://styles/mapbox/streets-v11',
      zoom: 11,
    };
  },
};
</script>

<style lang="scss" scoped>
#city-widget {
  width: 20vw;
  height: 10vh;
}

@media screen and(max-width: $tablet) {
  #city-widget {
    width: 75vw;
  }
}
</style>
