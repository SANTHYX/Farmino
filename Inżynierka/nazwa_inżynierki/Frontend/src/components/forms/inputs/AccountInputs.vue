<template>
  <div id="account-inputs">
    <label for="login">Login</label>
    <input type="text" name="login" id="login-form" />
    <label for="password">Hasło</label>
    <input type="password" name="password" id="password-form" />
    <label for="email">Email</label>
    <input type="email" name="email" id="email-form" />
  </div>
</template>

<script>
export default {
  name: 'account-inputs',
};
</script>

<style lang="scss">
#account-inputs {
  display: flex;
  flex-direction: column;
}
</style>
