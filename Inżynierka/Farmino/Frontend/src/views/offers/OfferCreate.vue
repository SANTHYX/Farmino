<template>
  <div>
    <div id="offer-creator">
      <div id="content">
        <offer-creator />
      </div>
    </div>
  </div>
</template>

<script>
import OfferCreator from '../../components/forms/offer/OfferCreator.vue';

export default {
  components: {
    OfferCreator,
  },
};
</script>

<style lang="scss" scoped>
#offer-creator {
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;

  #content {
    margin: 12rem 0;
  }
}

@media screen and(max-width: $tablet) {
  #offer-creator {
    #content {
      margin-top: 5rem;
    }
  }
}
</style>
