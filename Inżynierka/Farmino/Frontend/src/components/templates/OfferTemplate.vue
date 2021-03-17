<template>
  <div>
    <div id="offer-template">
      <div id="images-place">
        <img
          :src="`http://localhost:4800/Images/Offer/${offer.imageName}`"
          :alt="offer.imageName"
          id="img"
        />
      </div>

      <div id="offer-place">
        <div id="title">
          <div id="title-wraper">
            <h1>{{ offer.title }}</h1>
            <button id="observe-btn" @click="observeOffer({ userName, offerId: offer.id })">
              <unicon name="eye" id="eye" fill="#494949" width="35" height="35" />
            </button>
          </div>

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

        <div id="details" v-if="offer.product">
          <unicon name="truck" fill="#494949" />
          <h3>Realizacja Od: {{ `${offer.minQuantity}${offer.product.baseWeightUnit}` }}</h3>
        </div>

        <div id="make-order" v-if="offer.product">
          <div id="interface">
            <div>
              <label><strong>Cena</strong></label>
              <p>
                <strong>{{
                  `${offer.product.basePrice} zł/${offer.product.baseWeightUnit}`
                }}</strong>
              </p>
            </div>

            <div id="buy" v-if="offer.product">
              <label
                ><strong>Kup({{ offer.product.baseWeightUnit }})</strong></label
              >
              <input type="number" class="small-form-field" v-model.number="orderQuantity" />
              <label>Należność: {{ orderQuantity * offer.product.basePrice }} zł</label>
            </div>
          </div>

          <button
            class="btn"
            id="order"
            :disabled="!offer.isActive || orderQuantity <= offer.minQuantity"
            @click="setOrderQuantity(orderQuantity), $router.push({ name: 'make-order' })"
          >
            Zamów
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapMutations, mapActions } from 'vuex';
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
    ...mapActions({
      observeOffer: 'offer/OBSERVE_OFFER',
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
  width: 60vw;
  min-width: 50vw;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  color: rgb(71, 71, 71);

  #offer-place {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    background-color: rgba(243, 243, 243, 0.87);
    border-bottom: 4px solid orange;

    #title {
      padding: 1rem;
      background-color: rgba(235, 235, 235, 0.876);

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

      #title-wraper {
        display: flex;
        justify-content: space-between;

        #observe-btn {
          display: flex;
          align-items: center;
          padding: 0 0.2rem;
          background: none;
          border: none;
          cursor: pointer;
        }
      }
    }

    #description {
      display: flex;
      flex-direction: column;
      justify-content: space-between;
      word-break: break-all;
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
      padding: 0 1rem;
    }

    #make-order {
      display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
      padding: 1rem;
      width: 25vw;
      background-color: rgba(235, 235, 235, 0.897);

      #order {
        width: 24vw;
        font-weight: bold;
      }

      p {
        font-size: 1.8rem;
        color: rgb(129, 129, 129);
      }

      #interface {
        display: flex;
        padding: 1rem;
        align-items: center;
        justify-content: space-between;
        width: 25vw;

        #buy {
          display: flex;
          flex-direction: column;

          input {
            font-size: 1rem;
          }
        }
      }
    }
  }

  #images-place {
    background-color: rgb(121, 121, 121);
    border-top: 4px solid orange;
    width: 40vw;

    #img {
      width: 40vw;
      height: 83vh;
      object-fit: fill;
    }
  }

  .btn {
    padding: 0.5rem;
    background: none;
    border: 1px solid rgb(187, 187, 187);
    font-size: 1rem;
    width: 8vw;
    color: rgb(255, 255, 255);
    background: rgb(233, 153, 4);
    transition: 0.2s ease-in;
  }

  .btn:hover {
    border: 1px solid orange;
    color: orange;
    background: none;
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

      #description {
        width: 80vw;
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

    .btn {
      width: 30vw;
    }

    #images-place {
      height: 50vh;
      width: 90vw;

      #img {
        height: 50vh;
        width: 90vw;
        object-fit: fill;
      }
    }
  }
}
</style>
