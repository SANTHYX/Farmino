<template>
  <div>
    <div id="my-orders">
      <orders-list />
    </div>
  </div>
</template>

<script>
import OrdersList from '@/components/lists/OrdersList.vue';

export default {
  name: 'my-orders',

  components: {
    OrdersList,
  },
};
</script>

<style lang="scss" scoped>
#my-orders {
  @include flex-centred-site;
}
</style>
