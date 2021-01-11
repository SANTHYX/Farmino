<template>
  <div>
    <div id="offers">
      <div id="content">
        <offers-list></offers-list>
      </div>
    </div>
  </div>
</template>

<script>
import OffersList from '../../components/lists/OffersList.vue';

export default {
  components: {
    OffersList,
  },
};
</script>

<style lang="scss"></style>
