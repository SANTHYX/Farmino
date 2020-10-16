<template>
  <div id="register">
    <div id="layout"></div>
    <div id="register-section">
      <register-form></register-form>
    </div>
  </div>
</template>

<script>
import RegisterForm from '../components/forms/RegisterForm.vue';

export default {
  name: 'register',
  components: {
    RegisterForm,
  },
};
</script>

<style lang="scss" scoped>
#register {
  #layout {
    width: 70vw;
    height: 100vh;
  }
  #register-section {
    display: flex;
    justify-content: flex-end;
    width: 100vw;
    height: 100vh;
  }
}
</style>
