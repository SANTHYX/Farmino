<template>
  <div>
    <div id="my-delivery">
      <delivery-list />
    </div>
  </div>
</template>

<script>
import DeliveryList from '@/components/lists/DeliveryList.vue';

export default {
  components: {
    DeliveryList,
  },
};
</script>

<style lang="scss" scoped>
#my-delivery {
  @include flex-centred-site;
}
</style>
