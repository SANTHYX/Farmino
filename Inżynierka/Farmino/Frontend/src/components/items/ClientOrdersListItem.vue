<template>
  <div>
    <div id="client-order-item" :orderItem="orderItem"></div>
  </div>
</template>

<script>
export default {
  name: 'client-order-list-item',

  props: {
    orderItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped></style>
