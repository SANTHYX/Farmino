<template>
  <div></div>
</template>

<script>
export default {
  async beforeCreate() {
    await this.$store.dispatch('auction/GET_AUCTIONS');
  },
};
</script>

<style lang="scss" scoped></style>
