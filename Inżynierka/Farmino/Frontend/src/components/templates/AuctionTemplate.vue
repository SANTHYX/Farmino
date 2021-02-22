<template>
  <div>
    <div id="auction-template">
      <h1>{{ auction.title }}</h1>
      <label for="">Propozycja</label>
      <h2>Cena wywoławcza</h2>
      <p>{{ auction.startingPrice }}</p>
      <input type="number" name="" id="" step=".01" v-model.number="$v.proposedPrice.$model" />
      <button @click="toAuctionAsync" :disabled="$v.proposedPrice.$invalid">Dodaj</button>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import { decimal, required } from 'vuelidate/lib/validators';

export default {
  name: 'auction-template',

  data() {
    return {
      proposedPrice: undefined,
    };
  },

  validations: {
    proposedPrice: { required, decimal },
  },

  computed: {
    ...mapGetters({
      auction: 'auction/GET_AUCTION',
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      toAuction: 'auction/TO_AUCTION',
    }),

    toAuctionAsync() {
      this.toAuction({
        userName: this.userName,
        auctionId: this.auction.id,
        proposedPrice: this.proposedPrice,
      });
    },
  },

  created() {
    this.$store.dispatch('auction/CREATE_PARTICIPANT', this.$store.state.auth.userName);
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
