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
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
</style>
