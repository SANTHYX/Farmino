<template>
  <div>
    <div id="auction">
      <auction-template />
    </div>
  </div>
</template>

<script>
import AuctionTemplate from '@/components/templates/AuctionTemplate.vue';

export default {
  name: 'auction',

  props: {
    id: {
      type: String,
    },
  },

  components: {
    AuctionTemplate,
  },

  created() {
    this.$store.dispatch('auction/GET_AUCTION', this.id);
  },
};
</script>

<style lang="scss" scoped>
#auction {
  @include flex-centred-site-col;
}
</style>
