<template>
  <div>
    <div id="delivers-filter-bar">
      <div id="header">
        <unicon name="filter" height="40" width="40" fill="#615f5f" />
        <h1>Filtry</h1>
      </div>

      <div id="inputs">
        <div id="inputs-wraper">
          <label for="date" id="data-lable" class="form-label">Data realizacji</label>
          <input
            type="date"
            name="date"
            id="datepicker"
            class="small-form-field"
            v-model="query.date"
          />
        </div>

        <div id="inputs-wraper">
          <label for="order-status" id="order-status-lable" class="form-label"
            >Status Zamówienia</label
          >
          <select
            name="order-status"
            id="order-status"
            class="small-form-field"
            v-model="query.orderStatus"
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
            v-model="query.customerName"
          />
        </div>

        <button @click="search" id="btn">Szukaj</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
  name: 'delivers-filter-list',

  data() {
    return {
      query: {
        date: undefined,
        orderStatus: undefined,
        customerName: undefined,
      },
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
      this.$router.replace({ query: { ...this.query } });
      this.getOrders({ farmerName: this.userName, ...this.query });
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
  border: 1px solid rgb(223, 223, 223);
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
  background: rgba(246, 246, 246, 0.897);
  width: 80vw;

  #header {
    padding: 0.7rem;
    display: flex;
    justify-content: flex-start;
    background: rgb(235, 235, 235);
    border-bottom: 1px solid rgb(223, 223, 223);
    box-shadow: 0 2px 1px rgba(211, 211, 211, 0.39);
    width: 80vw;
    color: rgb(100, 100, 100);
  }

  #inputs {
    padding: 0.7rem;
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    width: 70vw;
    flex-wrap: wrap;

    #inputs-wraper {
      display: flex;
      flex-direction: column;

      .form-label {
        align-self: center;
        margin-top: 0;
        font-size: 1.05rem;
        color: #615f5f;
      }

      .small-form-field {
        text-align: center;
        font-size: 1rem;
      }
    }

    #btn {
      align-self: flex-end;
      margin-top: 0.5rem;
      width: 134px;
      height: 35px;
      background: none;
      border: 1px solid rgb(197, 197, 197);
      transition: 0.2s ease-in;
      font-size: 0.9rem;
    }

    #btn:hover {
      color: orange;
      border: 1px solid orange;
    }
  }
}

@media screen and(max-width: $tablet) {
  #delivers-filter-bar {
    margin: 8rem 0 1rem 0;
    width: 80vw;

    #header {
      width: 80vw;
    }
  }
}
</style>
