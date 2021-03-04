<template>
  <div>
    <div id="list-wraper">
      <div id="info-wraper">
        <h1>Aukcje</h1>
      </div>

      <div id="items-list">
        <auction-list-item v-for="auction in auctions" :key="auction.id" :auctionItem="auction" />
      </div>

      <div id="not-found" v-if="JSON.stringify(auctions) === '[]'">
        <not-found />
      </div>

      <div id="spinner" v-if="fetchingData">
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

  data() {
    return {
      fetchingData: true,
    };
  },

  computed: {
    ...mapGetters({
      auctions: 'auction/GET_AUCTIONS_ALL',
      auctionPagesNumber: 'auction/GET_PAGES_NUMBER',
    }),
  },

  components: {
    AuctionListItem,
    AuctionsListPagination,
    NotFound,
    LoadingSpinner,
  },

  created() {
    this.$store.dispatch('auction/GET_AUCTIONS', this.$route.query);
    this.fetchingData = false;
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 0 0 1rem 0;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  min-width: 70vw;
  min-height: 80vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  background: rgb(245, 245, 245);

  #info-wraper {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1rem;
    border-bottom: 1px solid rgb(216, 216, 216);
    box-shadow: 0 2px 1px rgba(211, 211, 211, 0.39);
    background: rgb(235, 235, 235);
  }

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
    margin: 4rem 0;
    min-height: 100vh;
    width: 80vw;
    flex-direction: column;
    align-items: center;

    #info-wraper {
      width: 80vw;
    }
  }
}
</style>
