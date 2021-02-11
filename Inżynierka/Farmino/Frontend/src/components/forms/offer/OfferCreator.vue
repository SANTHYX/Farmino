<template>
  <div>
    <div id="offer-creator">
      <div id="left">
        <label for="userName" class="form-label">Tytuł</label>
        <div id="inputs-wraper">
          <input type="text" name="userName" class="form-field" v-model="$v.offer.title.$model" />
        </div>
        <label for="userName" class="form-label">Cena jednostkowa</label>
        <div id="inputs-wraper">
          <input
            type="number"
            name="userName"
            class="form-field"
            v-model.number="$v.offer.product.basePrice.$model"
          />
        </div>
        <label for="userName" class="form-label">Jednostka Wagi</label>
        <div id="inputs-wraper">
          <select class="form-field" v-model.number="$v.offer.product.baseWeightUnit.$model">
            <option value="0">mg</option>
            <option value="1">dkg</option>
            <option value="2">g</option>
            <option value="3">kg</option>
            <option value="4">T</option>
          </select>
        </div>
        <div id="inputs-wraper">
          <label for="userName" class="form-label">Ilość</label>
          <input
            type="text"
            name="userName"
            class="form-field"
            v-model.number="$v.offer.minQuantity.$model"
          />
        </div>
        <div id="inputs-wraper">
          <label for="userName" class="form-label">Opis oferty</label>
          <textarea
            name=""
            class="form-field"
            cols="30"
            rows="10"
            v-model="$v.offer.description.$model"
          ></textarea>
        </div>
        <button @click="create" :disabled="$v.offer.$invalid">Stwórz</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import {
  required, minValue, maxValue, decimal,
} from 'vuelidate/lib/validators';

export default {
  name: 'offer-creator',

  data() {
    return {
      offer: {
        title: '',
        description: '',
        minQuantity: 0,
        product: {
          basePrice: 0,
          baseWeightUnit: 0,
        },
      },
    };
  },

  validations: {
    offer: {
      title: { required },
      description: { required },
      minQuantity: { required, minValue: minValue(1) },
      product: {
        basePrice: { required, decimal, minValue: minValue(1) },
        baseWeightUnit: { required, minValue: minValue(0), maxValue: maxValue(4) },
      },
    },
  },

  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      createOffer: 'offer/CREATE_OFFER',
    }),

    create() {
      this.createOffer({
        userName: this.userName,
        title: this.offer.title,
        description: this.offer.description,
        minQuantity: this.offer.minQuantity,
        product: this.offer.product,
      });
    },
  },

  async beforeCreate() {
    this.$store.dispatch('offer/CREATE_FARMER', { userName: this.$store.state.auth.userName });
  },
};
</script>

<style lang="scss" scoped>
#offer-creator {
  padding: 1rem;
  display: flex;
  flex-direction: column;
  align-items: center;

  #inputs-wraper {
    display: flex;
    flex-direction: column;
    button {
      background: none;
    }
  }
}
</style>
