<template>
  <div>
    <div id="auctioners-list-pagination">
      <button v-for="index in participantPagesNumber" :key="index" @click="fetchPage(index)">
        {{ index }}
      </button>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'auctioners-list-pagination',

  computed: {
    ...mapGetters({
      participantPagesNumber: 'auction/GET_PARTICIPANTS_PAGE_NUMBER',
    }),
  },

  methods: {
    ...mapActions({
      getAuctionOverview: 'auction/GET_AUCTION_OVERVIEW',
    }),

    fetchPage(pagesNumber) {
      this.getAuctionOverview({
        auctionId: this.$route.params.id,
        page: pagesNumber,
      });
    },
  },
};
</script>

<style lang="scss" scoped></style>
