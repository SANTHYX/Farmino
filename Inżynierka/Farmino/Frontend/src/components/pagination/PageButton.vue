<template>
  <div>
    <div id="page-button" :page="page">
      <button @click="fetchPage">{{ page }}</button>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
  name: 'page-button',

  props: {
    page: {
      type: Number,
      required: true,
    },
  },

  computed: {
    ...mapGetters({ userName: 'auth/GET_USERNAME' }),
  },

  methods: {
    ...mapActions({
      getOffers: 'offer/BROWSE_OFFERS',
      getAuctions: 'auction/GET_AUCTIONS',
      getOrders: 'order/GET_ORDERS',
    }),

    fetchPage() {
      if (this.$route.name === 'offers') {
        this.getOffers({ ...this.$route.query, page: this.page });
        this.$router.replace({
          name: 'offers',
          query: { ...this.$route.query, page: this.page },
        });
      }
      if (this.$route.name === 'auctions') {
        this.getAuctions({ ...this.$route.query, page: this.page });
        this.$router.replace({
          name: 'auctions',
          query: { ...this.$route.query, page: this.page },
        });
      }
      if (this.$route.name === 'my-orders') {
        this.getOrders({ ...this.$route.query, customerName: this.userName, page: this.page });
        this.$router.replace({
          name: 'my-orders',
          query: { ...this.$route.query, page: this.page },
        });
      }
      if (this.$route.name === 'my-delivers') {
        this.getOrders({ ...this.$route.query, farmerName: this.userName, page: this.page });
        this.$router.replace({
          name: 'my-delivers',
          query: { ...this.$route.query, page: this.page },
        });
      }
    },
  },
};
</script>

<style lang="scss" scoped></style>
