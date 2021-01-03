<template>
  <div id="login-form">
    <div id="form-wraper">
      <h1>Logowanie</h1>
      <hr />
      <div id="inputs-wraper">
        <label for="userName" class="form-label">Login</label>
        <input type="text" name="userName" class="form-field" v-model="$v.user.userName.$model" />
      </div>
      <div id="inputs-wraper">
        <label for="password" class="form-label">Hasło</label>
        <input
          type="password"
          name="password"
          class="form-field"
          v-model="$v.user.password.$model"
        />
      </div>
      <p>Nie pamiętam hasła</p>
      <button @click="LogUser" :disabled="$v.user.$invalid">
        Zaloguj się
      </button>
    </div>
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
        this.$router.push('home');
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
  #form-wraper {
    padding: 2rem;
    border: 2px solid rgb(189, 189, 189);
    box-shadow: 1px 1px 20px rgb(179, 179, 179);
    border-radius: 10px;
    hr {
      margin-top: 0.2rem;
      width: 240px;
      color: rgb(245, 245, 245);
    }
    h1 {
      text-align: center;
      color: rgb(63, 63, 63);
    }
    #inputs-wraper {
      display: flex;
      flex-direction: column;
    }
  }
}
</style>
