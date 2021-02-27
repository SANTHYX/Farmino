<template>
  <div>
    <div id="offer-template">
      <div id="images-place"></div>
      <div id="offer-place">
        <div id="title">
          <h1>{{ offer.title }}</h1>
          <hr />
          <p>Od: {{ offer.farmer.user.userName }}</p>
        </div>

        <div id="params-description">
          <div>
            <button class="btn" @click="showParamsSection = false">Opis</button>
            <button class="btn" @click="showParamsSection = true">Parametry</button>
          </div>

          <div id="description" class="parm-desc" v-if="!showParamsSection">
            <h2>Opis</h2>
            <p>{{ offer.description }}</p>
          </div>

          <div id="params" class="parm-desc" v-else>
            <h2>Parametry</h2>
            <p></p>
          </div>
        </div>

        <div id="details">
          <unicon name="truck" fill="#494949" />
          <h3>Dowóz od</h3>
        </div>

        <div id="make-order">
          <div id="interface">
            <p>
              <strong>{{ `${offer.product.basePrice}zł/${offer.product.baseWeightUnit}` }}</strong>
            </p>
            <input type="number" name="" id="" class="small-form-field" />
          </div>
          <button class="btn" id="order">Zamów</button>
        </div>

        <div id="city-displayer">
          <div id="location">
            <h2>Lokalizacja</h2>
            <unicon name="map-marker-info" />
          </div>
          <city-displayer
            :lon="offer.farmer.user.profile.address.node.lon"
            :lat="offer.farmer.user.profile.address.node.lat"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import CityDisplayer from '../maps/CityDisplayer.vue';

export default {
  name: 'offer-template',

  data() {
    return {
      showParamsSection: false,
    };
  },

  computed: {
    ...mapGetters({
      offer: 'offer/GET_OFFER',
      userName: 'auth/GET_USERNAME',
    }),
  },

  components: {
    CityDisplayer,
  },
};
</script>

<style lang="scss" scoped>
#offer-template {
  margin: 12rem 0;
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
    border-bottom: 4px solid rgb(233, 153, 4);

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
    }

    #params-description {
      display: flex;
      flex-direction: column;
      padding: 1rem;

      .parm-desc {
        margin: 1rem 0;

        h2 {
          margin: 0.2rem 0;
          font-size: 1.7rem;
        }

        p {
          margin: 0.7rem 0;
          color: rgb(97, 97, 97);
        }
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

    #city-displayer {
      h2 {
        padding: 1rem 0 1rem 1rem;
      }

      #location {
        display: flex;
        align-items: center;
      }
    }
  }

  #images-place {
    background-color: rgb(230, 230, 230);
    width: 50vw;
    border-top: 4px solid rgb(233, 153, 4);
  }

  .btn {
    padding: 0.5rem;
    background: none;
    border: 1px solid rgb(216, 216, 216);
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
      height: 40vh;
      width: 90vw;
    }
  }
}
</style>
