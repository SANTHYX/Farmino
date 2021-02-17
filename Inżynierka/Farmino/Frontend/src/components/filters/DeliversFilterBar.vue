<template>
  <div>
    <div id="delivers-filter-bar">
      <div id="row">
        <div id="inputs-wraper">
          <label for="date" id="data-lable">Data realizacji</label>
          <input type="date" name="date" id="datepicker" class="small-form-field" v-model="date" />
        </div>
        <div id="inputs-wraper">
          <label for="date" id="data-lable">Status Zamówienia</label>
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
          <label for="date" id="data-lable">Nazwa Klienta</label>
          <input
            type="text"
            name="customerName"
            id="customerName"
            class="small-form-field"
            v-model="customerName"
          />
        </div>
      </div>
      <button @click="fetchData" id="btn">Szukaj</button>
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

    fetchData() {
      this.getOrders({
        date: this.date,
        farmerName: this.userName,
        customerName: this.customerName,
        orderStatus: this.orderStatus,
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#delivers-filter-bar {
  margin: 12rem 0 2rem 0;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  flex-wrap: wrap;
  padding: 1rem;
  border: 1px solid rgb(223, 223, 223);

  #row {
    display: flex;
    justify-content: space-evenly;
    width: 70vw;
    #inputs-wraper {
      display: flex;
      flex-direction: column;

      #data-lable {
        font-size: 1.05rem;
        margin-bottom: 0.3rem;
        margin-left: 0.3rem;
        color: #615f5f;
      }
      .small-form-field {
        text-align: center;
      }
    }
  }
}
</style>
