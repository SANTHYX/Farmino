<template>
  <div>
    <div id="list-wraper">
      <auctioner-list-item
        v-for="participant in participants"
        :key="participant.id"
        :auctionerItem="participant"
      />
    </div>
    <auctioners-list-pagination />
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import AuctionerListItem from '../items/AuctionerListItem.vue';
import AuctionersListPagination from '../pagination/AuctionersListPagination.vue';

export default {
  name: 'auctioners-list',

  computed: {
    ...mapGetters({
      participants: 'auction/GET_PARTICIPANTS_ALL',
    }),
  },

  components: { AuctionerListItem, AuctionersListPagination },

  created() {
    this.$store.dispatch('auction/GET_AUCTION_OVERVIEW', {
      auctionId: this.$route.params.id,
    });
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 0 0 1rem 0;
  display: flex;
  justify-content: baseline;
  flex-wrap: wrap;
  flex-direction: column;
  border: 1px solid rgb(216, 216, 216);
  width: 50vw;
  min-width: 40vw;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
}
</style>
