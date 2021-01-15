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
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
