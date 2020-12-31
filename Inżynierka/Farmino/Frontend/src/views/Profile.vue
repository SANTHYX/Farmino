<template>
  <div id="profile">
    <div id="contnet">
      <address-form />
    </div>
  </div>
</template>

<script>
import AddressForm from '../components/forms/profile/AddressForm.vue';

export default {
  name: 'profile',
  components: {
    AddressForm,
  },
};
</script>

<style lang="scss" scoped>
#profile {
  display: flex;
  align-items: center;
}
</style>
