<template>
  <div>
    <div id="order-template" :orderId="orderId">
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
      <div id="client-details">x</div>
      <div id="order-details">x</div>
      <div id="decision-panel">
        <button>Zadzwoń</button>
        <button @click="releaseOrder">Realizuj</button>
        <button @click="cancelOrderAsync">Odrzuć</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import { MglMap, MglMarker } from 'vue-mapbox';

export default {
  name: 'order-template',

  props: {
    orderId: {
      type: String,
      required: true,
    },
  },

  components: {
    MglMap,
    MglMarker,
  },

  data() {
    return {
      showRealisationFrom: false,
    };
  },

  computed: {
    ...mapGetters({
      order: 'order/GET_ORDER',
      user: 'user/GET_STATE_USER',
    }),
  },

  methods: {
    ...mapActions({
      cancelOrder: 'order/CANCEL_ORDER',
    }),

    cancelOrderAsync() {
      this.cancelOrder({ orderId: this.orderId });
      this.$router.push({ name: 'my-delivers' });
    },

    releaseOrder() {
      this.showRealisationFrom = !this.showRealisationFrom;
      this.$emit('releaseOrderEvent', this.showRealisationFrom);
    },
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
  width: 40vw;
  height: 60vh;
  display: flex;

  #decision-panel {
    display: flex;
    justify-content: center;
    align-items: center;
  }
}
</style>
