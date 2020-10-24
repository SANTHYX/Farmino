<template>
  <div id="address-input">
    <label for="city" class="form-label">Miejscowość</label>
    <input
      type="text"
      name="city"
      id="city-input"
      class="form-field"
      placeholder="Warszawa"
      v-model="city"
    />
    <label for="street" class="form-label">Ulica</label>
    <input
      type="text"
      name="street"
      id="street-input"
      class="form-field"
      placeholder="Kaliska"
      v-model="street"
    />
    <label for="postalcode" class="form-label">Kod Pocztowy</label>
    <input
      type="text"
      name="postalcode"
      id="postalcode-input"
      class="form-field"
      placeholder="21-345"
      v-model="postalCode"
    />
    <label for="housenumber" class="form-label">Nr.Domu</label>
    <input
      type="text"
      name="housenumber"
      id="housenumber-input"
      class="form-field"
      placeholder="8"
      v-model="houseNumber"
    />
  </div>
</template>

<script>
import { required } from 'vuelidate/lib/validators';

export default {
  name: 'address-input',
  data() {
    return {
      address: {
        city: '',
        street: '',
        postalCode: '',
        houseNumber: '',
      },
    };
  },
  validations: {
    address: {
      city: { required },
      street: { required },
      postalCode: { required },
      houseNumber: { required },
    },
  },
  validationGroup: ['address.city', 'address.street', 'address.postalCode', 'address.houseNumber'],
  methods: {
    IsAddressValid() {
      this.$emit('IsAddressValid', this.$v.$invalid());
      console.log('Invoked passing boolean value about address validation result to Parent!');
    },
  },
  beforeDestroy() {
    this.IsAddressValid();
  },
};
</script>

<style lang="scss" scoped>
#address-input {
  display: flex;
  flex-direction: column;
}
</style>
