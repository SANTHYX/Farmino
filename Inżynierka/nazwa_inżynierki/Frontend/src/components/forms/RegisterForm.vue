<template>
  <div id="register-form">
    <div id="form-wraper">
      <account-inputs v-if="stage === 'account'"></account-inputs>
      <personal-data-inputs v-else-if="stage === 'personalData'"></personal-data-inputs>
      <address-input v-else></address-input>
    </div>
  </div>
</template>

<script>
import AccountInputs from './inputs/AccountInputs.vue';
import PersonalDataInputs from './inputs/PersonalDataInputs.vue';
import AddressInput from './inputs/AddressInputs.vue';

export default {
  name: 'register-form',
  data() {
    return {
      stage: 'account',
    };
  },
  components: {
    AccountInputs,
    PersonalDataInputs,
    AddressInput,
  },
};
</script>

<style lang="scss">
#register-form {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;

  #form-wraper {
    padding: 5rem 3rem;
    background: rgb(250, 250, 250);
    border-radius: 12px;
  }
}
</style>
