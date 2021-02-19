<template>
  <div>
    <div id="offers">
      <div id="content">
        <offers-filter-bar />
        <offers-list />
      </div>
    </div>
  </div>
</template>

<script>
import OffersList from '@/components/lists/OffersList.vue';
import OffersFilterBar from '@/components/filters/OffersFilterBar.vue';

export default {
  name: 'offers',

  components: {
    OffersList,
    OffersFilterBar,
  },
};
</script>

<style lang="scss">
#offers {
  @include flex-centred-site-col;
}
</style>
