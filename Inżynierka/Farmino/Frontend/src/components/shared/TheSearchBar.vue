<template>
  <div id="search-bar">
    <input
      type="search"
      name="search-bar"
      id="search-bar-form"
      placeholder="Szukaj..."
      v-model="query.phrase"
    />

    <select name="types" id="type-picker" v-model="endpoint">
      <option value="offers" id="option-field">Oferta</option>
      <option value="auctions" id="option-field">Aukcje</option>
    </select>

    <button id="search-btn" @click="search" :disabled="$v.query.$invalid">
      <unicon name="search" height="20" />
    </button>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import { required } from 'vuelidate/lib/validators';

export default {
  name: 'search-bar',

  data() {
    return {
      endpoint: 'offers',
      query: {
        phrase: undefined,
      },
    };
  },

  validations: {
    query: {
      phrase: { required },
    },
  },

  methods: {
    ...mapActions({
      getOffers: 'offer/BROWSE_OFFERS',
      getAuctions: 'auction/GET_AUCTIONS',
    }),

    search() {
      if (this.$route.name === 'offers') {
        this.getOffers(this.query);
        this.$router.replace({ name: this.endpoint, query: this.query });
      }
      if (this.$route.name === 'auctions') {
        this.getAuctions(this.query);
        this.$router.replace({ name: this.endpoint, query: this.query });
      }
      this.$router.replace({ name: this.endpoint, query: this.query });
    },
  },
};
</script>

<style lang="scss" scoped>
#search-bar {
  display: flex;
  align-items: center;

  #search-bar-form {
    font-size: 1rem;
    height: 35px;
    width: 24vw;
    min-width: 180px;
    border: none;
    border-radius: 7px 0px 0px 7px;
    padding: 0 0.7rem;
    background: rgb(241, 245, 184);
    border-top: 1px solid rgb(216, 216, 216);
    border-bottom: 1px solid rgb(216, 216, 216);
    border-left: 1px solid rgb(216, 216, 216);
  }

  #search-btn {
    display: flex;
    font-size: 1rem;
    height: 35px;
    width: 50px;
    border: none;
    padding: 0 0.4rem;
    border-radius: 0px 7px 7px 0px;
    cursor: pointer;
    align-items: center;
    justify-content: center;
    background: rgb(241, 169, 34);
    border-top: 1px solid rgb(216, 216, 216);
    border-bottom: 1px solid rgb(216, 216, 216);
    border-right: 1px solid rgb(216, 216, 216);
    transition: 0.5s;
  }

  #search-btn:hover {
    background: rgb(221, 152, 23);
  }

  #type-picker {
    height: 35px;
    width: 80px;
    border: 1px solid rgb(216, 216, 216);
    text-align: center;
    background: rgb(232, 240, 127);
    font-size: 1rem;
    appearance: none;

    #option-field {
      text-align: center;
    }
  }
}
</style>
