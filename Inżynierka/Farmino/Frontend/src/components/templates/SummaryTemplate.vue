<template>
  <div>
    <div id="summary-template">
      <div id="image-place">
        <img :src="`http://localhost:4800/Images/Offer/${offer.imageName}`" id="img" />
      </div>

      <div id="content">
        <div id="title">
          <h1>{{ offer.title }}</h1>
          <hr />
        </div>

        <div id="summary-overview">
          <p>
            Cena jednostkowa:
            {{ offer.product.basePrice + 'zł/' + offer.product.baseWeightUnit }}
          </p>
          <p>Zamówiona ilość: {{ `${order.orderQuantity}${offer.product.baseWeightUnit}` }}</p>
          <p>Przewidywany koszt: {{ predictedCost + 'zł' }}</p>
        </div>

        <button class="btn" @click="makeOrder">Złóż zamówienie</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'summary-template',

  computed: {
    ...mapGetters({
      offer: 'offer/GET_OFFER',
      order: 'offer/GET_ORDER',
      userName: 'auth/GET_USERNAME',
    }),

    predictedCost() {
      return (this.offer.product.basePrice * this.order.orderQuantity).toFixed(2);
    },
  },

  methods: {
    ...mapActions({
      makeOrderAsync: 'offer/MAKE_ORDER',
      createCustomer: 'offer/CREATE_CUSTOMER',
    }),

    makeOrder() {
      this.makeOrderAsync({
        offerId: this.offer.id,
        customerName: this.userName,
        orderQuantity: this.order.orderQuantity,
        customAddress: this.order.customAddress,
        orderDetails: this.order.orderDetails,
      });
      this.$router.push({ name: 'my-orders' });
    },
  },

  async created() {
    await this.createCustomer({ userName: this.userName });
  },
};
</script>

<style lang="scss" scoped>
#summary-template {
  display: flex;
  @include container-border;
  width: 50vw;
  height: 60vh;

  #image-place {
    #img {
      width: 20vw;
      height: 60vh;
      object-fit: cover;
    }
  }

  #content {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    width: 30vw;
    background: rgba(231, 231, 231, 0.822);
    height: 60vh;

    #title {
      display: flex;
      flex-direction: column;
      align-items: center;
      color: rgb(112, 112, 112);

      hr {
        border: 2px solid orange;
        width: 20vw;
      }
    }

    #summary-overview {
      padding: 1rem;
      font-size: 1.1rem;
      color: rgb(124, 124, 124);
    }

    .btn {
      padding: 0.7rem;
      font-size: 0.9rem;
      background: none;
      border: 1px solid rgb(145, 145, 145);
      color: rgb(117, 117, 117);
      transition: 0.1s ease-in;
    }

    .btn:hover {
      border: 1px solid orange;
      color: orange;
    }
  }
}

@media screen and(max-width: $tablet) {
}
</style>
