<template>
  <div>
    <div id="querry-interface"></div>
    <div id="list-wraper">
      <order-list-item v-for="order in orders" :key="order.customerId" :orderItem="order" />
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import OrderListItem from '../items/OrderListItem.vue';

export default {
  components: {
    OrderListItem,
  },

  computed: {
    ...mapGetters({
      orders: 'order/GET_ORDERS',
    }),
  },

  async created() {
    const customerName = this.$store.state.auth.userName;
    await this.$store.dispatch('order/GET_ORDERS', { customerName });
  },
};
</script>

<style lang="scss" scoped></style>
