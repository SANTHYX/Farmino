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

<style lang="scss" scoped>
#auction-template {
  margin: 2rem 0;
  padding: 0.2rem;
  border: 1px solid rgb(196, 196, 196);
  box-shadow: 1px 1px 6px rgb(179, 179, 179);
  flex-wrap: wrap;
}
</style>
