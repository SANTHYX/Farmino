<template>
  <div id="login-form">
    <h1>Logowanie</h1>
    <hr />
    <div id="inputs-wraper">
      <label for="userName" class="form-label">Login lub email</label>
      <input type="text" name="userName" class="form-field" v-model="$v.user.userName.$model" />
    </div>
    <div id="inputs-wraper">
      <label for="password" class="form-label">Hasło</label>
      <input type="password" name="password" class="form-field" v-model="$v.user.password.$model" />
    </div>
    <p>Nie pamiętam hasła</p>
    <button @click="LogUser" :disabled="$v.user.$invalid">
      Zaloguj się
    </button>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import { required } from 'vuelidate//lib/validators';

export default {
  name: 'login-form',
  data() {
    return {
      user: {
        userName: '',
        password: '',
      },
    };
  },
  validations: {
    user: {
      userName: { required },
      password: { required },
    },
  },
  methods: {
    ...mapActions({
      Login: 'auth/LOGIN',
    }),
    async LogUser() {
      try {
        await this.Login(this.user);
        this.$router.push('/');
      } catch (err) {
        console.log(err);
      }
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
