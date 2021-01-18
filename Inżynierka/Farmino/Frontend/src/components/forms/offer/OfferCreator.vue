<template>
  <div>
    <div id="offer-creator">
      <div id="title-editor">
        <div id="title-wraper">
          <label for="userName" class="form-label">Tytuł</label>
          <div id="inputs-wraper">
            <input type="text" name="userName" class="form-field" v-model="$v.offer.title.$model" />
          </div>
        </div>
      </div>
      <div id="product-editor">
        <div id="product-wraper">
          <div id="inputs-wraper">
            <h2>Cena za sztukę</h2>
            <label for="userName" class="form-label">Cena</label>
            <input
              type="text"
              name="price"
              class="form-field"
              v-model.number="$v.offer.product.basePrice.$model"
            />
          </div>
          <div id="inputs-wraper">
            <label for="userName" class="form-label">Bazowa jednostka</label>
            <select class="form-field" v-model.number="$v.offer.product.baseWeightUnit.$model">
              <option value="0">mg</option>
              <option value="1">dkg</option>
              <option value="2">g</option>
              <option value="3">kg</option>
              <option value="4">T</option>
            </select>
          </div>
          <div id="inputs-wraper">
            <h2>Minimalny półap zamówienia</h2>
            <label for="userName" class="form-label">Ilość</label>
            <input
              type="text"
              name="userName"
              class="form-field"
              v-model.number="$v.offer.minQuantity.$model"
            />
          </div>
        </div>
      </div>
      <div id="description-editor">
        <div id="title-wraper">
          <h1>Dodaj Opis</h1>
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
        </div>
      </div>
      <photo-editor />
      <button @click="create" :disabled="$v.offer.$invalid">Stwórz</button>
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
  components: {
    PhotoEditor: () => import('./editors/PhotoEditor.vue'),
  },

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
#inputs-wraper {
  display: flex;
  flex-direction: column;
}
</style>
