<template>
  <div>
    <div id="my-delivery">
      <delivers-filter-bar />
      <delivery-list />
    </div>
  </div>
</template>

<script>
import DeliveryList from '@/components/lists/DeliveryList.vue';
import DeliversFilterBar from '@/components/filters/DeliversFilterBar.vue';

export default {
  name: 'my-delivers',

  components: {
    DeliveryList,
    DeliversFilterBar,
  },
};
</script>

<style lang="scss" scoped>
#my-delivery {
  @include flex-centred-site-col;
}
</style>
