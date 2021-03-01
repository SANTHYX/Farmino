<template>
  <div>
    <div id="offer-creator">
      <offer-creator />
    </div>
  </div>
</template>

<script>
import OfferCreator from '@/components/forms/offer/OfferCreator.vue';

export default {
  components: {
    OfferCreator,
  },
};
</script>

<style lang="scss" scoped>
#offer-creator {
  @include flex-centred-site;
}
</style>
