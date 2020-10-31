<template>
  <div id="address-step">
    <div id="address-reg-form">
      <div id="input-wraper">
        <label for="city" :class="[!$v.address.city.$error ? 'form-label' : 'error-label']"
          >Miejscowość</label
        >
        <input
          type="text"
          name="city"
          :class="[!$v.address.city.$error ? 'form-field' : 'error-field']"
          placeholder="Warszawa"
          v-model.lazy="$v.address.city.$model"
        />
        <div id="error-message-wraper" v-if="$v.address.city.$error">
          <p class="error-message" v-if="!$v.address.city.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label for="street" :class="[!$v.address.street.$error ? 'form-label' : 'error-label']"
          >Ulica</label
        >
        <input
          type="text"
          name="city"
          :class="[!$v.address.street.$error ? 'form-field' : 'error-field']"
          placeholder="Powstanców"
          v-model.lazy="$v.address.street.$model"
        />
        <div id="error-message-wraper" v-if="$v.address.street.$error">
          <p class="error-message" v-if="!$v.address.street.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label
          for="postalCode"
          :class="[!$v.address.postalCode.$error ? 'form-label' : 'error-label']"
          >Kod Pocztowy</label
        >
        <input
          type="text"
          name="postalCode"
          :class="[!$v.address.postalCode.$error ? 'form-field' : 'error-field']"
          placeholder="35-234"
          v-model="$v.address.postalCode.$model"
        />
        <div id="error-message-wraper" v-if="$v.address.postalCode.$error">
          <p class="error-message" v-if="!$v.address.postalCode.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label
          for="houseNumber"
          :class="[!$v.address.houseNumber.$error ? 'form-label' : 'error-label']"
          >Numer</label
        >
        <input
          type="number"
          name="houseNumber"
          :class="[!$v.address.houseNumber.$error ? 'form-field' : 'error-field']"
          placeholder="1"
          v-model.trim.number="$v.address.houseNumber.$model"
        />
        <div id="error-message-wraper" v-if="$v.address.houseNumber.$error">
          <p class="error-message" v-if="!$v.address.houseNumber.required">Pole jest wymagane</p>
          <p class="error-message" v-if="$v.address.houseNumber.numeric">
            Wartość musi być liczbą
          </p>
          <p class="error-message" v-if="!$v.address.houseNumber.minValue">
            Nieprawidłowa wartość
          </p>
        </div>
      </div>
      <button @click="passDataToParent" :disabled="$v.address.$invalid">Rejestruj</button>
    </div>
  </div>
</template>

<script>
import { required, minValue } from 'vuelidate/lib/validators';

export default {
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
      houseNumber: { required, minValue: minValue(0) },
    },
  },
  methods: {
    passDataToParent() {
      this.$emit('address-event', { address: this.address });
    },
  },
};
</script>

<style lang="scss" scoped>
#address-step {
  display: flex;
  justify-content: center;
  align-items: center;
  #address-reg-form {
    display: flex;
    flex-direction: column;
    #input-wraper {
      display: flex;
      flex-direction: column;
    }
  }
}
</style>
