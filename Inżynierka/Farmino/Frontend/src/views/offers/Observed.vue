<template>
  <div>
    <div id="observed">
      <observed-list />
    </div>
  </div>
</template>

<script>
import ObservedList from '@/components/lists/ObservedList.vue';

export default {
  components: {
    ObservedList,
  },
};
</script>

<style lang="scss" scoped>
#observed {
  @include flex-centred-site-col;
}
</style>
