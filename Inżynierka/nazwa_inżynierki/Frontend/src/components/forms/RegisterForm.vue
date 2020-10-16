<template>
  <div id="register-form">
    <div id="form-wraper">
      <account-inputs></account-inputs>
      <personal-data-inputs></personal-data-inputs>
      <address-input></address-input>
    </div>
  </div>
</template>

<script>
import AccountInputs from './inputs/AccountInputs.vue';
import PersonalDataInputs from './inputs/PersonalDataInputs.vue';
import AddressInput from './inputs/AddressInputs.vue';

export default {
  name: 'register-form',
  components: {
    AccountInputs,
    PersonalDataInputs,
    AddressInput,
  },
};
</script>

<style lang="scss" scoped>
#register-form {
  display: flex;
  align-items: center;
  height: 100vh;
}
</style>
