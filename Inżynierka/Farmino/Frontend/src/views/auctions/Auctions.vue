<template>
  <div>
    <div id="auctions">
      <auctions-list />
    </div>
  </div>
</template>

<script>
import AuctionsList from '@/components/lists/AuctionsList.vue';

export default {
  components: {
    AuctionsList,
  },
};
</script>

<style lang="scss">
#auctions {
  @include flex-centred-site;
}
</style>
