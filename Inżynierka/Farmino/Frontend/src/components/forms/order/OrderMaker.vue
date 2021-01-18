<template>
  <div>
    <div id="order-maker">
      <input
        type="number"
        name="order-maker"
        id="order-maker"
        step=".01"
        class="small-form-field"
      />
      <button @click="moveToOrderCreate">Zamów</button>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    moveToOrderCreate() {
      this.$router.push('create-order');
    },
  },
};
</script>

<style lang="scss" scoped>
#order-maker {
  margin: 0.3rem 0;
  display: flex;
  flex-direction: column;
}
</style>
