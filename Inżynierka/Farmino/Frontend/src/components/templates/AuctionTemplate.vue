<template>
  <div>
    <div id="offer-template">
      <div id="images-place"></div>
      <div id="offer-place">
        <div id="title" v-if="auction.auctioner">
          <h1>{{ auction.title }}</h1>
          <hr />
          <p>Od: {{ auction.auctioner.user.userName }}</p>
          <div id="city-displayer">
            <city-displayer :lon="0.0" :lat="0.0" />
          </div>
        </div>

        <div id="params-description">
          <div>
            <button class="btn" @click="showParamsSection = false">Opis</button>
            <button class="btn" @click="showParamsSection = true">Parametry</button>
          </div>

          <div id="description" v-if="!showParamsSection">
            <h2>Opis</h2>
            <p>{{ auction.description }}</p>
          </div>

          <div id="params" v-else>
            <h2>Parametry</h2>
            <p></p>
          </div>
        </div>

        <div id="details"></div>

        <div id="make-order">
          <div id="interface">
            <p>
              <strong>{{ auction.startingPrice }}</strong>
            </p>
            <input type="number" name="" id="" class="small-form-field" />
          </div>
          <button class="btn" id="order" @click="$router.push({ name: 'make-order' })">
            Zamów
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import { decimal, required } from 'vuelidate/lib/validators';
import CityDisplayer from '../maps/CityDisplayer.vue';

export default {
  name: 'auction-template',

  data() {
    return {
      proposedPrice: undefined,
      showParamsSection: false,
    };
  },

  validations: {
    proposedPrice: { required, decimal },
  },

  computed: {
    ...mapGetters({
      auction: 'auction/GET_AUCTION',
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      toAuction: 'auction/TO_AUCTION',
    }),

    toAuctionAsync() {
      this.toAuction({
        userName: this.userName,
        auctionId: this.auction.id,
        proposedPrice: this.proposedPrice,
      });
    },
  },

  components: {
    CityDisplayer,
  },

  async created() {
    await this.$store.dispatch('auction/CREATE_PARTICIPANT', this.$store.state.auth.userName);
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
    flex-wrap: wrap;
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

      #city-displayer {
        h2 {
          padding: 1rem 0 1rem 1rem;
        }
      }
    }

    #params-description {
      display: flex;
      flex-direction: column;
      padding: 1rem;
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

    #description {
      width: 20vw;
      margin: 1rem 0;
      word-break: break-all;

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

      #description {
        width: 80vw;
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
