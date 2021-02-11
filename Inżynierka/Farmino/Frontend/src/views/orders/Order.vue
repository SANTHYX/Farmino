<template>
  <div>
    <div id="order">
      <order-template
        :orderId="id"
        @releaseOrderEvent="switchToRealisationForm"
        v-if="showRealisationForm == false"
      />
      <realisation-form :orderId="id" v-else />
    </div>
  </div>
</template>

<script>
import OrderTemplate from '@/components/templates/OrderTemplate.vue';
import RealisationForm from '@/components/forms/order/RealisationForm.vue';

export default {
  name: 'order',

  props: {
    id: {
      type: String,
    },
  },

  components: {
    OrderTemplate,
    RealisationForm,
  },

  data() {
    return {
      showRealisationForm: false,
    };
  },

  methods: {
    switchToRealisationForm(input) {
      this.showRealisationForm = input;
    },
  },

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
