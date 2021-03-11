<template>
  <div>
    <div id="my-offers">
      <my-offer-list-item />
    </div>
  </div>
</template>

<script>
import MyOfferListItem from '@/components/lists/MyOffersList.vue';

export default {
  components: {
    MyOfferListItem,
  },
};
</script>

<style lang="scss" scoped>
#my-offers {
  min-height: 100vh;
  @include flex-centred-site-col;
}
</style>
