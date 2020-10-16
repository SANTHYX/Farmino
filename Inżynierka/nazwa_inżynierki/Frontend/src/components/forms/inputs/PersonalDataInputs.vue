<template>
  <div id="personal-data-input">
    <label for="first-name">Imię</label>
    <input type="text" name="first-name" id="first-name-input" placeholder="Jan" />
    <label for="last-name">Nazwisko</label>
    <input type="text" name="last-name" id="last-name-input" placeholder="Kowalski" />
    <label for="phone-number">Nr.Telefonu</label>
    <input type="text" name="phone-number" id="phone-number-input" placeholder="555-333-222" />
  </div>
</template>

<script>
export default {
  name: 'personal-data-input',
};
</script>

<style lang="scss">
#personal-data-input {
  display: flex;
  flex-direction: column;
}
</style>
