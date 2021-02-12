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
};
</script>

<style lang="scss" scoped>
#order {
  @include flex-centred-site;
}
</style>
