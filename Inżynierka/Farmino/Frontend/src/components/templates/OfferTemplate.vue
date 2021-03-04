<template>
  <div>
    <div id="offer-template">
      <div id="images-place">
        <button id="observe-btn">
          <unicon name="eye" id="eye" fill="#494949" width="40" height="40" />
        </button>
      </div>
      <div id="offer-place">
        <div id="title">
          <h1>{{ offer.title }}</h1>
          <hr />
          <p v-if="offer.farmer">Od: {{ offer.farmer.user.userName }}</p>
          <div id="city-displayer" v-if="offer.farmer">
            <city-displayer
              :lon="offer.farmer.user.profile.address.node.lon"
              :lat="offer.farmer.user.profile.address.node.lat"
            />
          </div>
        </div>

        <div id="description" class="parm-desc">
          <h2>Opis</h2>
          <p>{{ offer.description }}</p>
        </div>

        <div id="details">
          <unicon name="truck" fill="#494949" />
          <h3>Dowóz od</h3>
        </div>

        <div id="make-order" v-if="offer.product">
          <div id="interface">
            <p>
              <strong>{{ `${offer.product.basePrice}zł/${offer.product.baseWeightUnit}` }}</strong>
            </p>
            <input
              type="number"
              name=""
              id=""
              class="small-form-field"
              v-model.number="orderQuantity"
            />
          </div>
          <button
            class="btn"
            id="order"
            @click="setOrderQuantity(orderQuantity),$router.push({ name: 'make-order' })"
          >
            Zamów
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapMutations } from 'vuex';
import CityDisplayer from '../maps/CityDisplayer.vue';

export default {
  name: 'offer-template',

  computed: {
    ...mapGetters({
      offer: 'offer/GET_OFFER',
      userName: 'auth/GET_USERNAME',
    }),
  },

  data() {
    return {
      orderQuantity: 0,
    };
  },

  methods: {
    ...mapMutations({
      setOrderQuantity: 'offer/SET_ORDER_QUANTITY',
    }),
  },

  components: {
    CityDisplayer,
  },
};
</script>

<style lang="scss" scoped>
#offer-template {
  margin: 10rem 0;
  display: flex;
  border: 1px solid rgb(216, 216, 216);
  width: 70vw;
  min-width: 50vw;
  min-height: 80vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  color: rgb(71, 71, 71);

  #offer-place {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    background-color: rgb(243, 243, 243);
    border-bottom: 4px solid orange;

    #title {
      padding: 1rem;
      background-color: rgb(235, 235, 235);

      hr {
        margin-top: 0.4rem;
        color: orange;
        border: 2px solid orange;
        width: 15vw;
      }

      p {
        margin: 0.5rem 0;
        color: rgb(117, 117, 117);
      }

      #city-displayer {
        h2 {
          padding: 1rem 0 1rem 1rem;
        }
      }
    }

    #description {
      display: flex;
      flex-direction: column;
      justify-content: space-between;
      padding: 1rem;

      h2 {
        margin: 0.2rem 0;
        font-size: 1.7rem;
      }

      p {
        margin: 0.7rem 0;
        color: rgb(97, 97, 97);
      }
    }

    #details {
      display: flex;
      padding: 1rem;
    }

    #make-order {
      display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
      padding: 1rem;
      width: 25vw;
      background-color: rgb(235, 235, 235);

      #order {
        width: 24vw;
        font-weight: bold;
      }

      p {
        font-size: 2.2rem;
        color: rgb(233, 153, 4);
      }

      #interface {
        display: flex;
        align-items: center;
        justify-content: space-evenly;
        margin: 1rem 0;
        width: 25vw;
      }
    }
  }

  #images-place {
    background-color: rgb(230, 230, 230);
    width: 50vw;
    border-top: 4px solid orange;

    #observe-btn {
      display: flex;
      align-items: center;
      background: none;
      margin: 1rem;
      font-size: 1rem;
      color: rgb(97, 97, 97);
      padding: 0.2rem;
      border: none;
    }
  }

  .btn {
    padding: 0.5rem;
    background: none;
    border: 1px solid rgb(187, 187, 187);
    font-size: 1rem;
    width: 8vw;
    transition: 0.2s ease-in;
  }

  .btn:hover {
    border: 1px solid orange;
    color: rgb(233, 153, 4);
  }
}

@media screen and(max-width: $tablet) {
  #offer-template {
    flex-direction: column;
    width: 90vw;

    #offer-place {
      width: 90vw;

      #params-description {
        width: 90vw;
        justify-content: center;
      }

      .btn {
        width: 40vw;
      }

      #make-order {
        width: 90vw;

        #order {
          width: 90vw;
          font-weight: bold;
        }

        #interface {
          width: 90vw;
        }
      }
    }

    #images-place {
      height: 50vh;
      width: 90vw;
    }
  }
}
</style>
