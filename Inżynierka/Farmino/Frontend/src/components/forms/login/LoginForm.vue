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

      <div id="btn-wraper">
        <button id="btn" @click="LogUser" :disabled="$v.user.$invalid" class="btn-form">
          Zaloguj się
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import { required } from 'vuelidate/lib/validators';

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
      await this.Login(this.user);

      if (this.$route.redirect !== null) {
        this.$router.push({ path: this.$route.query.redirect });
      } else this.$router.push({ name: 'home' });
    },
  },
};
</script>

<style lang="scss" scoped>
#login-form {
  #form-wraper {
    padding: 2rem;
    border: 1px solid rgb(189, 189, 189);
    box-shadow: 1px 1px 6px rgb(179, 179, 179);
    background: rgba(248, 248, 248, 0.883);

    hr {
      margin-top: 0.2rem;
      width: 240px;
      border: 2px solid orange;
    }

    h1 {
      text-align: center;
      color: rgb(129, 129, 129);
    }

    #inputs-wraper {
      display: flex;
      flex-direction: column;
    }

    #btn-wraper {
      margin-top: 1rem;
      display: flex;
      justify-content: center;

      #btn {
        padding: 0.5rem 0.2rem;
        background: none;
        border: 2px solid rgba(179, 179, 179, 0.733);
        font-weight: bold;
        color: rgba(0, 0, 0, 0.658);
        width: 240px;
        transition: 0.1s ease-in;
      }

      #btn:hover {
        border: 2px solid orange;
        color: orange;
      }
    }
  }
}
</style>
