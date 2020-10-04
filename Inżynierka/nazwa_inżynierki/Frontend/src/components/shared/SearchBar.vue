<template>
  <div id="search-bar">
    <input type="search" name="search-bar" id="search-bar-form" />
  </div>
</template>

<script>
export default {
  name: 'search-bar',
};
</script>

<style lang="scss" scoped>
#search-bar {
  display: flex;
  align-items: center;

  #search-bar-form {
    height: 35px;
    width: 23vw;
    min-width: 200px;
    border: none;
    border-radius: 20px;
  }
}
</style>
