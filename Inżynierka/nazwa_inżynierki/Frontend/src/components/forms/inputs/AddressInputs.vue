<template>
  <div id="address-input">
    <label for="city">Miejscowość</label>
    <input type="text" name="city" id="city-input" class="form-field" placeholder="Warszawa" />
    <label for="street">Ulica</label>
    <input type="text" name="street" id="street-input" class="form-field" placeholder="Kaliska" />
    <label for="postalcode">Kod Pocztowy</label>
    <input
      type="text"
      name="postalcode"
      id="postalcode-input"
      class="form-field"
      placeholder="21-345"
    />
    <label for="housenumber">Nr.Domu</label>
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
export default {
  name: 'address-input',
};
</script>

<style lang="scss" scoped>
#address-input {
  display: flex;
  flex-direction: column;
}
</style>
