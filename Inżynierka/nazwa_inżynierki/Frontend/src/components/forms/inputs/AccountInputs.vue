<template>
  <div id="account-inputs">
    <label for="login" class="form-label">Login</label>
    <input type="text" name="login" id="login-form" class="form-field" />
    <label for="password" class="form-label">Hasło</label>
    <input type="password" name="password" id="password-form" class="form-field" />
    <label for="email" class="form-label">Email</label>
    <input type="email" name="email" id="email-form" class="form-field" />
  </div>
</template>

<script>
import { email } from 'vuelidate/lib/validators';

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
  validators: {
    login: {},
    password: {},
    email: {},
  },
};
</script>

<style lang="scss" scoped>
#account-inputs {
  display: flex;
  flex-direction: column;
}
</style>
