<template>
  <div>
    <div id="order-address-from" v-if="!user.profile">
      <custom-address-form />
    </div>
    <div id="order-address-from" v-if="user.profile">
      <div id="button-wrapers" v-if="!showCustomAddressForm">
        <h2>Użyć danych z profilu jako danych korespondencyjnych?</h2>
        <div>
          <button @click="moveToSummary">Tak</button>
          <button @click="(showCustomAddressForm = true), customAddres(true)">Nie</button>
        </div>
      </div>
      <custom-address-form v-if="showCustomAddressForm" />
    </div>
  </div>
</template>

<script>
import { mapGetters, mapMutations } from 'vuex';
import customAddressForm from './inputs/CustomAddressForm.vue';

export default {
  name: 'order-address-form',

  data() {
    return {
      showCustomAddressForm: false,
    };
  },

  components: {
    customAddressForm,
  },

  computed: {
    ...mapGetters({
      order: 'offer/GET_ORDER',
      offer: 'offer/GET_OFFER',
      user: 'user/GET_STATE_USER',
    }),
  },

  methods: {
    ...mapMutations({
      customAddres: 'offer/SET_CUSTOM_ADDRESS',
      setCustomOrderDetails: 'offer/SET_CUSTOM_ORDER_DETAILS',
    }),

    moveToSummary() {
      this.$router.push({ name: 'summary' });
      this.setCustomOrderDetails(this.user.profile);
      this.customAddres(false);
    },
  },

  async beforeCreate() {
    this.$store.dispatch('user/GET_USER', this.$store.state.auth.userName);
  },
};
</script>

<style lang="scss" scoped>
#order-address-from {
  margin: 12rem 0;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 50vw;
  padding: 4rem;
  flex-wrap: wrap;
  border: 1px solid rgb(192, 191, 191);

  #bought-product-descripton {
    display: flex;
    justify-content: space-between;
    border: 1px solid rgb(190, 190, 190);
    width: 50vw;

    #img-wraper {
      height: 15vh;
      width: 14vw;
      background: rgb(196, 196, 196);
    }

    #product-content {
      display: flex;
    }
  }
  #button-wrapers {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    text-align: center;
  }
}

@media screen and(max-width: $tablet) {
  #order-address-from {
    width: 70vw;
  }
}
</style>
