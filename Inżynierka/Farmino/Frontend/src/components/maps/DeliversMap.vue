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
      </MglMap>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import { MglMap, MglMarker } from 'vue-mapbox';

export default {
  name: 'delivers-map',

  components: {
    MglMap,
    MglMarker,
  },

  data() {
    return {
      accessToken:
        'pk.eyJ1Ijoic2FudGh5eCIsImEiOiJja2sxaXU5ejAwcng4Mm5wY2xhOXlicDZsIn0.1Ur47k0QWf9nIulyzO6zOQ',
      mapStyle: 'mapbox://styles/mapbox/streets-v11',
      zoom: 7,
    };
  },

  computed: {
    ...mapGetters({
      deliveryOrders: 'order/GET_DELIVERY_ORDERS',
      user: 'user/GET_STATE_USER',
    }),
  },
};
</script>

<style lang="scss" scoped>
#delivers-map {
  margin: 12rem 3rem 12rem 0;
  display: flex;
  flex-direction: column;
  border: 1px solid rgb(216, 216, 216);
  width: 50vw;
  height: 70vh;
  box-shadow: 1px 1px 6px rgba(187, 187, 187, 0.746);
}

@media screen and(max-width: 845px) {
  #delivers-map {
    margin: 6rem 0 1rem 0;
    width: 100vw;
    height: 60vh;
  }
}
</style>
