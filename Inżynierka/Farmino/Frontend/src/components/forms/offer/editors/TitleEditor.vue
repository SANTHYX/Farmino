<template>
  <div>
    <div id="title-editor">
      <div id="title-wraper">
        <h1 v-if="!titleEditor">{{ offer.title }}</h1>
        <div id="inputs-wraper" v-if="titleEditor">
          <input type="text" name="userName" class="form-field" v-model="offer.title" />
        </div>
        <button @click="titleEditor = !titleEditor">
          Edytuj
          <unicon name="edit" width="20" height="20"></unicon>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'offer-creator',
  data() {
    return {
      titleEditor: false,
      offer: {
        title: 'Ustaw Tytuł Oferty',
      },
    };
  },
};
</script>

<style lang="scss" scoped>
#title-wraper {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin: 0.8rem;
  padding: 1rem;
  border: 1px solid gainsboro;

  h1 {
    margin: 0 0.5rem 0 0;
    text-align: center;
    font-weight: lighter;
    max-width: 20vw;
    font-size: 1.8rem;
  }

  button {
    margin: 1rem 0;
    display: flex;
    align-items: center;
    font-size: 0.9rem;
    padding: 0.1rem 0.4rem;
    font-weight: bold;
    font-weight: lighter;
    background: greenyellow;
    border: solid 1px rgb(204, 204, 204);
    border-radius: 20px;
  }
}

#inputs-wraper {
  display: flex;
  flex-direction: column;
}

@media screen and(max-width: $tablet) {
  #title-wraper {
    margin: 0.5;
    h1 {
      max-width: 50vw;
      text-align: center;
    }
  }
}
</style>
