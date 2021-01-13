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
  margin: 0.5rem;
  border: 1px solid grey;

  #title-wraper {
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center;
  }
}
</style>
