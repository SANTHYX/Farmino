<template>
  <div id="login-form">
    <div id="inputs-wraper">
      <label for="login" class="form-label">Login</label>
      <input type="text" name="login" class="form-field" />
    </div>
    <div id="inputs-wraper">
      <label for="password" class="form-label">Hasło</label>
      <input type="password" name="password" class="form-field" />
    </div>
    <button type="submit" @submit.prevent="">Zaloguj się</button>
  </div>
</template>

<script>
export default {
  name: 'login-form',
  data() {
    return {
      account: {
        login: '',
        password: '',
      },
    };
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
