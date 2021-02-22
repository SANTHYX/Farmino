<template>
  <div>
    <div id="my-delivery">
      <delivers-filter />
      <delivery-list />
    </div>
  </div>
</template>

<script>
import DeliveryList from '@/components/lists/DeliveryList.vue';
import DeliversFilter from '@/components/filters/DeliversFilter.vue';

export default {
  name: 'my-delivers',

  components: {
    DeliveryList,
    DeliversFilter,
  },
};
</script>

<style lang="scss" scoped>
#my-delivery {
  @include flex-centred-site-col;
}
</style>
