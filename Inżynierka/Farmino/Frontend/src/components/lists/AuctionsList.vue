<template>
  <div>
    <div id="list-wraper">
      <auction-list-item v-for="auction in auctions" :key="auction.id" :auctionItem="auction" />
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import AuctionListItem from '../items/AuctionListItem.vue';

export default {
  components: {
    AuctionListItem,
  },
  computed: {
    ...mapGetters({
      auctions: 'auction/GET_AUCTIONS_ALL',
    }),
  },
  async beforeCreate() {
    await this.$store.dispatch('auction/GET_AUCTIONS');
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  display: flex;
  justify-content: center;
  align-items: center;
  border: 1px solid rgb(194, 194, 194);
  width: 50vw;
  height: 80vh;
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    width: 80vw;
  }
}
</style>
