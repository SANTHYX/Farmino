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
  name: 'auctions-list',

  components: {
    AuctionListItem,
  },

  computed: {
    ...mapGetters({
      auctions: 'auction/GET_AUCTIONS_ALL',
    }),
  },

  created() {
    this.$store.dispatch('auction/GET_AUCTIONS', this.$route.query);
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 0 0 5rem 0;
  display: flex;
  justify-content: center;
  align-items: center;
  border: 1px solid rgb(194, 194, 194);
  min-width: 50vw;
  min-height: 80vh;
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
