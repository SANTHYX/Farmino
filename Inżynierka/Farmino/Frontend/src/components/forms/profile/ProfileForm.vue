<template>
  <div id="profile-form">
    <h1>Profil</h1>
    <div id="inputs-wraper">
      <label for="firstName" :class="[!$v.profile.firstName.$error ? 'form-label' : 'error-label']"
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
    </div>
    <button @click="sendProfile">Wyslij</button>
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
    },
  },
  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
      getUser: 'user/GET_USER',
    }),
  },
  methods: {
    ...mapActions({
      createProfile: 'user/CREATE_PROFILE',
      editProfile: 'user/EDIT_PROFILE',
    }),
    async sendProfile() {
      if (!this.getUser.profile) {
        await this.createProfile({
          userName: this.userName,
          firstName: this.profile.firstName,
          lastName: this.profile.lastName,
          phoneNumber: this.profile.phoneNumber,
        });
      } else {
        await this.editProfile({
          userName: this.userName,
          firstName: this.profile.firstName,
          lastName: this.profile.lastName,
          phoneNumber: this.profile.phoneNumber,
        });
      }
    },
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
