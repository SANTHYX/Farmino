<template>
  <div>
    <div id="list-wraper">
      <order-list-item v-for="order in orders" :key="order.id" :orderItem="order" />
    </div>
    <pagination :pagesNumber="ordersPagesNumber" />
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import OrderListItem from '../items/OrderListItem.vue';
import Pagination from '../pagination/Pagination.vue';

export default {
  name: 'orders-list',

  components: {
    OrderListItem,
    Pagination,
  },

  computed: {
    ...mapGetters({
      orders: 'order/GET_ORDERS',
      ordersPagesNumber: 'order/GET_PAGES_NUMBER',
    }),
  },

  created() {
    this.$store.dispatch('order/GET_ORDERS', { customerName: this.$store.state.auth.userName });
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 12rem 0;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  width: 70vw;
  min-width: 50vw;
  min-height: 80vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 12rem 0;
    min-height: 90vh;
    width: 80vw;
  }
}
</style>
