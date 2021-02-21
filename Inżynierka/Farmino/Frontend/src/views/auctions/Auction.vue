<template>
  <div>
    <div id="auction">
      <auction-template />
      <auctioners-list />
    </div>
  </div>
</template>

<script>
import AuctionTemplate from '@/components/templates/AuctionTemplate.vue';
import AuctionersList from '@/components/lists/AuctionersList.vue';

export default {
  name: 'auction',

  props: {
    id: {
      type: String,
    },
  },

  components: {
    AuctionTemplate,
    AuctionersList,
  },

  created() {
    this.$store.dispatch('auction/GET_AUCTION', this.id);
  },
};
</script>

<style lang="scss" scoped>
#auction {
  @include flex-centred-site-col;
}
</style>
