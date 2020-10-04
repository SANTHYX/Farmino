<template>
  <div id="app">
    <v-navbar></v-navbar>
    <router-view></router-view>
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
#app {
  height: 150vh;
}
</style>
