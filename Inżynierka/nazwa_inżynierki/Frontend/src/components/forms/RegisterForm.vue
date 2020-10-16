<template>
  <div id="register-form">
    <h1>Rejestracja</h1>
    <div id="form-wraper">
      <account-inputs v-if="stage === 'account'"></account-inputs>
      <personal-data-inputs v-else-if="stage === 'personalData'"></personal-data-inputs>
      <address-inputs v-else></address-inputs>
      <button id="form-btn">Dalej</button>
    </div>
  </div>
</template>

<script>
import AccountInputs from './inputs/AccountInputs.vue';
import PersonalDataInputs from './inputs/PersonalDataInputs.vue';
import AddressInputs from './inputs/AddressInputs.vue';

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
    AddressInputs,
  },
};
</script>

<style lang="scss">
#register-form {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100vh;

  h1 {
    color: #352a2a;
    margin-bottom: 30px;
    font-size: 2.3rem;
    background: #ffffff;
    padding: 0.6rem 3.9rem;
    border: 1px solid #cac2c2;
  }

  #form-wraper {
    display: flex;
    flex-direction: column;
    background: #ffffff;
    border: 1px solid #cac2c2;
    padding: 0.6rem 25px;

    #form-btn {
      align-self: center;
      margin: 2.3rem 0;
      width: 6rem;
      height: 2rem;
      font-family: 'Roboto Condensed', sans-serif;
      font-size: 1rem;
      background: orange;
      border: 2px solid rgb(221, 132, 50);
      border-radius: 5px;
    }
  }
}
</style>
