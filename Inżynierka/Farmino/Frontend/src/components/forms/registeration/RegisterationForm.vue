<template>
  <div id="registeration-form">
    <div id="design-content"></div>
    <div id="form-wraper">
      <account-step v-if="recentStep == 'account'" @account-event="setAccountData"></account-step>
      <personal-data-step
        v-if="recentStep == 'personalData'"
        @personalData-event="setPersonalData"
      ></personal-data-step>
      <address-step v-if="recentStep == 'address'" @address-event="setAddressData"></address-step>
    </div>
  </div>
</template>

<script>
import AccountStep from './steps-inputs/AccountStep.vue';
import devFarminoApi from '../../../plugins/axios';

export default {
  name: 'registeration-form',
  components: {
    AccountStep,
    PersonalDataStep: () => import('./steps-inputs/PersonalDataStep.vue'),
    AddressStep: () => import('./steps-inputs/AddressStep.vue'),
  },
  data() {
    return {
      user: {},
      recentStep: 'account',
    };
  },
  methods: {
    setAccountData(payload) {
      this.recentStep = payload.nextStep;
      this.user = payload.user;
    },
    setPersonalData(payload) {
      this.recentStep = payload.nextStep;
      this.user.personalData = payload.personalData;
    },
    async setAddressData(payload) {
      this.user.personalData.address = payload.address;
      await this.registerUser();
    },
    async registerUser() {
      try {
        await devFarminoApi.post('/users', this.user);
        console.log('completed');
      } catch (error) {
        console.log(error.message);
      }
    },
  },
};
</script>

<style lang="scss" scoped></style>
