<template>
  <div>
    <div>
      <div id="offers-filter-bar">
        <div id="inputs-wraper">
          <label for="" class="form-label">Cena od</label>
          <input
            type="text"
            id="price-from"
            class="small-form-field"
            v-model.number="query.priceFrom"
          />
        </div>

        <div id="inputs-wraper">
          <label for="" class="form-label">Cena do</label>
          <input
            type="text"
            id="price-from"
            class="small-form-field"
            v-model.number="query.priceTo"
          />
        </div>

        <div id="inputs-wraper">
          <label for="region" class="form-label">Województwo</label>
          <select name="region" id="region" class="small-form-field" v-model="query.region">
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
        </div>

        <div id="inputs-wraper">
          <label for="" class="form-label">Kategoria</label>
          <select name="category" id="category" class="small-form-field" v-model="query.category">
            <option value="warzywa">Warzywa</option>
            <option value="owoce">Owoce</option>
            <option value="przetwory">Przetwory</option>
            <option value="wedliny">Wędliny</option>
            <option value="nabial">Nabiał</option>
            <option value="pieczywo">Pieczywo</option>
          </select>
        </div>

        <div id="inputs-wraper">
          <label for="deliverPrice" class="form-label">Dowóz od</label>
          <input
            type="number"
            name="delive-price"
            id="deliver-price"
            class="small-form-field"
            v-model.number="query.deliverPrice"
          />
        </div>

        <button id="btn" @click="search">Szukaj</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'offers-filter-bar',

  data() {
    return {
      query: {
        priceFrom: undefined,
        priceTo: undefined,
        region: undefined,
        category: undefined,
        deliverPrice: undefined,
      },
      showFilter: false,
    };
  },

  methods: {
    ...mapActions({
      getOffers: 'offer/BROWSE_OFFERS',
    }),

    async search() {
      this.$router.replace({
        name: 'offers',
        query: {
          ...this.$route.query,
          ...this.query,
        },
      });
      await this.getOffers({
        ...this.$route.query,
        ...this.query,
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#offers-filter-bar {
  margin: 10rem 0 2rem 0;
  display: flex;
  align-items: center;
  justify-content: space-around;
  flex-wrap: wrap;
  padding: 0.7rem;
  border: 1px solid rgb(223, 223, 223);
  width: 70vw;

  #inputs-wraper {
    display: flex;
    flex-direction: column;

    .form-label {
      margin-top: 0;
      font-size: 1.05rem;
      color: #615f5f;
    }

    .small-form-field {
      text-align: center;
    }
  }

  #btn {
    margin-top: 0.5rem;
    width: 134px;
    height: 27px;
  }
}
</style>
