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
};
</script>

<style lang="scss" scoped>
#daily-delivers {
  @include flex-centred-site;
}
</style>
