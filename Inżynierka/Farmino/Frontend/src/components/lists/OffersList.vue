<template>
  <div>
    <div></div>
  </div>
</template>

<script>
export default {
  async created() {
    await this.$store.dispatch('offer/BROWSE_OFFERS');
  },
};
</script>

<style lang="scss" scoped></style>
