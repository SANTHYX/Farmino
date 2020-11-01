<template>
  <div id="login-form">
    <div id="inputs-wraper">
      <label for="login" class="form-label">Login lub email</label>
      <input type="text" name="login" class="form-field" v-model="$v.user.login.$model" />
    </div>
    <div id="inputs-wraper">
      <label for="password" class="form-label">Hasło</label>
      <input type="password" name="password" class="form-field" v-model="$v.user.password.$model" />
    </div>
    <button type="submit" @submit.prevent="" :disabled="$v.user.$invalid">Zaloguj się</button>
  </div>
</template>

<script>
import { required } from 'vuelidate//lib/validators';

export default {
  name: 'login-form',
  data() {
    return {
      user: {
        login: '',
        password: '',
      },
    };
  },
  validations: {
    user: {
      login: { required },
      password: { required },
    },
  },
};
</script>

<style lang="scss" scoped>
#login-form {
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  #inputs-wraper {
    display: flex;
    flex-direction: column;
  }
}
</style>
