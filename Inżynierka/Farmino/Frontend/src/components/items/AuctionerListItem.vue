<template>
  <div>
    <div id="auction-list-item">
      <div id="content">
        <h2>{{ auctionerItem.proposedPrice }}</h2>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'auctioner-list-item',

  props: {
    auctionerItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped>
#auction-list-item {
  display: flex;
  justify-content: center;
  justify-items: center;
  border-top: 1px solid rgb(211, 211, 211);
  border-bottom: 1px solid rgb(211, 211, 211);
  min-width: 20vw;
  padding: 0.5rem;
}
</style>
