<template>
  <div>
    <div id="deliver-details">
      <h1>Szczegóły</h1>
      <hr />
      <button @click="checkDeliveryOrdersList">Wróć</button>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'delivery-details',

  props: {
    id: {
      type: String,
      required: true,
    },
  },

  computed: {
    ...mapGetters({
      order: 'order/GET_ORDER',
    }),
  },

  methods: {
    checkDeliveryOrdersList() {
      this.$router.push({ name: 'daily-delivers' });
    },
  },

  created() {
    this.$store.dispatch('order/GET_ORDER', this.id);
  },
};
</script>

<style lang="scss" scoped>
#deliver-details {
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  justify-items: center;
  border-top: 1px solid rgb(211, 211, 211);
  border-bottom: 1px solid rgb(211, 211, 211);
  min-width: 20vw;
  padding: 0.5rem;
}
</style>
