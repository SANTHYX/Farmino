<template>
  <div>
    <div id="auction-template">
      <h1>{{ auction.title }}</h1>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'auction-template',

  computed: {
    ...mapGetters({
      auction: 'auction/GET_AUCTION',
      userName: 'auth/GET_USERNAME',
    }),
  },
};
</script>

<style lang="scss" scoped></style>
