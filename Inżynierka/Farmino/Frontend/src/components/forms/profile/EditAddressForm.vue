<template>
  <div id="profile-form">
    <h1>Edytuj Adres</h1>
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
        >Numer Domu</label
      >
      <input
        type="text"
        name="houseNumber"
        :class="[!$v.address.houseNumber.$error ? 'form-field' : 'error-field']"
        @blur="$v.address.houseNumber.$touch()"
        v-model="address.houseNumber"
      />
      <div id="error-message-wraper" v-if="$v.address.houseNumber.$error">
        <p class="error-message" v-if="!$v.address.houseNumber.required">Pole jest wymagane</p>
      </div>
    </div>
    <button @click="submitAddress">Wyslij</button>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import { required } from 'vuelidate/lib/validators';

export default {
  name: 'profile-form',
  data() {
    return {
      address: {
        city: '',
        street: '',
        postalCode: '',
        houseNumber: '',
      },
    };
  },
  validations: {
    address: {
      city: { required },
      street: { required },
      postalCode: { required },
      houseNumber: { required },
    },
  },
  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
      getUser: 'user/GET_STATE_USER',
    }),
  },
  methods: {
    ...mapActions({
      updateAddress: 'user/UPDATE_ADDRESS',
    }),
    async submitAddress() {
      await this.updateAddress({
        userName: this.userName,
        city: this.address.city,
        street: this.address.street,
        postalCode: this.address.postalCode,
        houseNumber: this.address.houseNumber,
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#profile-form {
  padding: 2rem;
  border: 1px solid rgb(189, 189, 189);
  box-shadow: 1px 1px 6px rgb(214, 214, 214);
  border-radius: 10px;
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
