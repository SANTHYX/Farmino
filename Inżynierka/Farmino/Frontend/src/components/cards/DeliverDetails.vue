<template>
  <div>
    <div id="deliver-details">
      <h1>Szczegóły</h1>
      <hr />

      <div>
        <h2></h2>
      </div>

      <div>
        <h2>Adres Klienta</h2>
        <p>{{ `${order.orderDetails.firstName} ${order.orderDetails.lastName}` }}</p>
        <p>
          {{ `${order.orderDetails.address.street} ${order.orderDetails.address.houseNumber}` }}
        </p>
        <p>{{ `${order.orderDetails.address.city} ${order.orderDetails.address.postalCode}` }}</p>
      </div>
      <button @click="checkDeliveryOrdersList">Wróć</button>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'delivery-details',

  props: {
    id: {
      type: String,
      required: true,
    },
  },

  computed: {
    ...mapGetters({
      order: 'order/GET_ORDER',
    }),
  },

  methods: {
    checkDeliveryOrdersList() {
      this.$router.push({ name: 'daily-delivers' });
    },
  },

  created() {
    this.$store.dispatch('order/GET_ORDER', this.id);
  },
};
</script>

<style lang="scss" scoped>
#deliver-details {
  margin: 12rem 0;
  display: flex;
  flex-direction: column;
  align-items: center;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  min-width: 20vw;
  min-height: 70vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);

  h1 {
    margin: 0.75rem 0 0 0;
    color: rgb(51, 51, 51);
  }

  hr {
    width: 200px;
    color: rgb(228, 228, 228);
    margin: 0 0 1rem 0;
  }
}
</style>
