<template>
  <div>
    <div id="register">
      <div id="content">
        <div id="register-section">
          <registeration-form />
        </div>
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
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}
</style>
