<template>
  <div>
    <div id="error-message">
      {{ message }}
    </div>
  </div>
</template>

<script>
export default {
  name: 'error-message',

  props: {
    message: {
      type: String,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped>
#error-message{
  background: rgb(216, 63, 63);
}
</style>
