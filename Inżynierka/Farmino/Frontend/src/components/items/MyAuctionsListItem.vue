<template>
  <div>
    <div id="my-auction-item">
      <p>{{ auctionItem.id }}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    auctionItem: {
      typ: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped></style>
