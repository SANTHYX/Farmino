<template>
  <div id="search-bar">
    <input
      type="search"
      name="search-bar"
      id="search-bar-form"
      placeholder="Szukaj"
      v-model="phrase"
    />
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
  }
}
</style>
