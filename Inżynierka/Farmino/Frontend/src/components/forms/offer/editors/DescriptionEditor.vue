<template>
  <div>
    <div id="description-editor">
      <div id="title-wraper">
        <h1>Dodaj Opis</h1>
        <div id="inputs-wraper">
          <label for="userName" class="form-label">Login</label>
          <textarea
            name=""
            class="form-field"
            cols="30"
            rows="10"
            v-model="setDescription"
          ></textarea>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  computed: {
    setDescription: {
      get() {
        return this.$store.state.offer.description;
      },
      set(value) {
        this.$store.commit('offer/SET_DESCRIPTION', value);
      },
    },
  },
};
</script>

<style lang="scss" scoped>
#description-editor {
  padding: 1rem;
  margin: 0.8rem;
  border: 1px solid rgb(196, 196, 196);

  #title-wraper {
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center;
    flex-direction: column;

    h1 {
      margin: 0 0.5rem 0 0;
      text-align: center;
      font-weight: lighter;
      font-size: 1.8rem;
    }

    #inputs-wraper {
      display: flex;
      flex-direction: column;

      textarea {
        padding: 0.3rem;
        width: 30vw;
        height: 200px;
        font-weight: normal;
        resize: none;
      }
    }
  }
}

@media screen and(max-width: $tablet) {
  #description-editor {
    margin: 0.5;
    h1 {
      max-width: 50vw;
      text-align: center;
    }
  }
}
</style>
