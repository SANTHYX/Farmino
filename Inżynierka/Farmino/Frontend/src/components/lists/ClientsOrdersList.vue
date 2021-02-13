<template>
  <div>
    <div id="list-wraper">
      <h1>Lista Dostaw</h1>
      <hr />
      <client-orders-list-item v-for="order in orders" :key="order.id" :orderItem="order" />
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import ClientOrdersListItem from '../items/ClientOrdersListItem.vue';

export default {
  name: 'clients-list',

  components: {
    ClientOrdersListItem,
  },

  computed: {
    ...mapGetters({
      orders: 'order/GET_ORDERS',
    }),
  },

  created() {
    this.$store.dispatch('order/GET_ORDERS', { byDate: new Date().toDateString() });
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
  min-width: 20vw;
  min-height: 60vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
}
</style>
