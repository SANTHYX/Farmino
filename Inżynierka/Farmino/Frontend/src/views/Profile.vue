<template>
  <div>
    <div id="profile">
      <div id="content">
        <router-view></router-view>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'profile',
};
</script>

<style lang="scss" scoped>
#profile {
  display: flex;
  justify-content: center;
  justify-self: center;
  height: 100vh;
}
</style>
