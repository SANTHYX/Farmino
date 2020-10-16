<template>
  <div id="register">
    <div id="content">
      <div id="content-section"></div>
      <div id="register-section">
        <register-form></register-form>
      </div>
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
#content {
  display: flex;
  font-family: 'Roboto Condensed', sans-serif;

  #register-section {
    background: rgb(246, 233, 108);
    width: 30vw;
    height: 100vh;
  }
  #content-section {
    background: green;
    width: 70vw;
    height: 100vh;
  }
}
</style>
