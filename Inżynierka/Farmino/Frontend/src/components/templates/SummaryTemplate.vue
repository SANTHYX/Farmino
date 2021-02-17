<template>
  <div>
    <div id="summary-template">
      <div id="column-setup">
        <div id="row-setup">
          <div id="img-wraper"></div>

          <div id="offer-wraper">
            <h1>{{ offer.title }}</h1>
            <div id="details">
              <p>
                Cena jednostkowa:
                {{ offer.product.basePrice + 'zł/' + offer.product.baseWeightUnit }}
              </p>
              <p>Zamówiona ilość: {{ `${order.orderQuantity}${offer.product.baseWeightUnit}` }}</p>
              <p>Przewidywany koszt: {{ predictedCost + 'zł' }}</p>
            </div>

            <div>
              <button @click="makeOrder">Zamów</button>
            </div>
          </div>
        </div>
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

    async makeOrder() {
      await this.makeOrderAsync({
        offerId: this.offer.id,
        customerName: this.userName,
        orderQuantity: this.order.orderQuantity,
        customAddress: this.order.customAddress,
        orderDetails: this.order.orderDetails,
      });
    },
  },

  async created() {
    await this.createCustomer({ userName: this.userName });
  },
};
</script>

<style lang="scss" scoped>
#summary-template {
  margin: 12rem 0;
  padding: 0.2rem;
  border: 1px solid rgb(196, 196, 196);
  box-shadow: 1px 1px 6px rgb(179, 179, 179);
  border-radius: 10px;

  #column-setup {
    display: flex;
    flex-direction: column;

    #row-setup {
      display: flex;
      justify-content: center;

      #img-wraper {
        width: 25vw;
        height: 47vh;
        background: rgb(211, 211, 211);
        border-radius: 10px;
      }

      #offer-wraper {
        display: flex;
        flex-direction: column;
        justify-content: space-around;
        align-items: center;
        margin: 0 0.5rem;

        h1 {
          text-align: center;
          width: 20vw;
          padding: 0.2rem;
        }

        #details {
          text-align: center;
          margin: 0.5rem 0;
        }
      }
    }
  }
}

@media screen and(max-width: $tablet) {
  #offer-template {
    margin: 12rem 0;

    #column-setup {
      #row-setup {
        flex-direction: column;
        align-items: center;
        #img-wraper {
          width: 80vw;
        }

        #offer-wraper {
          width: 70vw;
          text-align: center;

          h1 {
            width: 60vw;
          }

          #farmer-widget {
            width: 75vw;
          }
        }
      }
    }
  }
}
</style>
