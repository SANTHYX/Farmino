<template>
  <div>
    <div id="auction-list-item" :auctionItem="auctionItem"></div>
  </div>
</template>

<script>
export default {
  name: 'auction-item',

  props: {
    auctionItem: {
      type: Object,
      required: true,
    },
  },

  methods: {
    moveToAuction() {},
  },
};
</script>

<style lang="scss" scoped></style>
