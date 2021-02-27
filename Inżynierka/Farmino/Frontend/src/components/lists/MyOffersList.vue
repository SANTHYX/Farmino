<template>
  <div>
    <div id="list-wraper">
      <my-offer-list-item v-for="offer in offers" :key="offer.id" :offerItem="offer" />

      <div id="not-found" v-if="JSON.stringify(offers) === '[]'">
        <not-found />
      </div>

      <div id="spinner" v-if="fetchingData">
        <loading-spinner />
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import MyOfferListItem from '../items/MyOfferListItem.vue';
import NotFound from '../utils/NotFound.vue';
import LoadingSpinner from '../utils/LoadingSpinner.vue';

export default {
  components: {
    MyOfferListItem,
    NotFound,
    LoadingSpinner,
  },

  data() {
    return {
      fetchingData: true,
    };
  },

  computed: {
    ...mapGetters({
      offers: 'offer/GET_OFFERS_ALL',
    }),
  },

  created() {
    this.$store.dispatch('offer/BROWSE_OFFERS', { farmerName: this.$store.state.auth.userName });
    this.fetchingData = false;
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 12rem 0;
  display: flex;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  width: 70vw;
  min-width: 50vw;
  min-height: 80vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);

  #not-found,
  #spinner {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100vw;
  }
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
