<template>
  <div>
    <div id="offer-creator">
      <div id="content">
        <offer-wizard></offer-wizard>
      </div>
    </div>
  </div>
</template>

<script>
import OfferWizard from '@/components/forms/offer/OfferWizard.vue';

export default {
  components: {
    OfferWizard,
  },
};
</script>

<style lang="scss" scoped>
#offer-creator {
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
</style>
