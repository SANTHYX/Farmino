<template>
  <div>
    <div id="order-maker">
      <input
        type="number"
        name="order-maker"
        id="order-maker"
        step=".01"
        class="small-form-field"
        v-model.number="$v.orderQuantity.$model"
      />
      <button @click="moveToMakeOrder" :disabled="$v.orderQuantity.$invalid">Zamów</button>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import { decimal, required } from 'vuelidate/lib/validators';

export default {
  name: 'order-maker',

  data() {
    return {
      orderQuantity: 0,
    };
  },

  computed: {
    ...mapGetters({
      minQuantity: 'offer/GET_MIN_QUANTITY',
    }),
  },

  validations: {
    orderQuantity: {
      required,
      decimal,
      greatherEqualMin(value) {
        return value >= this.minQuantity;
      },
    },
  },

  methods: {
    moveToMakeOrder() {
      this.$router.push({ name: 'make-order' });
      this.$store.commit('offer/SET_ORDER_QUANTITY', this.orderQuantity);
    },
  },
};
</script>

<style lang="scss" scoped>
#order-maker {
  margin: 0.3rem 0;
  display: flex;
  flex-direction: column;
}
</style>
