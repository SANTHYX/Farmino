<template>
  <div>
    <div id="order-template">
      <div id="client-details">x</div>

      <div id="order-details">x</div>

      <div id="decision-panel">
        <button>Zadzwoń</button>
        <button @click="releaseOrder">Realizuj</button>
        <button @click="revokeOrder">Odrzuc</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'order-template',

  props: {
    id: {
      type: String,
      required: true,
    },
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

    revokeOrder() {
      this.cancelOrder({ orderId: this.id });
      this.$router.push({ name: 'my-delivers' });
    },

    releaseOrder() {
      this.$router.push({ name: 'order-release', params: { id: this.id } });
    },
  },

  async created() {
    await this.$store.dispatch('user/GET_USER', this.$store.state.auth.userName);
    await this.$store.dispatch('order/GET_ORDER', this.id);
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
  justify-content: center;

  #decision-panel {
    display: flex;
    justify-content: center;
    align-items: center;
  }
}
</style>
