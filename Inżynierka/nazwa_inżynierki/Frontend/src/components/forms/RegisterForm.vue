<template>
  <div id="register-form">
    <h1>Rejestracja</h1>
    <div class="form" id="account-form" v-if="stage === 'account-form'">
      <h2>Dane Logowania</h2>
      <label for="login-form">Login</label>
      <input type="text" name="login-form" id="login-form" />
      <label for="login-form">Login</label>
      <input type="text" name="login-form" id="login-form" />
      <label for="login-form">Login</label>
      <input type="text" name="login-form" id="login-form" />
    </div>
    <div class="form" id="personal-data-form" v-else-if="stage === 'personal-data-form'"></div>
    <div class="form" id="address-form" v-else-if="stage === 'address-form'"></div>
  </div>
</template>

<script>
export default {
  name: 'register-form',
  data() {
    return {
      stage: 'account-form',
    };
  },
};
</script>

<style lang="scss" scoped>
#register-form {
  display: flex;
  justify-content: center;
  align-items: center;

  #account-form {
    display: flex;
    flex-direction: column;
    justify-self: center;
    align-self: center;
  }
}
</style>
