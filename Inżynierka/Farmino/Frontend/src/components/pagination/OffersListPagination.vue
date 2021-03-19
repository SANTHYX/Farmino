<template>
  <div>
    <div id="pagination-list">
      <button
        v-for="index in pageDetails.pagesNumber"
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
      pageDetails: 'offer/GET_PAGE_DETAILS',
    }),
  },

  methods: {
    ...mapActions({
      getOffers: 'offer/BROWSE_OFFERS',
    }),

    fetchPage(pagesNumber) {
      this.getOffers({ ...this.$route.query, page: pagesNumber, isActive: true });
      this.$router.replace({
        name: this.$route.name,
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
    border: 1px solid rgb(224, 224, 224);
    font-size: 0.9rem;
    transition: 0.1s ease-in;
  }

  #page-btn:hover {
    width: 30px;
    height: 35px;
    border: 1px solid rgba(255, 166, 0, 0.534);
  }
}
</style>
