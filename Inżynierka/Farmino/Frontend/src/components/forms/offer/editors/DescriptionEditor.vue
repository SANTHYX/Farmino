<template>
  <div>
    <div id="description-editor">
      <div id="title-wraper">
        <h1>Dodaj Opis</h1>
        <unicon name="edit" @click="descriptionEditor = !descriptionEditor"></unicon>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  offer: {
    description: '',
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

    h1 {
      margin: 0 0.5rem 0 0;
      text-align: center;
      font-weight: lighter;
      font-size: 1.8rem;
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
