<template>
  <div id="account-inputs">
    <label for="login" class="form-label">Login</label>
    <input type="text" name="login" id="login-form" class="form-field" v-model="user.login" />
    <label for="password" class="form-label">Hasło</label>
    <input
      type="password"
      name="password"
      id="password-form"
      class="form-field"
      v-model="user.password"
    />
    <label for="email" class="form-label">Email</label>
    <input type="email" name="email" id="email-form" class="form-field" v-model="user.email" />
  </div>
</template>

<script>
import { required, email } from 'vuelidate/lib/validators';

export default {
  name: 'account-inputs',
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
      login: { required },
      password: { required },
      email: { required, email },
    },
  },
  validationGroup: ['user.login', 'user.password', 'login.email'],
  methods: {
    IsAccountValid() {
      this.$emit('IsAddressValid', this.$v.$invalid);
      console.log('Invoked passing boolean value about Account validation result to Parent!');
    },
  },
};
</script>

<style lang="scss" scoped>
#account-inputs {
  display: flex;
  flex-direction: column;
}
</style>
