<template>
  <div id="register-form">
    <h1>{{ title }}</h1>
    <hr />
    <div id="account-reg-form" v-if="registerationStage === 'user'">
      <label for="login" class="form-label">Login</label>
      <input type="text" name="login" class="form-field" v-model="$v.user.login.$model" />
      <label for="password" class="form-label">Hasło</label>
      <input type="password" name="password" class="form-field" v-model="$v.user.password.$model" />
      <label for="email" class="form-label">E-mail</label>
      <input type="email" name="email" class="form-field" v-model="$v.user.email.$model" />
      <button @click="validateUserForm" :disabled="$v.userValidation.$invalid">Dalej</button>
    </div>
    <div id="personalData-reg-form" v-else-if="registerationStage === 'personalData'">
      <label for="first-name" class="form-label">Imię</label>
      <input
        type="text"
        name="first-name"
        class="form-field"
        placeholder="Jan"
        v-model="$v.user.personalData.firstName.$model"
      />
      <label for="last-name" class="form-label">Nazwisko</label>
      <input
        type="text"
        name="last-name"
        class="form-field"
        placeholder="Kowalski"
        v-model="$v.user.personalData.lastName.$model"
      />
      <label for="phone-number" class="form-label">Nr.Telefonu</label>
      <input
        type="text"
        name="phone-number"
        class="form-field"
        placeholder="545-167-316"
        v-model="$v.user.personalData.phoneNumber.$model"
      />
      <button @click="validatePDForm" :disabled="$v.personalDataValidation.$invalid">Dalej</button>
    </div>
    <div id="address-reg-form" v-else-if="registerationStage === 'address'">
      <label for="city" class="form-label">Miejscowość</label>
      <input
        type="text"
        name="city"
        class="form-field"
        placeholder="Warszawa"
        v-model="$v.user.personalData.address.city.$model"
      />
      <label for="street" class="form-label">Ulica</label>
      <input
        type="text"
        name="city"
        class="form-field"
        placeholder="Powstanców"
        v-model="$v.user.personalData.address.street.$model"
      />
      <label for="postalCode" class="form-label">Kod Pocztowy</label>
      <input
        type="text"
        name="city"
        class="form-field"
        placeholder="35-234"
        v-model="$v.user.personalData.address.postalCode.$model"
      />
      <label for="houseNumber" class="form-label">Kod Pocztowy</label>
      <input
        type="number"
        name="houseNumber"
        class="form-field"
        placeholder="1"
        v-model="$v.user.personalData.address.houseNumber.$model"
      />
      <button type="submit" @click.prevent="" :disabled="$v.addressValidation.$invalid">
        Rejestruj
      </button>
    </div>
  </div>
</template>

<script>
import { required, email } from 'vuelidate/lib/validators';

export default {
  name: 'register-form',
  data() {
    return {
      title: 'Tworzenie Konta',
      registerationStage: 'user',
      user: {
        login: '',
        password: '',
        email: '',
        personalData: {
          firstName: '',
          lastName: '',
          phoneNumber: '',
          address: {
            city: '',
            street: '',
            postalCode: '',
            houseNumber: 0,
          },
        },
      },
    };
  },
  validations: {
    user: {
      login: { required },
      password: { required },
      email: { required, email },
      personalData: {
        firstName: { required },
        lastName: { required },
        phoneNumber: { required },
        address: {
          city: { required },
          street: { required },
          postalCode: { required },
          houseNumber: { required },
        },
      },
    },
    userValidation: ['user.login', 'user.password', 'user.email'],
    personalDataValidation: [
      'user.personalData.firstName',
      'user.personalData.lastName',
      'user.personalData.phoneNumber',
    ],
    addressValidation: ['user.personalData.address'],
  },
  methods: {
    validateUserForm() {
      this.registerationStage = 'personalData';
      this.title = 'Dane Personalne';
    },
    validatePDForm() {
      this.registerationStage = 'address';
      this.title = 'Adres';
    },
  },
};
</script>

<style lang="scss" scoped>
#register-form {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  height: 100vh;

  #account-reg-form,
  #personalData-reg-form,
  #address-reg-form {
    display: flex;
    flex-direction: column;
  }
}
</style>
