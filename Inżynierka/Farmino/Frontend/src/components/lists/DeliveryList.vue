<template>
  <div>
    <div id="list-wraper">
      <delivery-list-item v-for="order in orders" :key="order.id" :deliveryItem="order" />
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import DeliveryListItem from '../items/DeliveryListItem.vue';

export default {
  components: {
    DeliveryListItem,
  },

  computed: {
    ...mapGetters({
      orders: 'order/GET_ORDERS',
    }),
  },

  async created() {
    const farmerName = this.$store.state.auth.userName;
    await this.$store.dispatch('order/GET_ORDERS', { farmerName });
  },
};
</script>

<style lang="scss" scoped></style>
