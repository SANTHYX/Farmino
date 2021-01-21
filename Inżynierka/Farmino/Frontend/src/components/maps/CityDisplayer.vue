<template>
  <div>
    <div id="city-widget">
      <MglMap
        :accessToken="accessToken"
        :mapStyle.sync="mapStyle"
        :center="coordinates"
        :zoom="zoom"
      >
        <MglMarker :coordinates="coordinates" :color="green" />
      </MglMap>
    </div>
  </div>
</template>

<script>
import { MglMap, MglMarker } from 'vue-mapbox';

export default {
  name: 'BaseMap',
  components: {
    MglMap,
    MglMarker,
  },
  data() {
    return {
      accessToken:
        'pk.eyJ1Ijoic2FudGh5eCIsImEiOiJja2sxaXU5ejAwcng4Mm5wY2xhOXlicDZsIn0.1Ur47k0QWf9nIulyzO6zOQ',
      mapStyle: 'mapbox://styles/mapbox/streets-v11',
      coordinates: [22.4702336, 50.371997],
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
