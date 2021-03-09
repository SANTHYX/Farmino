<template>
  <div>
    <div id="daily-delivers">
      <delivers-map />
    </div>
  </div>
</template>

<script>
import DeliversMap from '@/components/maps/DeliversMap.vue';

export default {
  name: 'daily-delivers',

  components: { DeliversMap },

  created() {
    this.$store.dispatch('order/GET_DELIVERY_ORDERS', {
      date: new Date().toDateString(),
      userName: this.$store.state.auth.userName,
    });
    this.$store.dispatch('user/GET_USER', this.$store.state.auth.userName);
  },
};
</script>

<style lang="scss" scoped>
#daily-delivers {
  @include flex-centred-site;
}

@media screen and(max-width: 845px) {
  #daily-delivers {
    flex-direction: column;
    align-content: center;
  }
}
</style>
