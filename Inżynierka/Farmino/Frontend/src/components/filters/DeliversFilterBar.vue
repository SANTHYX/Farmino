<template>
  <div>
    <div id="delivers-filter-bar">
      <h1>Filtry</h1>
      <div id="inputs-wraper">
        <label for="date" id="data-lable" class="form-label">Data realizacji</label>
        <input type="date" name="date" id="datepicker" class="small-form-field" v-model="date" />
      </div>

      <div id="inputs-wraper">
        <label for="order-status" id="order-status-lable" class="form-label"
          >Status Zamówienia</label
        >
        <select
          name="order-status"
          id="order-status"
          class="small-form-field"
          v-model="orderStatus"
        >
          <option value="Oczekujaca">Oczekująca</option>
          <option value="Przyjeta">Przyjęta</option>
          <option value="Odrzucona">Odrzucona</option>
          <option value="Dostarczona">Dostarczona</option>
        </select>
      </div>

      <div id="inputs-wraper">
        <label for="date" id="customer-name-label" class="form-label">Nazwa Klienta</label>
        <input
          type="text"
          name="customerName"
          id="customerName"
          class="small-form-field"
          v-model="customerName"
        />
      </div>

      <button @click="search" id="btn">Szukaj</button>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
  name: 'delivers-filter-list',

  data() {
    return {
      date: '',
      orderStatus: '',
      customerName: '',
    };
  },

  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      getOrders: 'order/GET_ORDERS',
    }),

    search() {
      this.getOrders({
        date: this.date,
        farmerName: this.userName,
        customerName: this.customerName,
        orderStatus: this.orderStatus,
      });
      this.$router.replace({
        query: { date: this.date, customerName: this.customerName, orderStatus: this.orderStatus },
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#delivers-filter-bar {
  margin: 10rem 0 2rem 0;
  display: flex;
  align-items: center;
  justify-content: space-around;
  flex-wrap: wrap;
  padding: 0.7rem;
  border: 1px solid rgb(223, 223, 223);
  width: 70vw;

  #inputs-wraper {
    display: flex;
    flex-direction: column;

    .form-label {
      margin-top: 0;
      font-size: 1.05rem;
      color: #615f5f;
    }

    .small-form-field {
      text-align: center;
    }
  }

  #btn {
    margin-top: 0.5rem;
    width: 134px;
    height: 27px;
  }
}
</style>
