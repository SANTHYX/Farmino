<template>
  <div>
    <div id="register">
      <div id="register-section">
        <registeration-form />
      </div>
    </div>
  </div>
</template>

<script>
import RegisterationForm from '@/components/forms/registeration/RegisterationForm.vue';

export default {
  components: {
    RegisterationForm,
  },
};
</script>

<style lang="scss">
#register {
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
</style>
