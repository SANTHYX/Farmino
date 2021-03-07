<template>
  <div>
    <div id="list-wraper">
      <h1>Lista Dostaw</h1>
      <hr />
      <client-orders-list-item v-for="order in orders" :key="order.id" :orderItem="order" />

      <div id="not-found" v-if="JSON.stringify(orders) === '[]'">
        <not-found />
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import ClientOrdersListItem from '../items/ClientOrdersListItem.vue';
import NotFound from '../utils/NotFound.vue';

export default {
  name: 'clients-orders-list',

  components: {
    ClientOrdersListItem,
    NotFound,
  },

  computed: {
    ...mapGetters({
      orders: 'order/GET_DELIVERY_ORDERS',
    }),
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 12rem 0;
  display: flex;
  flex-direction: column;
  align-items: center;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  min-width: 20vw;
  min-height: 70vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  background: rgb(245, 245, 245);

  h1 {
    margin: 0.75rem 0 0 0;
    color: rgb(105, 105, 105);
  }

  hr {
    width: 200px;
    color: orange;
    margin: 0 0 1rem 0;
    border: solid 2px orange;
  }

  #not-found,
  #spinner {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 50vh;
  }
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 0;
    width: 88vw;
    height: 20vh;
    margin: 1rem 0 5rem 0;
  }
}
</style>
