<template>
  <div>
    <div id="list-wraper">
      <offer-list-item v-for="offer in offers" :key="offer.id" :offerItem="offer" />
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import OfferListItem from '../items/OfferListItem.vue';

export default {
  name: 'offers-list',

  components: {
    OfferListItem,
  },

  computed: {
    ...mapGetters({
      offers: 'offer/GET_OFFERS_ALL',
    }),
  },

  created() {
    this.$store.dispatch('offer/BROWSE_OFFERS', this.$route.query);
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 0 0 5rem 0;
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
    min-height: 90vh;
    width: 80vw;
    flex-direction: column;
  }
}
</style>
