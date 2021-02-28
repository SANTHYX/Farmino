<template>
  <div>
    <div id="list-wraper">
      <div id="not-found">
        <not-found />
      </div>

      <div id="spinner">
        <loading-spinner />
      </div>
    </div>
  </div>
</template>

<script>
import NotFound from '../utils/NotFound.vue';
import LoadingSpinner from '../utils/LoadingSpinner.vue';

export default {
  name: 'observed-list',

  data() {
    return {};
  },

  components: {
    NotFound,
    LoadingSpinner,
  },
};
</script>

<style lang="scss" scoped>
#list-wraper {
  margin: 12rem 0;
  display: flex;
  justify-content: baseline;
  flex-wrap: wrap;
  border: 1px solid rgb(216, 216, 216);
  width: 70vw;
  min-width: 50vw;
  min-height: 80vh;
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);
}

@media screen and(max-width: $tablet) {
  #list-wraper {
    margin: 12rem 0;
    min-height: 90vh;
    width: 80vw;
    flex-direction: column;
  }
}
</style>
