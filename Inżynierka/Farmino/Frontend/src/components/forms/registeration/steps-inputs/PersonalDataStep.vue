<template>
  <div id="personal-data-step">
    <div id="personalData-reg-form">
      <div id="input-wraper">
        <label
          for="first-name"
          :class="[!$v.personalData.firstName.$error ? 'form-label' : 'error-label']"
          >Imię</label
        >
        <input
          type="text"
          name="first-name"
          :class="[!$v.personalData.firstName.$error ? 'form-field' : 'error-field']"
          placeholder="Jan"
          v-model.lazy="$v.personalData.firstName.$model"
        />
        <div id="error-message-wraper" v-if="$v.personalData.firstName.$error">
          <p class="error-message" v-if="!$v.personalData.firstName.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label
          for="last-name"
          :class="[!$v.personalData.lasttName.$error ? 'form-label' : 'error-label']"
          >Nazwisko</label
        >
        <input
          type="text"
          name="last-name"
          :class="[!$v.personalData.lastName.$error ? 'form-field' : 'error-field']"
          placeholder="Kowalski"
          v-model.lazy="$v.personalData.lastName.$model"
        />
        <div id="error-message-wraper" v-if="$v.personalData.lastName.$error">
          <p class="error-message" v-if="!$v.personalData.lastName.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label
          for="phone-number"
          :class="[!$v.personalData.phoneNumber.$error ? 'form-label' : 'error-label']"
          >Nr.Telefonu</label
        >
        <input
          type="text"
          name="phone-number"
          :class="[!$v.personalData.phoneNumber.$error ? 'form-field' : 'error-field']"
          placeholder="545-167-316"
          v-model.lazy="$v.personalData.phoneNumber.$model"
        />
        <div id="error-message-wraper" v-if="$v.personalData.phoneNumber.$error">
          <p class="error-message" v-if="!$v.personalData.phoneNumber.required">
            Pole jest wymagane
          </p>
          <p class="error-message" v-if="!$v.personalData.phoneNumber.requiredLength">
            Podany numer jest nie poprawny
          </p>
        </div>
      </div>
      <button @click="passDataToParent" :disabled="$v.personalData.$invalid">
        Dalej
      </button>
    </div>
  </div>
</template>

<script>
import { required } from 'vuelidate/lib/validators';

export default {
  data() {
    return {
      personalData: {
        firstName: '',
        lastName: '',
        address: {},
        phoneNumber: '',
      },
    };
  },
  validations: {
    personalData: {
      firstName: { required },
      lastName: { required },
      phoneNumber: {
        required,
        requiredLength(value) {
          if (value.length === 11) {
            return true;
          }
          return false;
        },
      },
    },
  },
  methods: {
    passDataToParent() {
      this.$emit('personalData-event', { personalData: this.personalData, nextStep: 'address' });
      console.log(this.personalData);
    },
  },
};
</script>

<style lang="scss" scoped>
#personal-data-step {
  display: flex;
  justify-content: center;
  align-items: center;
  #personalData-reg-form {
    display: flex;
    flex-direction: column;
    #input-wraper {
      display: flex;
      flex-direction: column;
    }
  }
}
</style>
