<template>
  <div id="registeration-form">
    <div id="form-wrapper">
      <h1>Rejestracja</h1>
      <hr />
      <div id="input-wraper">
        <label for="login" :class="[!$v.user.userName.$error ? 'form-label' : 'error-label']"
          >Login</label
        >
        <input
          type="text"
          name="login"
          :class="[!$v.user.userName.$error ? 'form-field' : 'error-field']"
          @blur="$v.user.userName.$touch()"
          v-model="user.userName"
        />
        <div id="error-message-wraper" v-if="$v.user.userName.$error">
          <p class="error-message" v-if="!$v.user.userName.required">Pole jest wymagane</p>
          <p class="error-message" v-else-if="!$v.user.userName.LoginAvability">
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
      <button @click="RegisterUser" :disabled="$v.user.$invalid">
        Zarejestruj
      </button>
    </div>
  </div>
</template>

<script>
import { required, email } from 'vuelidate/lib/validators';
import api from '@/plugins/axios';

export default {
  name: 'registeration-form',
  data() {
    return {
      user: {
        userName: '',
        password: '',
        email: '',
      },
    };
  },
  validations: {
    user: {
      userName: {
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
    async RegisterUser() {
      try {
        await api.post('/auth/register', this.user);
        this.$router.push('login');
      } catch (err) {
        throw new Error(err);
      }
    },
  },
};
</script>

<style lang="scss" scoped>
#registeration-form {
  #form-wrapper {
    display: flex;
    flex-direction: column;
    align-items: center;
    flex-wrap: wrap;
    padding: 2rem;
    border: 2px solid rgb(206, 206, 206);
    box-shadow: 1px 1px 20px rgb(179, 179, 179);
    border-radius: 10px;
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
