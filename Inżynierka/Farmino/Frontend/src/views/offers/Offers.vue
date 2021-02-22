<template>
  <div>
    <div id="offers">
      <div id="content">
        <offers-filter />
        <offers-list />
      </div>
    </div>
  </div>
</template>

<script>
import OffersList from '@/components/lists/OffersList.vue';
import OffersFilter from '@/components/filters/OffersFilter.vue';

export default {
  name: 'offers',

  components: {
    OffersList,
    OffersFilter,
  },
};
</script>

<style lang="scss">
#offers {
  @include flex-centred-site-col;
}
</style>
