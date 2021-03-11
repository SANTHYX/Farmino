<template>
  <div id="app">
    <div>
      <the-navbar />
      <transition name="fade">
        <router-view id="view" class="background-svg" />
      </transition>
      <the-footer />
    </div>
  </div>
</template>

<script>
import TheNavbar from './components/shared/TheNavbar.vue';
import TheFooter from './components/shared/TheFooter.vue';

export default {
  name: 'app',
  components: {
    TheNavbar,
    TheFooter,
  },
};
</script>
<style lang="scss">
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

#app {
  #view {
    min-height: 100vh;
  }
}
</style>
