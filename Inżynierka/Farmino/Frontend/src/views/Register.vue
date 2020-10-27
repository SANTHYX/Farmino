<template>
  <div id="register">
    <div id="content">
      <div id="register-section">
        <registeration-form></registeration-form>
      </div>
    </div>
  </div>
</template>

<script>
import RegisterationForm from '../components/forms/RegisterationForm.vue';

export default {
  name: 'register',
  components: {
    RegisterationForm,
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
