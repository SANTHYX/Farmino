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
