<template>
  <div>
    <div id="list-wraper"></div>
  </div>
</template>

<script>
export default {
  name: 'auctioners-list',
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 0 0 1rem 0;
  display: flex;
  justify-content: baseline;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  width: 50vw;
  min-width: 40vw;
  min-height: 30vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
}
</style>
