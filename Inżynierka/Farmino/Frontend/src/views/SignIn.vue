<template>
  <div id="signin">
    <div id="content">
      <login-form></login-form>
    </div>
  </div>
</template>

<script>
import LoginForm from '../components/forms/login/LoginForm.vue';

export default {
  name: 'signin',
  components: { LoginForm },
};
</script>

<style lang="scss" scoped></style>
