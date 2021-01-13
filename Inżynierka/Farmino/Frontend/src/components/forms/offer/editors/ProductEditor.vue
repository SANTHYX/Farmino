<template>
  <div>
    <div id="product-editor">
      <div id="product-wraper">
        <div id="title-wraper">
          <h1>Ustaw Dane O Produkcie</h1>
          <unicon name="edit" @click="productEditor = !productEditor"></unicon>
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
  margin: 0.5rem;
  padding: 1rem;
  border: 1px solid gainsboro;

  #title-wraper {
    display: flex;
    align-items: center;

    h1 {
      margin: 0 0.4rem 0 0;
    }
  }
}
</style>
