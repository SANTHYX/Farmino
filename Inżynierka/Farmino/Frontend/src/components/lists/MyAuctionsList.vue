<template>
  <div>
    <div id="list-wraper">
      <my-auction-list-item v-for="auction in auctions" :key="auction.id" :auctionItem="auction" />
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import MyAuctionListItem from '../items/MyAuctionsListItem.vue';

export default {
  components: {
    MyAuctionListItem,
  },

  computed: {
    ...mapGetters({
      auctions: 'auction/GET_AUCTIONS_ALL',
    }),
  },

  created() {
    this.$store.dispatch('auction/GET_AUCTIONS', {
      auctionerName: this.$store.state.auth.userName,
    });
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 12rem 0;
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
