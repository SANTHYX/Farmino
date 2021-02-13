<template>
  <div>
    <div id="daily-delivers">
      <delivers-map />
      <clients-list />
    </div>
  </div>
</template>

<script>
import ClientsList from '../../components/lists/ClientsList.vue';
import DeliversMap from '../../components/maps/DeliversMap.vue';

export default {
  name: 'daily-delivers',

  components: {
    ClientsList,
    DeliversMap,
  },
};
</script>

<style lang="scss" scoped>
#daily-delivers {
  @include flex-centred-site;
}
</style>
