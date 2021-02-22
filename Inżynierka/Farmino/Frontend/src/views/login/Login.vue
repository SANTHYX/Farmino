<template>
  <div>
    <div id="login">
      <div id="content">
        <login-form />
      </div>
    </div>
  </div>
</template>

<script>
import LoginForm from '@/components/forms/login/LoginForm.vue';

export default {
  name: 'login',

  components: { LoginForm },
};
</script>

<style lang="scss">
#login {
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
</style>
