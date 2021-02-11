<template>
  <div>
    <div id="realisation-form" :orderId="orderId">
      <label for="date">Data Realizacji</label>
      <input type="date" name="date" id="date" v-model="realsationDate" />
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'realisation-form',

  props: {
    orderId: {
      type: String,
      required: true,
    },
  },

  data() {
    return {
      realsationDate: '',
    };
  },

  methods: {
    ...mapActions({
      releaseOrder: 'order/RELEASE_ORDER',
    }),

    async releaseOrderAsync() {
      await this.releaseOrder({
        orderId: this.orderId,
        realsationDate: this.realsationDate,
      });
    },
  },
};
</script>

<style lang="scss" scoped>
#realisation-form {
  margin: 12rem 0;
  border: 1px solid rgb(212, 212, 212);
  width: 40vw;
  height: 60vh;
  display: flex;
}
</style>
