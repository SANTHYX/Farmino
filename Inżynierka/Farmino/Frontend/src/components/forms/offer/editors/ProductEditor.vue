<template>
  <div>
    <div id="product-editor">
      <div id="product-wraper">
        <div id="title-wraper">
          <h1>Dodaj Dane O Produkcie</h1>
          <button @click="titleEditor = !titleEditor">
            Edytuj
            <unicon
              name="edit"
              width="20"
              height="20"
              @click="productEditor = !productEditor"
            ></unicon>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'product-editor',
  data() {
    return {
      productEditor: false,
      offer: {
        product: {},
      },
    };
  },
};
</script>

<style lang="scss" scoped>
#product-editor {
  margin: 0.8rem;
  padding: 1rem;
  border: 1px solid gainsboro;

  #title-wraper {
    display: flex;
    flex-direction: column;
    align-items: center;

    h1 {
      margin: 0 0.4rem 0 0;
      font-weight: lighter;
      font-size: 1.8rem;
    }
  }
}
@media screen and(max-width: $tablet) {
  #product-editor {
    margin: 0.5;
    h1 {
      max-width: 50vw;
      text-align: center;
    }
  }
}
</style>
