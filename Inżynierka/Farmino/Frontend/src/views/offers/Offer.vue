<template>
  <div>
    <div id="offer">
      <offer-template />
    </div>
  </div>
</template>

<script>
import OfferTemplate from '@/components/templates/OfferTemplate.vue';

export default {
  name: 'offer',
  props: {
    id: {
      type: String,
      required: true,
    },
  },

  components: {
    OfferTemplate,
  },

  async mounted() {
    await this.$store.dispatch('offer/GET_OFFER', this.id);
  },
};
</script>

<style lang="scss" scoped>
#offer {
  @include flex-centred-site;
}
</style>
