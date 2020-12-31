<template>
  <div id="profile">
    <profile-form></profile-form>
  </div>
</template>

<script>
import ProfileForm from '../components/forms/profile/ProfileForm.vue';

export default {
  name: 'profile',
  components: {
    ProfileForm,
  },
};
</script>

<style lang="scss" scoped>
#profile {
  display: flex;
  align-items: center;
}
</style>
