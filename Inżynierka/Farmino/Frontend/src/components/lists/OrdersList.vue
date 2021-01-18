<template>
  <div>
    <div id="list-wraper">
      <div></div>
    </div>
  </div>
</template>

<script>
export default {
  async created() {
    await this.$store.dispatch('order/GET_ORDERS');
  },
};
</script>

<style lang="scss" scoped></style>
