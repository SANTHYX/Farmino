<template>
  <div>
    <div id="pagination-list">
      <button
        v-for="index in auctionsPageNumbers"
        :key="index"
        id="page-btn"
        @click="fetchPage(index)"
      >
        {{ index }}
      </button>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'pagination-list',

  computed: {
    ...mapGetters({
      auctionsPageNumbers: 'auction/GET_PAGES_NUMBER',
    }),
  },

  methods: {
    ...mapActions({
      getAuctions: 'auction/GET_AUCTIONS',
    }),

    fetchPage(pagesNumber) {
      this.getAuctions({ ...this.$route.query, page: pagesNumber });
      this.$router.replace({
        name: 'auctions',
        query: { ...this.$route.query, page: pagesNumber },
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#pagination-list {
  display: flex;
  justify-content: center;
  margin: 0 0 3rem 0;
  padding: 0.5rem;

  #page-btn {
    width: 30px;
    height: 35px;
  }
}
</style>
