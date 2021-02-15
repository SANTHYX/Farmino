<template>
  <div id="search-bar">
    <input
      type="search"
      name="search-bar"
      id="search-bar-form"
      placeholder="Szukaj"
      v-model="phrase"
    />
    <select name="types" id="type-picker">
      <option value="offers" id="option-field">Oferta</option>
      <option value="auctions" id="option-field">Aukcje</option>
    </select>
    <button id="search-btn" @click="search">Szukaj</button>
  </div>
</template>

<script>
import { mapMutations } from 'vuex';

export default {
  name: 'search-bar',

  data() {
    return {
      phrase: '',
    };
  },

  methods: {
    ...mapMutations({
      SET_PHRASE: 'search/SET_PHRASE',
    }),

    search() {
      this.SET_PHRASE({ phrase: this.phrase });
      this.$router.push('/search');
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
    width: 25vw;
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
    font-size: 1rem;
    height: 35px;
    border: none;
    padding: 0 0.4rem;
    border-radius: 0px 7px 7px 0px;
    cursor: pointer;
    background: rgb(241, 169, 34);
    font-family: 'Roboto Condensed', sans-serif;
    border-top: 1px solid rgb(216, 216, 216);
    border-bottom: 1px solid rgb(216, 216, 216);
    border-right: 1px solid rgb(216, 216, 216);
  }

  #type-picker {
    height: 35px;
    width: 80px;
    border: 1px solid rgb(216, 216, 216);
    text-align: center;
    font-family: 'Roboto Condensed', sans-serif;
    background: rgb(232, 240, 127);
    font-size: 1rem;

    #option-field {
      text-align: center;
      font-family: 'Roboto Condensed', sans-serif;
    }
  }
}
</style>
