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
  components: {
    OfferListItem,
  },
  computed: {
    ...mapGetters({
      offers: 'offer/GET_OFFERS_ALL',
    }),
  },
  async created() {
    await this.$store.dispatch('offer/BROWSE_OFFERS');
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
  border: 1px solid rgb(194, 194, 194);
  min-width: 50vw;
  min-height: 80vh;
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    min-height: 90vh;
    width: 80vw;
    flex-direction: column;
  }
}
</style>
