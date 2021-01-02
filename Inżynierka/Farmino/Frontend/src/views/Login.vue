<template>
  <div>
    <div id="signin">
      <div id="content">
        <login-form />
      </div>
    </div>
  </div>
</template>

<script>
import LoginForm from '@/components/forms/login/LoginForm.vue';

export default {
  components: { LoginForm },
};
</script>

<style lang="scss"></style>
