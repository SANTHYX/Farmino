<template>
  <div>
    <div id="order-list-item" :orderItem="orderItem">
      <div id="order-id" class="order-details">
        <h4>Numer Zamówienia</h4>
        <h4>
          <span>{{ orderItem.customerId }}</span>
        </h4>
      </div>

      <div id="offer-title" class="order-details">
        <h4>Tytuł</h4>
        <h4>
          <span>{{ orderItem.offer.title }}</span>
        </h4>
      </div>

      <div id="summary-price" class="order-details">
        <h4>Łączny koszt</h4>
        <h4>
          <span>{{ orderItem.priceSummary + 'zł' }}</span>
        </h4>
      </div>

      <div id="bought-quantity" class="order-details">
        <h4>Zamówiono</h4>
        <h4>
          <span>{{ orderItem.orderQuantity + orderItem.offer.product.baseWeightUnit }}</span>
        </h4>
      </div>

      <div id="contact" class="order-details">
        <h4>Data Realizacji</h4>
        <h4>
          <span>{{ orderItem.releaseDate | date }}</span>
        </h4>
      </div>

      <div id="contact" class="order-details">
        <h4>Status</h4>
        <h4>
          <span>{{ orderItem.orderStatus }}</span>
        </h4>
      </div>

      <div id="order-details">
        <button id="btn" @click="buttonContent = orderItem.offer.farmer.user.profile.phoneNumber">
          {{ buttonContent }}
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'order-list-item',

  props: {
    orderItem: {
      type: Object,
      required: true,
    },
  },

  filters: {
    date(value) {
      let date = new Date(value).toLocaleDateString();

      if (date === '1.01.1') {
        date = 'Brak';
      }

      return date;
    },
  },

  data() {
    return {
      buttonContent: 'Zadzwoń',
    };
  },
};
</script>

<style lang="scss" scoped>
#order-list-item {
  display: flex;
  align-items: center;
  justify-content: space-evenly;
  flex-wrap: wrap;
  border-bottom: 1px solid rgb(214, 214, 214);
}

.order-details {
  text-align: center;

  h4 {
    margin: 0.5rem 0;
    color: rgb(49, 49, 49);

    span {
      color: rgb(124, 124, 124);
    }
  }
}

#btn {
  padding: 0.5rem;
  font-size: 0.9rem;
  background: none;
  border: 1px solid grey;
  transition: 0.2s ease-in;
}

#btn:hover {
  border: 1px solid rgb(255, 145, 0);
  color: rgb(255, 145, 0);
}

@media screen and(max-width: $tablet) {
  #order-list-item {
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
