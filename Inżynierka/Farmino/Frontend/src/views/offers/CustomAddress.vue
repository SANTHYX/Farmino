<template>
  <div>
    <div id="custom-address">
      <custom-address-form />
    </div>
  </div>
</template>

<script>
import CustomAddressForm from '@/components/forms/order/inputs/CustomAddressForm.vue';

export default {
  components: {
    CustomAddressForm,
  },
};
</script>

<style lang="scss" scoped>
#custom-address {
  @include flex-centred-site;
}
</style>
