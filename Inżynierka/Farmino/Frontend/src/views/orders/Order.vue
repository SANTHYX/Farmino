<template>
  <div>
    <div id="order">
      <order-template />
    </div>
  </div>
</template>

<script>
import OrderTemplate from '@/components/templates/OrderTemplate.vue';

export default {
  name: 'order',

  props: {
    id: {
      type: String,
    },
  },

  components: { OrderTemplate },

  async created() {
    await this.$store.dispatch('order/GET_ORDER', this.id);
  },
};
</script>

<style lang="scss" scoped>
#order {
  @include flex-centred-site;
}
</style>
