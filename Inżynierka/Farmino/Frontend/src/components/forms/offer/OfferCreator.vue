<template>
  <div>
    <div id="offer-creator">
      <div id="creator-wraper">
        <div id="inputs-wraper">
          <label for="title" class="form-label">Tytuł oferty</label>
          <input type="text" name="userName" class="form-field" v-model="title" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'offer-creator',
  data() {
    return {
      offer: {
        title: '',
      },
    };
  },
};
</script>

<style lang="scss" scoped>
#creator-wraper {
  background: rgb(233, 231, 231);
  #inputs-wraper {
    display: flex;
    flex-direction: column;
  }
}
</style>
