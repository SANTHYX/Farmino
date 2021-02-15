<template>
  <div>
    <div id="daily-delivers">
      <delivers-map />
      <clients-orders-list />
    </div>
  </div>
</template>

<script>
import ClientsOrdersList from '@/components/lists/ClientsOrdersList.vue';
import DeliversMap from '@/components/maps/DeliversMap.vue';

export default {
  name: 'daily-delivers',

  components: {
    ClientsOrdersList,
    DeliversMap,
  },

  created() {
    this.$store.dispatch('order/GET_DELIVERY_ORDERS', {
      date: new Date().toDateString(),
      userName: this.$store.state.auth.userName,
    });
  },
};
</script>

<style lang="scss" scoped>
#daily-delivers {
  @include flex-centred-site;
}

@media screen and(max-width: $tablet) {
  #daily-delivers {
    flex-direction: column;
    align-content: center;
  }
}
</style>
