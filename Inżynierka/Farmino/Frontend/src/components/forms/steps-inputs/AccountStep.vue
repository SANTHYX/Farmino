<template>
  <div id="account-step">
    <div id="account-reg-form">
      <div id="input-wraper">
        <label for="login" class="form-label">Login</label>
        <input type="text" name="login" class="form-field" v-model.trim="$v.user.login.$model" />
        <div id="error-message-wraper">
          <p class="error-message" v-if="!$v.user.login.required">Pole jest wymagane</p>
          <p class="error-message" v-else-if="!$v.user.login.LoginAvability">
            Ten login jest już zajęty
          </p>
        </div>
      </div>
      <div id="input-wraper">
        <label for="password" class="form-label">Hasło</label>
        <input
          type="password"
          name="password"
          class="form-field"
          v-model="$v.user.password.$model"
        />
        <div id="error-message-wraper">
          <p class="error-message" v-if="!$v.user.password.required">Pole jest wymagane</p>
        </div>
      </div>
      <div id="input-wraper">
        <label for="email" class="form-label">E-mail</label>
        <input type="email" name="email" class="form-field" v-model="$v.user.email.$model" />
        <div id="error-message-wraper">
          <p class="error-message" v-if="!$v.user.email.required">Pole jest wymagane</p>
          <p class="error-message" v-if="!$v.user.email.email">Email nie poprawny</p>
        </div>
      </div>
      <button @click="passDataToParent" :disabled="$v.user.$invalid">Zatwierdź</button>
    </div>
  </div>
</template>

<script>
import { required, email } from 'vuelidate/lib/validators';
import devFarminoApi from '../../../plugins/axios';

export default {
  name: 'account-step',
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
          const response = await devFarminoApi.get(`/users/isLoginAvaliable?login=${value}`);
          return response.data.isAvaliable;
        },
      },
      password: { required },
      email: { required, email },
    },
  },
  methods: {
    passDataToParent() {
      this.$emit('account-event', { user: this.user, nextStep: 'personalData' });
    },
  },
};
</script>

<style lang="scss" scoped>
#account-step {
  display: flex;
  justify-content: center;
  align-items: center;
  #account-reg-form {
    display: flex;
    flex-direction: column;
    #input-wraper {
      display: flex;
      flex-direction: column;
    }
  }
}
</style>
