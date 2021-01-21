<template>
  <div>
    <div :deliveryItem="deliveryItem"></div>
  </div>
</template>

<script>
export default {
  props: {
    deliveryItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped></style>
