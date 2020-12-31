<template>
  <div id="profile-form">
    <h1>Adres</h1>
    <hr />
    <div id="inputs-wraper">
      <label for="city" :class="[!$v.address.city.$error ? 'form-label' : 'error-label']"
        >Miasto</label
      >
      <input
        type="text"
        name="city"
        :class="[!$v.address.city.$error ? 'form-field' : 'error-field']"
        @blur="$v.address.city.$touch()"
        v-model="address.city"
      />
      <div id="error-message-wraper" v-if="$v.address.city.$error">
        <p class="error-message" v-if="!$v.address.city.required">Pole jest wymagane</p>
      </div>
    </div>
    <div id="inputs-wraper">
      <label for="street" :class="[!$v.address.street.$error ? 'form-label' : 'error-label']"
        >Ulica</label
      >
      <input
        type="text"
        name="street"
        :class="[!$v.address.street.$error ? 'form-field' : 'error-field']"
        @blur="$v.address.street.$touch()"
        v-model="address.street"
      />
      <div id="error-message-wraper" v-if="$v.address.street.$error">
        <p class="error-message" v-if="!$v.address.street.required">Pole jest wymagane</p>
      </div>
    </div>
    <div id="inputs-wraper">
      <label
        for="postalCode"
        :class="[!$v.address.postalCode.$error ? 'form-label' : 'error-label']"
        >Kod Pocztowy</label
      >
      <input
        type="text"
        name="postalCode"
        :class="[!$v.address.postalCode.$error ? 'form-field' : 'error-field']"
        @blur="$v.address.postalCode.$touch()"
        v-model="address.postalCode"
      />
      <div id="error-message-wraper" v-if="$v.address.postalCode.$error">
        <p class="error-message" v-if="!$v.address.postalCode.required">Pole jest wymagane</p>
      </div>
    </div>
    <div id="inputs-wraper">
      <label
        for="houseNumber"
        :class="[!$v.address.houseNumber.$error ? 'form-label' : 'error-label']"
        >Numer Telefonu</label
      >
      <input
        type="text"
        name="phoneNumber"
        :class="[!$v.address.houseNumber.$error ? 'form-field' : 'error-field']"
        @blur="$v.address.houseNumber.$touch()"
        v-model="address.houseNumber"
      />
      <div id="error-message-wraper" v-if="$v.address.houseNumber.$error">
        <p class="error-message" v-if="!$v.address.houseNumber.required">Pole jest wymagane</p>
        <p class="error-message" v-if="!$v.address.houseNumber.minValue">
          nie prawidłowy numer
        </p>
      </div>
    </div>
    <button @click="submitAddress">Wyslij</button>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import { required, minValue } from 'vuelidate/lib/validators';

export default {
  name: 'profile-form',
  data() {
    return {
      address: {
        city: '',
        street: '',
        postalCode: '',
        houseNumber: 0,
      },
    };
  },
  validations: {
    address: {
      city: { required },
      street: { required },
      postalCode: { required },
      houseNumber: { required, minValue: minValue(1) },
    },
  },
  computed: {
    ...mapGetters({
      getUser: 'user/GET_USER',
    }),
  },
  methods: {
    ...mapActions({}),
  },
};
</script>

<style lang="scss" scoped>
#profile-form {
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  hr {
    margin-top: 0.2rem;
    width: 200px;
    color: rgb(245, 245, 245);
  }
  h1 {
    color: rgb(63, 63, 63);
  }
  #inputs-wraper {
    display: flex;
    flex-direction: column;
  }
}
</style>
