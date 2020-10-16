<template>
  <div id="personal-data-input">
    <label for="first-name" class="form-label">Imię</label>
    <input
      type="text"
      name="first-name"
      id="first-name-input"
      class="form-field"
      placeholder="Jan"
    />
    <label for="last-name" class="form-label">Nazwisko</label>
    <input
      type="text"
      name="last-name"
      id="last-name-input"
      class="form-field"
      placeholder="Kowalski"
    />
    <label for="phone-number" class="form-label">Nr.Telefonu</label>
    <input
      type="text"
      name="phone-number"
      id="phone-number-input"
      class="form-field"
      placeholder="555-333-222"
    />
  </div>
</template>

<script>
export default {
  name: 'personal-data-input',
};
</script>

<style lang="scss" scoped>
#personal-data-input {
  display: flex;
  flex-direction: column;
}
</style>
