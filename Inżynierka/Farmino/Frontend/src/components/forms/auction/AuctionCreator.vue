<template>
  <div>
    <div id="auction-creator-form">
      <h1>Stwórz Aukcje</h1>
      <hr />
      <div id="input-wraper">
        <label for="title" :class="[!$v.auction.title.$error ? 'form-label' : 'error-label']"
          >Tytuł</label
        >
        <input
          type="text"
          name="title"
          :class="[!$v.auction.title.$error ? 'form-field' : 'error-field']"
          @blur="$v.auction.title.$touch()"
          v-model="$v.auction.title.$model"
        />
      </div>

      <div id="input-wraper">
        <label
          for="description"
          :class="[!$v.auction.description.$error ? 'form-label' : 'error-label']"
          >Opis Aukcji</label
        >
        <input
          type="text"
          name="Opis"
          :class="[!$v.auction.description.$error ? 'form-field' : 'error-field']"
          @blur="$v.auction.description.$touch()"
          v-model="$v.auction.description.$model"
        />
      </div>

      <div id="input-wraper">
        <label
          for="startDate"
          :class="[!$v.auction.startDate.$error ? 'form-label' : 'error-label']"
          >Początek</label
        >
        <input
          type="date"
          name=""
          id=""
          :class="[!$v.auction.startDate.$error ? 'form-field' : 'error-field']"
          v-model="$v.auction.startDate.$model"
        />
      </div>

      <div id="input-wraper">
        <label for="endDate" :class="[!$v.auction.endDate.$error ? 'form-label' : 'error-label']"
          >Koniec</label
        >
        <input
          type="date"
          name=""
          :class="[!$v.auction.endDate.$error ? 'form-field' : 'error-field']"
          v-model="$v.auction.endDate.$model"
        />
      </div>

      <div id="input-wraper">
        <label
          for="startingPrice"
          :class="[!$v.auction.startDate.$error ? 'form-label' : 'error-label']"
          >Cena Wywoławcza</label
        >
        <input
          type="number"
          name="startingPrice"
          :class="[!$v.auction.startingPrice.$error ? 'form-field' : 'error-field']"
          v-model.number="$v.auction.startingPrice.$model"
        />
      </div>
      <button @click="createAuctionAsync" :disabled="$v.auction.$invalid">Stwórz</button>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import { required, decimal, minValue } from 'vuelidate/lib/validators';

export default {
  name: 'auction-creator-form',

  data() {
    return {
      auction: {
        title: '',
        description: '',
        startDate: '',
        endDate: '',
        startingPrice: 0,
      },
    };
  },

  validations: {
    auction: {
      title: { required },
      description: { required },
      startDate: { required },
      endDate: { required },
      startingPrice: { required, decimal, minValue: minValue(0.1) },
    },
  },

  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      createAuction: 'auction/CREATE_AUCTION',
    }),

    createAuctionAsync() {
      this.createAuction({ ...this.auction, userName: this.userName });
    },
  },

  created() {
    this.$store.dispatch('auction/CREATE_AUCTIONER', this.$store.state.auth.userName);
  },
};
</script>

<style lang="scss" scoped></style>
