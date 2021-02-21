<template>
  <div>
    <div id="auction-creator">
      <auction-creator />
    </div>
  </div>
</template>

<script>
import AuctionCreator from '@/components/forms/auction/AuctionCreator.vue';

export default {
  name: 'auction-create',

  components: {
    AuctionCreator,
  },
};
</script>

<style lang="scss" scoped>
#auction-creator {
  @include flex-centred-site;
}
</style>
