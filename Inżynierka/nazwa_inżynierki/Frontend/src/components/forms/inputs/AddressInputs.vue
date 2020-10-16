<template>
  <div id="address-input">
    <label for="city">Miejscowość</label>
    <input type="text" name="city" id="city-input" placeholder="Warszawa" />
    <label for="street">Ulica</label>
    <input type="text" name="street" id="street-input" placeholder="Kaliska" />
    <label for="postalcode">Kod Pocztowy</label>
    <input type="text" name="postalcode" id="postalcode-input" placeholder="21-345" />
    <label for="housenumber"></label>
    <input type="text" name="housenumber" id="housenumber-input" placeholder="8" />
  </div>
</template>

<script>
export default {
  name: 'address-input',
};
</script>

<style></style>
