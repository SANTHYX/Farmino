<template>
  <div>
    <div id="offer-editor">
      <offer-editor />
    </div>
  </div>
</template>

<script>
import OfferEditor from '../../components/forms/offer/OfferEditor.vue';

export default {
  components: {
    OfferEditor,
  },
};
</script>

<style lang="scss" scoped>
#offer-editor {
  @include flex-centred-site;
}
</style>
