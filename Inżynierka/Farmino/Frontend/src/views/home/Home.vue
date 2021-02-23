<template>
  <div>
    <div id="home">
      <div id="content">
        <showcase />
        <about />
        <providence />
      </div>
    </div>
  </div>
</template>

<script>
import Showcase from './sections/Showcase.vue';
import About from './sections/About.vue';
import Providence from './sections/Providence.vue';

export default {
  components: {
    Showcase,
    Providence,
    About,
  },
};
</script>

<style lang="scss" scoped></style>
