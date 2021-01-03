<template>
  <div>
    <div id="profile-form">
      <h1>Stwórz Profil</h1>
      <hr />
      <div id="inputs-wraper">
        <label
          for="firstName"
          :class="[!$v.profile.firstName.$error ? 'form-label' : 'error-label']"
          >Imię</label
        >
        <input
          type="text"
          name="firstName"
          :class="[!$v.profile.firstName.$error ? 'form-field' : 'error-field']"
          @blur="$v.profile.firstName.$touch()"
          v-model="profile.firstName"
        />
        <div id="error-message-wraper" v-if="$v.profile.firstName.$error">
          <p class="error-message" v-if="!$v.profile.firstName.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="inputs-wraper">
        <label for="lastName" :class="[!$v.profile.lastName.$error ? 'form-label' : 'error-label']"
          >Nazwisko</label
        >
        <input
          type="text"
          name="lastName"
          :class="[!$v.profile.lastName.$error ? 'form-field' : 'error-field']"
          @blur="$v.profile.lastName.$touch()"
          v-model="profile.lastName"
        />
        <div id="error-message-wraper" v-if="$v.profile.lastName.$error">
          <p class="error-message" v-if="!$v.profile.lastName.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="inputs-wraper">
        <label
          for="phoneNumber"
          :class="[!$v.profile.phoneNumber.$error ? 'form-label' : 'error-label']"
          >Numer Telefonu</label
        >
        <input
          type="text"
          name="phoneNumber"
          :class="[!$v.profile.phoneNumber.$error ? 'form-field' : 'error-field']"
          @blur="$v.profile.phoneNumber.$touch()"
          v-model="profile.phoneNumber"
        />
        <div id="error-message-wraper" v-if="$v.profile.phoneNumber.$error">
          <p class="error-message" v-if="!$v.profile.phoneNumber.required">Pole jest wymagane</p>
          <p class="error-message" v-if="!$v.profile.phoneNumber.numeric">
            Nie wymaga podania znaków
          </p>
          <p class="error-message" v-if="!$v.profile.phoneNumber.isPhoneNumber">
            Nie prawidłowa długość numeru
          </p>
        </div>
        <div id="inputs-wraper">
          <label
            for="city"
            :class="[!$v.profile.address.city.$error ? 'form-label' : 'error-label']"
            >Miasto</label
          >
          <input
            type="text"
            name="city"
            :class="[!$v.profile.address.city.$error ? 'form-field' : 'error-field']"
            @blur="$v.profile.address.city.$touch()"
            v-model="profile.address.city"
          />
          <div id="error-message-wraper" v-if="$v.profile.address.city.$error">
            <p class="error-message" v-if="!$v.profile.address.city.required">Pole jest wymagane</p>
          </div>
        </div>
        <div id="inputs-wraper">
          <label
            for="street"
            :class="[!$v.profile.address.street.$error ? 'form-label' : 'error-label']"
            >Ulica</label
          >
          <input
            type="text"
            name="street"
            :class="[!$v.profile.address.street.$error ? 'form-field' : 'error-field']"
            @blur="$v.profile.address.street.$touch()"
            v-model="profile.address.street"
          />
          <div id="error-message-wraper" v-if="$v.profile.address.street.$error">
            <p class="error-message" v-if="!$v.profile.address.street.required">
              Pole jest wymagane
            </p>
          </div>
        </div>
        <div id="inputs-wraper">
          <label
            for="postalCode"
            :class="[!$v.profile.address.postalCode.$error ? 'form-label' : 'error-label']"
            >Kod Pocztowy</label
          >
          <input
            type="text"
            name="postalCode"
            :class="[!$v.profile.address.postalCode.$error ? 'form-field' : 'error-field']"
            @blur="$v.profile.address.postalCode.$touch()"
            v-model="profile.address.postalCode"
          />
          <div id="error-message-wraper" v-if="$v.profile.address.postalCode.$error">
            <p class="error-message" v-if="!$v.profile.address.postalCode.required">
              Pole jest wymagane
            </p>
          </div>
        </div>
        <div id="inputs-wraper">
          <label
            for="houseNumber"
            :class="[!$v.profile.address.houseNumber.$error ? 'form-label' : 'error-label']"
            >Numer Telefonu</label
          >
          <input
            type="number"
            name="houseNumber"
            :class="[!$v.profile.address.houseNumber.$error ? 'form-field' : 'error-field']"
            @blur="$v.profile.address.houseNumber.$touch()"
            v-model.number="profile.address.houseNumber"
          />
          <div id="error-message-wraper" v-if="$v.profile.address.houseNumber.$error">
            <p class="error-message" v-if="!$v.profile.address.houseNumber.required">
              Pole jest wymagane
            </p>
          </div>
        </div>
        <button @click="send">Stwórz</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import { required, numeric } from 'vuelidate/lib/validators';

export default {
  name: 'profile-form',
  data() {
    return {
      profile: {
        firstName: '',
        lastName: '',
        phoneNumber: 0,
        address: {
          city: '',
          street: '',
          postalCode: '',
          houseNumber: 0,
        },
      },
    };
  },
  validations: {
    profile: {
      firstName: { required },
      lastName: { required },
      phoneNumber: {
        required,
        numeric,
        isPhoneNumber(value) {
          return value.length === 9 || value.length === 11;
        },
      },
      address: {
        city: { required },
        street: { required },
        postalCode: { required },
        houseNumber: { required },
      },
    },
  },
  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
    }),
  },
  methods: {
    ...mapActions({
      createProfile: 'user/CREATE_PROFILE',
      setAddress: 'user/CREATE_ADDRESS',
    }),
    async send() {
      await this.createProfile({
        userName: this.userName,
        firstName: this.profile.firstName,
        lastName: this.profile.lastName,
        phoneNumber: this.profile.phoneNumber,
      });
      await this.setAddress({
        userName: this.userName,
        city: this.profile.address.city,
        street: this.profile.address.street,
        postalCode: this.profile.address.postalCode,
        houseNumber: this.profile.address.houseNumber,
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
