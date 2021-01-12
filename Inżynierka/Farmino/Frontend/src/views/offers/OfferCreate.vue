<template>
  <div>
    <div id="offer-creator">
      <div id="content">
        <h1>Kreator Offert</h1>
        <offer-creator></offer-creator>
      </div>
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
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
</style>
