<template>
  <div id="app">
    <v-navbar id="navbar"></v-navbar>
    <router-view id="view"></router-view>
    <v-footer></v-footer>
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
#navbar {
  position: fixed;
  width: 100vw;
}
#view {
  min-height: 100vh;
}
</style>
