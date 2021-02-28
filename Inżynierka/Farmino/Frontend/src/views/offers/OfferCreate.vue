<template>
  <div>
    <div id="offer-creator">
      <picture-picker />
      <offer-creator />
    </div>
  </div>
</template>

<script>
import OfferCreator from '@/components/forms/offer/OfferCreator.vue';
import PicturePicker from '@/components/forms/offer/PicturePicker.vue';

export default {
  components: {
    OfferCreator,
    PicturePicker,
  },
};
</script>

<style lang="scss" scoped>
#offer-creator {
  @include flex-centred-site;
  justify-content: space-evenly;
}
</style>
