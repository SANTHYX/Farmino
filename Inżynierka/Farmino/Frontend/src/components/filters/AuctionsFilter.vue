<template>
  <div>
    <div id="auctions-filter-bar">
      <div id="header">
        <unicon name="filter" height="40" width="40" />
        <h1>Filtry</h1>
      </div>

      <div id="inputs">
        <div id="inputs-wraper">
          <label for="" class="form-label">Cena</label>
          <input
            type="text"
            id="price-from"
            class="small-form-field"
            v-model.number="query.priceFrom"
          />
        </div>

        <div id="inputs-wraper">
          <label for="" class="form-label">Cena</label>
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
  name: 'auctions-filter-bar',

  data() {
    return {
      query: {
        priceFrom: undefined,
        priceTo: undefined,
        region: undefined,
        category: undefined,
        deliverPrice: undefined,
      },
    };
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
  display: flex;
  flex-direction: column;
  align-items: center;
  flex-wrap: wrap;
  border: 1px solid rgb(223, 223, 223);
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  background: rgb(246, 246, 246);
  width: 70vw;

  #header {
    padding: 0.7rem;
    display: flex;
    justify-content: center;
    background: rgb(235, 235, 235);
    border-bottom: 1px solid rgb(223, 223, 223);
    box-shadow: 0 2px 1px rgba(211, 211, 211, 0.39);
    width: 70vw;
    color: #615f5f;
  }

  #inputs {
    padding: 0.7rem;
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    width: 70vw;
    flex-wrap: wrap;

    #inputs-wraper {
      display: flex;
      flex-direction: column;

      .form-label {
        align-self: center;
        margin-top: 0;
        font-size: 1.05rem;
        color: #615f5f;
      }

      .small-form-field {
        text-align: center;
        font-size: 1rem;
      }
    }
  }

  #btn {
    align-self: flex-end;
    margin-top: 0.5rem;
    width: 134px;
    height: 35px;
    background: none;
    border: 1px solid rgb(197, 197, 197);
    transition: 0.2s ease-in;
    font-size: 0.9rem;
  }

  #btn:hover {
    color: orange;
    border: 1px solid orange;
  }
}

@media screen and(max-width: $tablet) {
  #auctions-filter-bar {
    margin: 8rem 0 1rem 0;
    width: 80vw;

    #header {
      width: 80vw;
    }
  }
}
</style>
