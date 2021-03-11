<template>
  <div>
    <div id="order-template">
      <div id="overview">
        <overview-map />
      </div>

      <div id="details">
        <div id="order-details">
          <h1>Szczegóły Zamówienia</h1>
          <hr />

          <div id="content" v-if="order.offer">
            <h2>{{ order.offer.title }}</h2>

            <div id="order">
              <p>Zamówiono: {{ `${order.orderQuantity} ${order.offer.product.baseWeightUnit}` }}</p>
              <p>Data realizacji: {{ order.releaseDate | date }}</p>
              <p>Status: {{ order.orderStatus }}</p>
              <p>Należność: {{ order.priceSummary }} zł</p>
            </div>
          </div>
        </div>

        <div id="address">
          <h1>Adres Klienta</h1>
          <hr />

          <div id="content" v-if="order.orderDetails">
            <p>{{ `${order.orderDetails.firstName} ${order.orderDetails.lastName}` }}</p>
            <p>
              {{ `${order.orderDetails.address.street} ${order.orderDetails.address.houseNumber}` }}
            </p>
            <p>
              {{ `${order.orderDetails.address.postalCode} ${order.orderDetails.address.city}` }}
            </p>
            <p id="phone-number">
              <unicon name="phone" fill="#494949" />{{ order.orderDetails.phoneNumber }}
            </p>
          </div>
        </div>

        <div
          id="interface"
          v-if="order.orderStatus === 'Oczekujaca' || order.orderStatus === 'Odrzucona'"
        >
          <button class="btn" @click="release">
            Przyjmij
          </button>
          <button class="btn" @click="revoke">Odrzuć</button>
        </div>

        <div id="interface" v-else>
          <button class="btn" @click="release">
            Przenieś Termin
          </button>
          <button class="btn" @click="deliver">Dostarczona</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import OverviewMap from '../maps/OverviewMap.vue';

export default {
  name: 'order-template',

  props: {
    id: {
      type: String,
      required: true,
    },
  },

  components: {
    OverviewMap,
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

  computed: {
    ...mapGetters({
      order: 'order/GET_ORDER',
      user: 'user/GET_STATE_USER',
    }),
  },

  methods: {
    ...mapActions({
      cancelOrder: 'order/CANCEL_ORDER',
      deliverOrder: 'order/DELIVER_ORDER',
    }),

    async revoke() {
      this.cancelOrder({ orderId: this.id });
      this.$router.push({ name: 'my-delivers' });
    },

    async release() {
      this.$router.push({ name: 'order-release', params: { id: this.id } });
    },

    async deliver() {
      this.deliverOrder({ orderId: this.id });
      this.$router.push({ name: 'my-delivers' });
    },
  },

  async created() {
    await this.$store.dispatch('order/GET_ORDER', this.id);
    await this.$store.dispatch('direction/GET_ROUTE_NODES', {
      farmerNodes: this.user.profile.address.node,
      clientNodes: this.order.orderDetails.address.node,
    });
  },

  destroyed() {
    this.$store.commit('direction/SET_CLIENT_GEONODE', []);
    this.$store.commit('order/SET_ORDER', {});
  },
};
</script>

<style lang="scss" scoped>
#order-template {
  margin: 10rem 0;
  display: flex;
  border: 1px solid rgb(216, 216, 216);
  width: 60vw;
  min-width: 40vw;
  height: 72vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  color: rgb(102, 102, 102);

  #details {
    display: flex;
    flex-direction: column;
    justify-content: space-around;
    background: rgba(243, 243, 243, 0.883);

    #order-details {
      min-height: 20vh;
      width: 20vw;
      padding: 1rem;
      display: flex;
      flex-direction: column;
    }

    #address {
      min-height: 20vh;
      width: 20vw;
      padding: 1rem;
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-self: center;

      #phone-number {
        margin-top: 0.3rem;
        display: flex;
        width: 20vw;
        align-self: flex-start;
      }
    }

    hr {
      margin-top: 0.4rem;
      margin-bottom: 0.7rem;
      color: orange;
      border: 2px solid orange;
      width: 15vw;
    }

    #interface {
      min-height: 20vh;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: space-evenly;
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
    color: rgb(90, 90, 90);
    background: none;
  }

  #overview {
    height: 72vh;
    width: 40vw;
    background: rgb(206, 206, 206);
  }
}

@media screen and(max-width: $tablet) {
  #order-template {
    margin: 8rem 0 24rem 0;
    flex-direction: column;
    width: 80vw;

    #details {
      width: 80vw;

      #order-details {
        display: flex;
        padding: 0;
        text-align: center;
        align-items: center;
        width: 80vw;
      }

      #address {
        display: flex;
        padding: 0;
        text-align: center;
        align-items: center;
        width: 80vw;

        #content {
          width: 80vw;

          #phone-number {
            justify-content: center;
            width: 80vw;
          }
        }
      }
    }

    .btn {
      width: 75vw;
    }

    #overview {
      width: auto;
    }
  }
}
</style>
