<template>
  <div>
    <div id="offer-list-item" :offerItem="offerItem">
      <div id="offer-img">
        <img
          :src="`http://localhost:4800/Images/Offer/${offerItem.imageName}`"
          :alt="offerItem.imageName"
          id="img"
        />
      </div>
      <div id="offer-detail">
        <h2>{{ offerItem.title }}</h2>

        <div id="region" v-if="offerItem.farmer">
          <unicon name="globe" fill="gray" width="23" />
          <p id="region-value">
            {{ offerItem.region }}, {{ offerItem.farmer.user.profile.address.city }}
          </p>
        </div>
      </div>

      <div id="price-details">
        <h2>{{ `${offerItem.product.basePrice}zł/${offerItem.product.baseWeightUnit}` }}</h2>
        <div id="btn-wraper">
          <button
            id="btn"
            @click="$router.push({ name: 'offer-editor', params: { id: offerItem.id } })"
          >
            Edytuj
          </button>

          <button id="btn" @click="deactivateOffer({ id: offerItem.id, userName })">
            Deaktywuj
          </button>

          <button id="btn" @click="$router.push({ name: 'offer', params: { id: offerItem.id } })">
            Sprawdź
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
  name: 'offer-list-item',

  props: {
    offerItem: {
      type: Object,
      required: true,
    },
  },

  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      deactivateOffer: 'offer/DEACTIVATE_OFFER',
    }),
  },
};
</script>

<style lang="scss" scoped>
#offer-list-item {
  display: flex;
  flex-direction: column;
  justify-content: center;
  margin: 1rem;
  border: 1px solid rgb(177, 177, 177);
  background: rgb(245, 245, 245);
  width: 19vw;
  min-width: 240px;
  box-shadow: 1px 1px 6px rgb(179, 179, 179);
  transition: 0.1s all;

  #offer-img {
    height: 250px;
    width: 18.9vw;
    min-width: 240px;
    align-self: center;
    background: rgb(192, 192, 192);
    transition: 0.1s all;

    #img {
      height: 250px;
      width: 18.9vw;
    }
  }

  #offer-detail {
    display: flex;
    flex-direction: column;
    padding: 1rem;

    #region {
      display: flex;
      align-items: center;

      p {
        color: rgb(73, 73, 73);
      }
    }

    h2 {
      color: rgb(73, 73, 73);
    }
  }

  #price-details {
    display: flex;
    justify-content: space-between;
    align-items: flex-end;
    padding: 1rem;

    h2 {
      color: rgb(73, 73, 73);
      font-size: 1.3rem;
    }

    #btn-wraper {
      display: flex;
      flex-wrap: wrap;
      justify-content: flex-end;

      #btn {
        background: none;
        padding: 0.4rem;
        margin-top: 0.2rem;
        cursor: pointer;
        width: 6vw;
        border: 1px solid rgb(185, 185, 185);
        font-size: 0.9rem;
      }

      #btn:hover {
        transition: 0.3s ease-in;
        background: none;
        border: 1px solid orange;
        color: rgb(233, 153, 4);
      }
    }
  }
}

#offer-list-item:hover {
  box-shadow: 1px 1px 12px rgb(156, 156, 156);
  transform: translateY(-5px);
  transition: all 0.3s ease;
  border-bottom: orange 5px solid;
}

@media screen and(max-width: $tablet) {
  #offer-list-item {
    width: 73vw;

    #offer-img {
      width: 73vw;
    }

    #price-details {
      #btn-wraper {
        flex-wrap: wrap;
        justify-content: flex-end;
        flex-direction: row;

        #btn {
          width: 20vw;
        }
      }
    }
  }
}
</style>
