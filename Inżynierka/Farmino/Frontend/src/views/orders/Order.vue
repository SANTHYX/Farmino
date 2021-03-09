<template>
  <div>
    <div id="order">
      <router-view />
    </div>
  </div>
</template>

<script>
export default {
  name: 'order',

  async beforeCreate() {
    await this.$store.dispatch('user/GET_USER', this.$store.state.auth.userName);
  },
};
</script>

<style lang="scss" scoped>
#order {
  @include flex-centred-site;
}
</style>
