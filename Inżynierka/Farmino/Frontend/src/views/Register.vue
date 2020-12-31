<template>
  <div id="register">
    <div id="content">
      <div id="register-section">
        <registeration-form />
      </div>
    </div>
  </div>
</template>

<script>
import RegisterationForm from '../components/forms/registeration/RegisterationForm.vue';

export default {
  name: 'register',
  components: {
    RegisterationForm,
  },
};
</script>

<style lang="scss" scoped></style>
