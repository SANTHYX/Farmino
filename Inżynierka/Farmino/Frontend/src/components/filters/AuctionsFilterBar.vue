<template>
  <div>
    <div id="auctions-filter-bar">
      <label for="">Cena</label>
      <input type="text" id="price-from" v-model.number="query.priceFrom" />
      <input type="text" id="price-from" v-model.number="query.priceTo" />

      <label for="region">Województwo</label>
      <select name="region" id="region" v-model="query.region">
        <option value="dolnoslaskie">Dolnoslaskie</option>
        <option value="kujawskopomorskie">Kujawsko-Pomorskie</option>
        <option value="lubelskie">Lubelskie</option>
        <option value="lubuskie">Lubuskie</option>
        <option value="lodzkie">Łódzkie</option>
        <option value="malopolskie">Małopolskie</option>
        <option value="mazowieckie">Mazowieckie</option>
        <option value="opolskie">Opolskie</option>
        <option value="podkarpackie">Podkarpackie</option>
        <option value="podlaskie">Podlaskie</option>
        <option value="pomorskie">Pomorskie</option>
        <option value="slaskie">Śląskie</option>
        <option value="swietokrzyskie">Świętokrzyskie</option>
        <option value="warminskomazurskie">Warmińsko-Mazurskie</option>
        <option value="wielkopolskie">Wielkopolskie</option>
        <option value="zachodnioPomorskie">Zachodniopomorskie</option>
      </select>

      <label for="">Kategoria</label>
      <select name="category" id="category" v-model="query.category">
        <option value="warzywa">Warzywa</option>
        <option value="owoce">Owoce</option>
        <option value="przetwory">Przetwory</option>
        <option value="wedliny">Wędliny</option>
        <option value="nabial">Nabiał</option>
        <option value="pieczywo">Pieczywo</option>
      </select>

      <label for="deliverPrice">Dowóz od</label>
      <input
        type="number"
        name="delive-price"
        id="deliver-price"
        v-model.number="query.deliverPrice"
      />

      <button @click="search">Szukaj</button>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'auctions-filter-bar',

  data() {
    return {
      query: {
        priceFrom: 0,
        priceTo: 0,
        region: '',
        category: '',
        deliverPrice: 0,
      },
    };
  },

  computed: {
    phrase() {
      return this.$route.query.phrase;
    },
  },

  methods: {
    ...mapActions({
      getOffers: 'auction/GET_AUCTIONS',
    }),

    search() {
      this.$router.replace({
        name: 'auctions',
        query: {
          phrase: this.phrase,
        },
      });
      this.getOffers(this.query);
    },
  },
};
</script>

<style lang="scss" scoped>
#auctions-filter-bar {
  margin: 10rem 0 2rem 0;
}
</style>
