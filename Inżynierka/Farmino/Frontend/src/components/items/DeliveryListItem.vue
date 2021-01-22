<template>
  <div>
    <div id="delivery-list-item" :deliveryItem="deliveryItem">
      <div id="order-id" class="order-details">
        <h4>Numer Zamówienia</h4>
        <h4>
          <span>{{ deliveryItem.id }}</span>
        </h4>
      </div>
      <div id="offer-title" class="order-details">
        <h4>Tytuł</h4>
        <h4>
          <span>{{ deliveryItem.offer.title }}</span>
        </h4>
      </div>
      <div id="summary-price" class="order-details">
        <h4>Łączny koszt</h4>
        <h4>
          <span>{{ deliveryItem.priceSummary + 'zł' }}</span>
        </h4>
      </div>
      <div id="bought-quantity" class="order-details">
        <h4>Zamówiono</h4>
        <h4>
          <span>{{ deliveryItem.orderQuantity + deliveryItem.offer.product.baseWeightUnit }}</span>
        </h4>
      </div>
      <div id="contact" class="order-details">
        <h4>Data Realizacji</h4>
        <h4>
          <span>{{ deliveryItem.releaseDate | dateFormat('YYYY.MM.DD') }}</span>
        </h4>
      </div>
      <div id="contact" class="order-details">
        <h4>Status</h4>
        <h4>
          <span>{{ deliveryItem.orderStatus }}</span>
        </h4>
      </div>
      <div id="contact" class="order-details">
        <button @click="$router.push({ name: 'order', params: { id: deliveryItem.id } })">
          Sprawdz
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    deliveryItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped>
#delivery-list-item {
  margin: 0 0 0.5rem 0;
  display: flex;
  align-items: center;
  justify-content: space-evenly;
  flex-wrap: wrap;
  border: 1px solid rgb(189, 189, 189);
}

.order-details {
  text-align: center;
  h4 {
    margin: 0.5rem 0;
    span {
      color: rgb(124, 124, 124);
    }
  }
}

@media screen and(max-width: $tablet) {
  #delivery-list-item {
    flex-direction: column;
  }

  .order-details {
    text-align: center;
    h4 {
      margin: 0.5rem 0;
      span {
        color: rgb(124, 124, 124);
      }
    }
  }
}
</style>
