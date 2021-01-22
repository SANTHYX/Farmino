<template>
  <div>
    <div id="order-template">
      <div id="route-displayer">
        <MglMap
          :accessToken="accessToken"
          :mapStyle.sync="mapStyle"
          :center="coordinates"
          :zoom="zoom"
        >
          <MglMarker :coordinates="[]" color="green" />
          <MglMarker :coordinates="[]" color="blue" />
        </MglMap>
      </div>
      <div id=""></div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import { MglMap, MglMarker } from 'vue-mapbox';

export default {
  name: 'order-template',

  components: {
    MglMap,
    MglMarker,
  },

  data() {
    return {
      accessToken:
        'pk.eyJ1Ijoic2FudGh5eCIsImEiOiJja2sxaXU5ejAwcng4Mm5wY2xhOXlicDZsIn0.1Ur47k0QWf9nIulyzO6zOQ',
      mapStyle: 'mapbox://styles/mapbox/streets-v11',
      zoom: 11,
    };
  },

  computed: {
    ...mapGetters({
      order: 'order/GET_ORDER',
      user: 'user/GET_STATE_USER',
    }),
  },

  async created() {
    await this.$store.dispatch('user/GET_USER', this.$store.state.auth.userName);
  },
};
</script>

<style lang="scss" scoped>
#order-template {
  margin: 12rem 0;
  border: 1px solid rgb(212, 212, 212);
  width: 60vw;
  height: 80vh;
  display: flex;
}
</style>
