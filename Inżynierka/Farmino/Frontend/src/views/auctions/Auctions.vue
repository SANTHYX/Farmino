<template>
  <div>
    <div id="auctions">
      <auctions-filter-bar />
      <auctions-list />
    </div>
  </div>
</template>

<script>
import AuctionsList from '@/components/lists/AuctionsList.vue';
import AuctionsFilterBar from '@/components/filters/AuctionsFilterBar.vue';

export default {
  components: {
    AuctionsList,
    AuctionsFilterBar,
  },
};
</script>

<style lang="scss">
#auctions {
  @include flex-centred-site-col;
}
</style>
