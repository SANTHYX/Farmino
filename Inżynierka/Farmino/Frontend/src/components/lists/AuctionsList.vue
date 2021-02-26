<template>
  <div>
    <div id="list-wraper">
      <auction-list-item v-for="auction in auctions" :key="auction.id" :auctionItem="auction" />

      <div id="not-found" v-if="JSON.stringify(auctions) === '[]'">
        <not-found />
      </div>

      <div id="spinner">
        <loading-spinner />
      </div>
    </div>
    <auctions-list-pagination />
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import AuctionListItem from '../items/AuctionListItem.vue';
import AuctionsListPagination from '../pagination/AuctionsListPagination.vue';
import NotFound from '../utils/NotFound.vue';
import LoadingSpinner from '../utils/LoadingSpinner.vue';

export default {
  name: 'auctions-list',

  components: {
    AuctionListItem,
    AuctionsListPagination,
    NotFound,
    LoadingSpinner,
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
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  min-width: 70vw;
  min-height: 80vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);

  #not-found,
  #spinner {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 70vw;
  }
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
