<template>
  <div>
    <div id="offer-list-item" :offerItem="offerItem"></div>
  </div>
</template>

<script>
export default {
  name: 'offer-item',

  props: {
    offerItem: {
      type: Object,
      required: true,
    },
  },

  methods: {
    moveToOffer() {},
  },
};
</script>

<style lang="scss" scoped>
#offer-list-item {
  border: 1px solid black;
}
</style>
