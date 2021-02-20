<template>
  <div>
    <div id="pagination-list" :pagesNumber="pagesNumber">
      <page-button v-for="index in pagesNumber" :key="index" :page="index" />
    </div>
  </div>
</template>

<script>
import PageButton from './PageButton.vue';

export default {
  name: 'pagination-list',

  props: {
    pagesNumber: {
      value: Number,
      required: true,
    },
  },

  components: { PageButton },
};
</script>

<style lang="scss" scoped></style>
