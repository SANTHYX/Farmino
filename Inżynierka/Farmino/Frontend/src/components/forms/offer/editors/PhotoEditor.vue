<template>
  <div>
    <div id="photo-editor">
      <div id="title-wraper">
        <h1>Dodaj Fotografię</h1>
        <unicon name="plus-circle"></unicon>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
#photo-editor {
  margin: 0.8rem;
  padding: 1rem;
  display: flex;
  height: 40vh;
  border: 1px solid rgb(202, 201, 201);
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  text-align: center;

  #title-wraper {
    h1 {
      font-weight: lighter;
      font-size: 1.8rem;
    }
  }
}

@media screen and(max-width: $tablet) {
  #photo-editor {
    margin: 0.5;
    h1 {
      max-width: 50vw;
      text-align: center;
    }
  }
}
</style>
