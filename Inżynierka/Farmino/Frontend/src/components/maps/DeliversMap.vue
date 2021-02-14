<template>
  <div>
    <div id="delivers-map">
      <MglMap
        :accessToken="accessToken"
        :mapStyle.sync="mapStyle"
        :center="[21.017532, 52.237049]"
        :zoom="zoom"
      >
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
    }),
  },
};
</script>

<style lang="scss" scoped>
#delivers-map {
  margin: 12rem 3rem 12rem 0;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  width: 50vw;
  height: 60vh;
  box-shadow: 1px 1px 6px rgba(187, 187, 187, 0.746);
}
</style>
