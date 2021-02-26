<template>
  <div>
    <div id="list-wraper">
      <order-list-item v-for="order in orders" :key="order.id" :orderItem="order" />

      <div id="not-found" v-if="JSON.stringify(orders) === '[]'">
        <not-found />
      </div>

      <div id="spinner" v-if="fetchingData">
        <loading-spinner />
      </div>
    </div>
    <orders-list-pagination />
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import OrderListItem from '../items/OrderListItem.vue';
import OrdersListPagination from '../pagination/OrdersListPagination.vue';
import NotFound from '../utils/NotFound.vue';
import LoadingSpinner from '../utils/LoadingSpinner.vue';

export default {
  name: 'orders-list',

  components: {
    OrderListItem,
    OrdersListPagination,
    NotFound,
    LoadingSpinner,
  },

  data() {
    return {
      fetchingData: true,
    };
  },

  computed: {
    ...mapGetters({
      orders: 'order/GET_ORDERS',
      ordersPagesNumber: 'order/GET_PAGES_NUMBER',
    }),
  },

  async created() {
    await this.$store.dispatch('order/GET_ORDERS', {
      customerName: this.$store.state.auth.userName,
    });
    this.fetchingData = false;
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

  #not-found,
  #spinner {
    display: flex;
    align-items: center;
    justify-content: center;
    min-height: 100vh;
  }
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 12rem 0;
    min-height: 90vh;
    width: 80vw;
  }
}
</style>
