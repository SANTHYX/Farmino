<template>
  <div>
    <div id="list-wraper">
      <div id="info-wraper">
        <h1>Moje Aukcje</h1>
        <p>
          <strong>Wyniki: {{ auctionPagesNumber.foundResults }}</strong>
        </p>
      </div>
      <div id="list-content">
        <div id="items-list">
          <my-auction-list-item
            v-for="auction in auctions"
            :key="auction.id"
            :auctionItem="auction"
          />
        </div>
        <div id="not-found" v-if="JSON.stringify(auctions) === '[]'">
          <not-found />
        </div>

        <div id="spinner" v-if="fetchData">
          <loading-spinner />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import MyAuctionListItem from '../items/MyAuctionsListItem.vue';
import NotFound from '../utils/NotFound.vue';
import LoadingSpinner from '../utils/LoadingSpinner.vue';

export default {
  components: {
    MyAuctionListItem,
    NotFound,
    LoadingSpinner,
  },

  data() {
    return {
      fetchData: true,
    };
  },

  computed: {
    ...mapGetters({
      auctions: 'auction/GET_AUCTIONS_ALL',
      auctionPagesNumber: 'auction/GET_PAGES_NUMBER',
    }),
  },

  created() {
    this.$store.dispatch('auction/GET_AUCTIONS', {
      auctionerName: this.$store.state.auth.userName,
    });
    this.fetchData = false;
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 12rem 0 1rem 0;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  width: 80vw;
  min-width: 50vw;
  min-height: 100vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  background: rgb(245, 245, 245);
}

#info-wraper {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  border-bottom: 1px solid rgb(216, 216, 216);
  box-shadow: 0 2px 1px rgba(211, 211, 211, 0.39);
  color: rgb(100, 100, 100);
  background: rgb(235, 235, 235);
}

#list-content {
  display: flex;
  justify-content: center;

  #items-list {
    display: flex;
    flex-wrap: wrap;
    justify-content: space-evenly;
  }

  #spinner,
  #not-found {
    display: flex;
    align-items: center;
    justify-content: center;
    min-height: 100vh;
  }
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 4rem 0;
    min-height: 90vh;
    width: 80vw;
    flex-direction: column;
  }
}
</style>
