<template>
  <div>
    <div id="list-wraper">
      <div id="info-wraper">
        <h1>Oferty</h1>
        <p>
          <strong>Wyniki: {{ pageDetails.foundResults }}</strong>
        </p>
      </div>

      <div id="items-list">
        <offer-list-item v-for="offer in offers" :key="offer.id" :offerItem="offer" />
      </div>

      <div id="not-found" v-if="JSON.stringify(offers) === '[]'">
        <not-found />
      </div>

      <div id="spinner" v-if="fetchData">
        <loading-spinner />
      </div>
    </div>
    <offers-list-pagination />
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import OfferListItem from '../items/OfferListItem.vue';
import OffersListPagination from '../pagination/OffersListPagination.vue';
import LoadingSpinner from '../utils/LoadingSpinner.vue';
import NotFound from '../utils/NotFound.vue';

export default {
  name: 'offers-list',

  data() {
    return {
      fetchData: true,
    };
  },

  components: {
    OfferListItem,
    OffersListPagination,
    LoadingSpinner,
    NotFound,
  },

  computed: {
    ...mapGetters({
      offers: 'offer/GET_OFFERS_ALL',
      pageDetails: 'offer/GET_PAGE_DETAILS',
      fetchStatus: 'offer/GET_FETCH_STATUS',
    }),
  },

  async created() {
    await this.$store.dispatch('offer/BROWSE_OFFERS', this.$route.query);
    this.fetchData = false;
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
  width: 70vw;
  min-width: 50vw;
  min-height: 100vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
}

#info-wraper {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  border-bottom: 1px solid rgb(216, 216, 216);
  box-shadow: 0 2px 1px rgba(211, 211, 211, 0.39);
}

#spinner,
#not-found {
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 12rem 0;
    min-height: 90vh;
    width: 80vw;
    flex-direction: column;
  }
}
</style>
