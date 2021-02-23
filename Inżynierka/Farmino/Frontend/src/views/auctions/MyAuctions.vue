<template>
  <div>
    <div id="my-auctions">
      <my-auctions-list />
    </div>
  </div>
</template>

<script>
import MyAuctionsList from '@/components/lists/MyAuctionsList.vue';

export default {
  name: 'my-auctions',

  components: {
    MyAuctionsList,
  },
};
</script>

<style lang="scss" scoped>
#my-auctions {
  @include flex-centred-site-col;
}
</style>
