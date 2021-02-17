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
  name: 'delivers-list',

  components: {
    DeliveryListItem,
  },

  computed: {
    ...mapGetters({
      orders: 'order/GET_ORDERS',
    }),
  },

  created() {
    this.$store.dispatch('order/GET_ORDERS', {
      farmerName: this.$store.state.auth.userName,
    });
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 0 0 5rem 0;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  width: 70vw;
  min-width: 50vw;
  min-height: 80vh;
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 1rem 0;
    min-height: 90vh;
    width: 80vw;
  }
}
</style>
