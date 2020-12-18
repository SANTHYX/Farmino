<template>
  <div id="registeration-form">
    <div id="design-content"></div>
    <div id="form-wraper">
      <h1>Rejestracja</h1>
      <hr />
      <div id="input-wraper">
        <label for="login" :class="[!$v.user.login.$error ? 'form-label' : 'error-label']"
          >Login</label
        >
        <input
          type="text"
          name="login"
          :class="[!$v.user.login.$error ? 'form-field' : 'error-field']"
          @blur="$v.user.login.$touch()"
          v-model="user.login"
        />
        <div id="error-message-wraper" v-if="$v.user.login.$error">
          <p class="error-message" v-if="!$v.user.login.required">Pole jest wymagane</p>
          <p class="error-message" v-else-if="!$v.user.login.LoginAvability">
            Ten login jest już zajęty
          </p>
        </div>
      </div>
      <div id="input-wraper">
        <label for="password" :class="[!$v.user.password.$error ? 'form-label' : 'error-label']"
          >Hasło</label
        >
        <input
          type="password"
          name="password"
          :class="[!$v.user.password.$error ? 'form-field' : 'error-field']"
          @blur="$v.user.password.$touch()"
          v-model="user.password"
        />
        <div id="error-message-wraper" v-if="$v.user.password.$error">
          <p class="error-message" v-if="!$v.user.password.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label for="email" :class="[!$v.user.email.$error ? 'form-label' : 'error-label']"
          >E-mail</label
        >
        <input
          type="email"
          name="email"
          :class="[!$v.user.email.$error ? 'form-field' : 'error-field']"
          @blur="$v.user.email.$touch()"
          v-model="user.email"
        />
        <div id="error-message-wraper" v-if="$v.user.email.$error">
          <p class="error-message" v-if="!$v.user.email.required">Pole jest wymagane</p>
          <p class="error-message" v-if="!$v.user.email.email">Email nie poprawny</p>
        </div>
      </div>
      <button @submit.prevent="register(user)">Zarejestruj</button>
    </div>
  </div>
</template>

<script>
import { mapMutations } from 'vuex';
import { required, email } from 'vuelidate/lib/validators';
import api from '@/plugins/axios';

export default {
  name: 'registeration-form',
  data() {
    return {
      user: {
        login: '',
        password: '',
        email: '',
      },
    };
  },
  validations: {
    user: {
      login: {
        required,
        async LoginAvability(value) {
          const response = await api.get(`/users/isLoginAvaliable?login=${value}`);
          return response.data.isAvaliable;
        },
      },
      password: { required },
      email: { required, email },
    },
  },
  methods: {
    ...mapMutations({
      register: 'user/REGISTER',
    }),
  },
};
</script>

<style lang="scss" scoped>
#registeration-form {
  display: flex;
  #form-wraper {
    display: flex;
    flex-direction: column;
    align-items: center;
    hr {
      margin-top: 0.2rem;
      width: 200px;
      color: rgb(245, 245, 245);
    }
    h1 {
      color: rgb(63, 63, 63);
    }
    #input-wraper {
      display: flex;
      flex-direction: column;
    }
  }
}
</style>
