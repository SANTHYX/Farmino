<template>
  <div id="address-step">
    <div id="address-reg-form">
      <div id="input-wraper">
        <label for="city" class="form-label">Miejscowość</label>
        <input
          type="text"
          name="city"
          class="form-field"
          placeholder="Warszawa"
          v-model="$v.address.city.$model"
        />
        <div id="error-message-wraper">
          <p class="error-message" v-if="!$v.address.city.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label for="street" class="form-label">Ulica</label>
        <input
          type="text"
          name="city"
          class="form-field"
          placeholder="Powstanców"
          v-model="$v.address.street.$model"
        />
        <div id="error-message-wraper">
          <p class="error-message" v-if="!$v.address.street.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label for="postalCode" class="form-label">Kod Pocztowy</label>
        <input
          type="text"
          name="city"
          class="form-field"
          placeholder="35-234"
          v-model="$v.address.postalCode.$model"
        />
        <div id="error-message-wraper">
          <p class="error-message" v-if="!$v.address.postalCode.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label for="houseNumber" class="form-label">Numer</label>
        <input
          type="number"
          name="houseNumber"
          class="form-field"
          placeholder="1"
          v-model.trim.number="$v.address.houseNumber.$model"
        />
        <div id="error-message-wraper">
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
      this.$emit('address-event', this.address);
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
