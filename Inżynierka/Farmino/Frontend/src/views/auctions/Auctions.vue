<template>
  <div>
    <div id="auctions">
      <auctions-filter />
      <auctions-list />
    </div>
  </div>
</template>

<script>
import AuctionsList from '@/components/lists/AuctionsList.vue';
import AuctionsFilter from '@/components/filters/AuctionsFilter.vue';

export default {
  components: {
    AuctionsList,
    AuctionsFilter,
  },
};
</script>

<style lang="scss">
#auctions {
  @include flex-centred-site-col;
}
</style>
