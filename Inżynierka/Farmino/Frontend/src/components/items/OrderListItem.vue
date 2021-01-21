<template>
  <div>
    <div id="order-list-item" :orderItem="orderItem"></div>
  </div>
</template>

<script>
export default {
  name: 'order-item',

  props: {
    orderItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped></style>
