<template>
  <div>
    <div id="offer-template">
      <div id="column-setup">
        <div id="row-setup">
          <div id="img-wraper"></div>
          <div id="offer-wraper">
            <h1>{{ offer.title }}</h1>
            <div id="price">
              <h2>
                {{ offer.product.basePrice + 'zł/' + offer.product.baseWeightUnit }}
              </h2>
              <order-maker />
            </div>
            <div id="details">
              <p>Dostawa od: {{ offer.minQuantity + offer.product.baseWeightUnit }}</p>
            </div>
            <div id="farmer-widget">
              <h3>{{ offer.farmer.user.userName }}</h3>
              <city-displayer />
            </div>
          </div>
        </div>
        <div id="descriptions">
          <h2>Opis Oferty</h2>
          <p>{{ offer.description }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import OrderMaker from '../forms/order/OrderMaker.vue';
import CityDisplayer from '../maps/CityDisplayer.vue';

export default {
  name: 'offer-template',

  components: {
    CityDisplayer,
    OrderMaker,
  },

  computed: {
    ...mapGetters({
      offer: 'offer/GET_OFFER',
    }),
  },
};
</script>

<style lang="scss" scoped>
#offer-template {
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
        justify-content: space-between;
        align-items: center;
        margin: 0 0.5rem;

        h1 {
          text-align: center;
          width: 20vw;
          padding: 0.2rem;
        }

        #farmer-widget {
          display: flex;
          flex-direction: column;
          text-align: center;
          border-radius: 10px;
          border: 1px solid rgb(202, 202, 202);
          margin: 0.5rem 0;
        }

        #details {
          text-align: center;
          margin: 0.5rem 0;
        }

        #price {
          display: flex;
          flex-direction: column;
          text-align: center;
          margin: 0.5rem 0;

          h2 {
            font-size: 1.7rem;
          }
        }
      }
    }
    #descriptions {
      margin: 0.5rem 0;
      padding: 0.2rem;
      border: 1px solid rgb(196, 196, 196);
      border-radius: 10px;
      text-align: center;

      h2 {
        margin: 0.5rem 0;
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
            width: 70vw;
          }
        }
      }
    }
  }
}
</style>
