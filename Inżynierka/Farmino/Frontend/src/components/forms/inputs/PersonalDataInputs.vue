<template>
  <div id="personal-data-input">
    <label for="first-name" class="form-label">Imię</label>
    <input
      type="text"
      name="first-name"
      id="first-name-input"
      class="form-field"
      placeholder="Jan"
      v-model="personalData.firstName"
    />
    <label for="last-name" class="form-label">Nazwisko</label>
    <input
      type="text"
      name="last-name"
      id="last-name-input"
      class="form-field"
      placeholder="Kowalski"
      v-model="personalData.lastName"
    />
    <label for="phone-number" class="form-label">Nr.Telefonu</label>
    <input
      type="text"
      name="phone-number"
      id="phone-number-input"
      class="form-field"
      placeholder="557-231-282"
      v-model="personalData.phoneNumber"
    />
  </div>
</template>

<script>
import { required } from 'vuelidate/lib/validators';

export default {
  name: 'personal-data-input',
  data() {
    return {
      personalData: {
        firstName: '',
        lastName: '',
        phoneNumber: '',
      },
    };
  },
  validations: {
    personalData: {
      firstName: { required },
      lastName: { required },
      phoneNumber: { required },
    },
  },
  validationGroup: ['personalData.firstName', 'personalData.lastName', 'personalData.phoneNumbe'],
  methods: {
    IsPersonalDataValid() {
      this.$emit('IsPersonalDataValid', this.$v.$invalid);
      console.log('Invoked passing boolean value about personal data validation result to Parent!');
    },
  },
  beforeDestroy() {
    this.IsPersonalDataValid();
  },
};
</script>

<style lang="scss" scoped>
#personal-data-input {
  display: flex;
  flex-direction: column;
}
</style>
