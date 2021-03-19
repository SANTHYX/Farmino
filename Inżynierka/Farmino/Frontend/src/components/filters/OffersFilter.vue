<template>
  <div>
    <div>
      <div id="offers-filter-bar">
        <div id="header">
          <unicon name="filter" height="40" width="40" fill="#615f5f" />
          <h1>Filtry</h1>
        </div>

        <div id="inputs">
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
              <option value="Dolnośląskie">Dolnoslaskie</option>
              <option value="KujawskoPomorskie">Kujawsko-Pomorskie</option>
              <option value="Lubelskie">Lubelskie</option>
              <option value="Lubuskie">Lubuskie</option>
              <option value="Łódzkie">Łódzkie</option>
              <option value="Małopolskie">Małopolskie</option>
              <option value="Mazowieckie">Mazowieckie</option>
              <option value="Opolskie">Opolskie</option>
              <option value="Podkarpackie">Podkarpackie</option>
              <option value="Podlaskie">Podlaskie</option>
              <option value="Pomorskie">Pomorskie</option>
              <option value="Śląskie">Śląskie</option>
              <option value="Świętokrzyskie">Świętokrzyskie</option>
              <option value="WarmińskoMazurskie">Warmińsko-Mazurskie</option>
              <option value="Wielkopolskie">Wielkopolskie</option>
              <option value="ZachodnioPomorskie">Zachodniopomorskie</option>
            </select>
          </div>

          <div id="inputs-wraper">
            <label for="city" class="form-label">Miasto</label>
            <input
              type="text"
              name="city"
              id="city"
              class="small-form-field"
              v-model.number="query.city"
            />
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

          <button id="btn" @click="search">Szukaj</button>
        </div>
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
        city: undefined,
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
  flex-direction: column;
  align-items: center;
  flex-wrap: wrap;
  @include container-border;
  background: rgba(246, 246, 246, 0.856);
  width: 80vw;

  #header {
    padding: 0.7rem;
    display: flex;
    justify-content: flex-start;
    background: rgb(235, 235, 235);
    border-bottom: 1px solid rgb(223, 223, 223);
    box-shadow: 0 2px 1px rgba(211, 211, 211, 0.39);
    width: 80vw;
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
        margin-top: 0;
        font-size: 1.05rem;
        color: #615f5f;
        align-self: center;
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
  #offers-filter-bar {
    margin: 8rem 0 1rem 0;
    width: 80vw;

    #header {
      width: 80vw;
    }
  }
}
</style>
