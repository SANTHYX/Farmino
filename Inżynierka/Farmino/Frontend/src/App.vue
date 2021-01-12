<template>
  <div id="app">
    <div>
      <v-navbar></v-navbar>
      <transition name="fade">
        <router-view id="view" />
      </transition>
      <v-footer></v-footer>
    </div>
  </div>
</template>

<script>
import Navbar from './components/shared/Navbar.vue';
import Footer from './components/shared/Footer.vue';

export default {
  name: 'app',
  components: {
    'v-navbar': Navbar,
    'v-footer': Footer,
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
