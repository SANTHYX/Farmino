<template>
  <div id="list-wraper"></div>
</template>

<script>
export default {
  async beforeCreate() {
    await this.$store.dispatch('auction/GET_AUCTIONS');
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  display: flex;
  justify-content: center;
  align-items: center;
  border: 1px solid rgb(194, 194, 194);
  width: 50vw;
  height: 80vh;
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    width: 80vw;
  }
}
</style>
