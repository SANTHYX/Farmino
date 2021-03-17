<template>
  <div>
    <div id="list-wraper">
      <div id="info-wraper">
        <h1>Moje Dostawy</h1>
      </div>

      <div id="list-item">
        <delivery-list-item v-for="order in orders" :key="order.id" :deliveryItem="order" />
      </div>

      <div id="not-found" v-if="JSON.stringify(orders) === '[]'">
        <not-found />
      </div>

      <div id="spinner" v-if="fetchingData">
        <loading-spinner />
      </div>
    </div>
    <delivery-list-pagination />
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import DeliveryListItem from '../items/DeliveryListItem.vue';
import DeliveryListPagination from '../pagination/DeliveryListPagination.vue';
import NotFound from '../utils/NotFound.vue';
import LoadingSpinner from '../utils/LoadingSpinner.vue';

export default {
  name: 'delivers-list',

  components: {
    DeliveryListItem,
    DeliveryListPagination,
    NotFound,
    LoadingSpinner,
  },

  data() {
    return {
      fetchingData: false,
    };
  },

  computed: {
    ...mapGetters({
      orders: 'order/GET_ORDERS',
      deliversPagesNumber: 'order/GET_PAGES_NUMBER',
    }),
  },

  created() {
    this.$store.dispatch('order/GET_ORDERS', {
      date: this.$route.query.date,
      farmerName: this.$store.state.auth.userName,
      customerName: this.$route.query.customerName,
      orderStatus: this.$route.query.orderStatus,
    });
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 0 0 1rem 0;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  width: 80vw;
  min-width: 50vw;
  min-height: 80vh;
  background: rgba(245, 245, 245, 0.87);

  #info-wraper {
    display: flex;
    padding: 1rem;
    width: 80vw;
    background: rgb(233, 233, 233);
    border-bottom: 1px solid rgb(216, 216, 216);
    box-shadow: 0 2px 1px rgba(211, 211, 211, 0.39);
    color: rgb(100, 100, 100);
  }
}

#not-found,
#spinner {
  height: 80vh;
  display: flex;
  justify-content: center;
  align-items: center;
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 1rem 0;
    min-height: 90vh;
    width: 80vw;

    #info-wraper {
      width: 80vw;
    }
  }
}
</style>
