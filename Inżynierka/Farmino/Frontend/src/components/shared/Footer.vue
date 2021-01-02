<template>
  <div>
    <footer id="the-footer">
      <h2>Footer</h2>
    </footer>
  </div>
</template>

<script>
export default {
  name: 'the-footer',
};
</script>

<style lang="scss" scoped>
#the-footer {
  z-index: 2;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 1rem;
  background: rgb(255, 255, 255);
  border-top: 0.3px solid rgb(199, 199, 199);
}
</style>
