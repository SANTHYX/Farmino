<template>
  <div>
    <div id="product-editor">
      <div id="product-wraper">
        <div id="inputs-wraper">
          <label for="userName" class="form-label">Cena</label>
          <input type="text" name="price" class="form-field" v-model.number="offer.product.price" />
        </div>
        <div id="inputs-wraper">
          <label for="userName" class="form-label">Ilosc</label>
          <input
            type="text"
            name="quantity"
            class="form-field"
            v-model.number="offer.product.quantity"
          />
        </div>
        <div id="inputs-wraper">
          <select class="form-field" v-model.number="offer.product.weight.unit">
            <option value="0">g</option>
            <option value="1">dkg</option>
            <option value="2">g</option>
            <option value="3">kg</option>
            <option value="4">T</option>
          </select>
        </div>
        <div id="inputs-wraper">
          <label for="userName" class="form-label">Ilosc</label>
          <input
            type="text"
            name="userName"
            class="form-field"
            v-model.number="offer.product.weight.value"
          />
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
      offer: {
        product: {
          price: 0,
          quantity: 0,
          weight: {
            unit: 0,
            value: 0,
          },
        },
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

    select {
      align-items: center;
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
