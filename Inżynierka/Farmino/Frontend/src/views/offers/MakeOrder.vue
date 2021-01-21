<template>
  <div>
    <div id="make-order">
      <order-address-from />
    </div>
  </div>
</template>

<script>
import OrderAddressFrom from '@/components/forms/order/OrderAddressFrom.vue';

export default {
  name: 'make-order',

  components: {
    OrderAddressFrom,
  },
};
</script>

<style lang="scss" scoped>
#make-order {
  @include flex-centred-site;
}
</style>
