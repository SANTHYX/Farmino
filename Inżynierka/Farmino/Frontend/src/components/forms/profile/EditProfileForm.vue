<template>
  <div id="profile-form">
    <h1>Edytuj Profil</h1>
    <hr />

    <div>
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
      </div>

      <div id="btn-wraper">
        <button class="btn" @click="submitProfile">Wyslij</button>
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
        phoneNumber: '',
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
      isProfileEmpty: 'user/IS_PROFILE_EMPTY',
    }),
  },

  methods: {
    ...mapActions({
      editProfile: 'user/EDIT_PROFILE',
    }),

    async submitProfile() {
      await this.editProfile({
        userName: this.userName,
        firstName: this.profile.firstName,
        lastName: this.profile.lastName,
        phoneNumber: this.profile.phoneNumber,
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#profile-form {
  padding: 2rem;
  @include container-border;
  background: rgba(243, 243, 243, 0.884);

  hr {
    margin-top: 0.2rem;
    width: 200px;
    border: 2px solid orange;
  }

  h1 {
    color: rgb(68, 68, 68);
  }

  #inputs-wraper {
    display: flex;
    flex-direction: column;
  }

  #btn-wraper {
    display: flex;
    justify-content: center;
    margin-top: 2rem;

    .btn {
      padding: 0.4rem;
      width: 200px;
      font-size: 0.9rem;
      background: none;
      border: 1px solid rgb(151, 151, 151);
      transition: 0.2s ease-in;
    }

    .btn:hover{
      border: 1px solid orange;
      color: orange;
    }
  }
}
</style>
