<template>
  <div>
    <div id="offer-template">
      <div id="column-setup">
        <div id="row-setup">
          <div id="img-wraper"></div>
          <div id="offer-wraper">
            <h1>{{ offer.title }}</h1>
            <div id="informations">
              <div id="price"></div>
              <h2>Cena</h2>
              <h2>{{ offer.product.basePrice + 'zł/' + offer.product.baseWeightUnit }}</h2>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'offer-template',

  computed: {
    ...mapGetters({
      offer: 'offer/GET_OFFER',
    }),
  },
};
</script>

<style lang="scss" scoped>
#offer-template {
  padding: 0.2rem;
  border: 1px solid grey;

  #column-setup {
    display: flex;
    flex-direction: column;

    #row-setup {
      display: flex;
      justify-content: center;

      #img-wraper {
        width: 30vw;
        height: 60vh;
        background: rgb(146, 146, 146);
      }

      #offer-wraper {
        margin: 0 0.5rem;
        h1 {
          text-align: center;
          width: 20vw;
          padding: 0.2rem;
          border: 1px solid grey;
        }
      }

      #informations {
        margin: 0 0.5rem;
        display: flex;
        align-items: center;
        flex-direction: column;

        #price {
          display: flex;
          flex-direction: column;
        }
      }
    }
  }
}

@media screen and(max-width: $tablet) {
  #offer-template {
    #column-setup {
      #row-setup {
        flex-direction: column;
      }
    }
  }
}
</style>
