<template>
  <div>
    <div id="pagination-list">
      <button
        v-for="index in ordersPageNumbers"
        :key="index"
        id="page-btn"
        @click="fetchPage(index)"
      >
        {{ index }}
      </button>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'pagination-list',

  computed: {
    ...mapGetters({
      ordersPageNumbers: 'order/GET_PAGES_NUMBER',
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      getOrders: 'order/GET_ORDERS',
    }),

    fetchPage(pagesNumber) {
      this.getOrders({ ...this.$route.query, customerName: this.userName, page: pagesNumber });
      this.$router.replace({
        name: this.$route.name,
        query: { ...this.$route.query, page: pagesNumber },
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#pagination-list {
  display: flex;
  justify-content: center;
  margin: 0 0 3rem 0;
  padding: 0.5rem;

  #page-btn {
    width: 30px;
    height: 35px;
  }
}
</style>
