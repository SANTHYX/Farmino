<template>
  <div>
    <div id="filter-bar">
      <div>
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
      </div>
    </div>
  </div>
</template>

<script>
import { decimal } from 'vuelidate/lib/validators';

export default {
  name: 'filter-bar',

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

  validations: {
    query: {
      priceFrom: { decimal },
      priceTo: { decimal },
      deliverPrice: { decimal },
    },
  },

  updated() {
    this.$emit('query-event', this.query);
  },
};
</script>

<style lang="scss" scoped></style>
