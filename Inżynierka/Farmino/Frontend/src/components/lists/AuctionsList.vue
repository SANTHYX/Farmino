<template>
  <div>
    <div id="list-wraper">
      <auction-list-item v-for="auction in auctions" :key="auction.id" :auctionItem="auction" />
    </div>
    <auctions-list-pagination />
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import AuctionListItem from '../items/AuctionListItem.vue';
import AuctionsListPagination from '../pagination/AuctionsListPagination.vue';

export default {
  name: 'auctions-list',

  components: {
    AuctionListItem,
    AuctionsListPagination,
  },

  computed: {
    ...mapGetters({
      auctions: 'auction/GET_AUCTIONS_ALL',
      auctionPagesNumber: 'auction/GET_PAGES_NUMBER',
    }),
  },

  created() {
    this.$store.dispatch('auction/GET_AUCTIONS', this.$route.query);
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 0 0 1rem 0;
  display: flex;
  justify-content: baseline;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  width: 70vw;
  min-width: 50vw;
  min-height: 80vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 12rem 0;
    min-height: 100vh;
    width: 90vw;
    flex-direction: column;
  }
}
</style>
