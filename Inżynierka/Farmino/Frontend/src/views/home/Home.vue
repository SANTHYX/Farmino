<template>
  <div>
    <div id="home">
      <div id="content">
        <showcase />
        <tools />
      </div>
    </div>
  </div>
</template>

<script>
import Showcase from './sections/Showcase.vue';
import Tools from './sections/Tools.vue';

export default {
  components: {
    Showcase,
    Tools,
  },
};
</script>

<style lang="scss" scoped></style>
