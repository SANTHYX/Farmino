<template>
  <div id="address-input">
    <label for="city" class="form-label">Miejscowość</label>
    <input type="text" name="city" id="city-input" class="form-field" placeholder="Warszawa" />
    <label for="street" class="form-label">Ulica</label>
    <input type="text" name="street" id="street-input" class="form-field" placeholder="Kaliska" />
    <label for="postalcode" class="form-label">Kod Pocztowy</label>
    <input
      type="text"
      name="postalcode"
      id="postalcode-input"
      class="form-field"
      placeholder="21-345"
    />
    <label for="housenumber" class="form-label">Nr.Domu</label>
    <input
      type="text"
      name="housenumber"
      id="housenumber-input"
      class="form-field"
      placeholder="8"
    />
  </div>
</template>

<script>
import {} from 'vuelidate/lib/validators';

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
};
</script>

<style lang="scss" scoped>
#address-input {
  display: flex;
  flex-direction: column;
}
</style>
