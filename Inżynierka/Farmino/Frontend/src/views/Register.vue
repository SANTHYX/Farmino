<template>
  <div id="register">
    <div id="content">
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
  justify-content: center;
  font-family: 'Roboto Condensed', sans-serif;
  min-height: 100vh;
}
</style>
