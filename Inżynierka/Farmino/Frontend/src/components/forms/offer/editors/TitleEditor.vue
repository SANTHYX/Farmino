<template>
  <div>
    <div id="offer-creator">
      <div id="creator-wraper">
        <div id="title-editor">
          <div id="title-wraper">
            <h1>{{ offer.title }}</h1>
            <unicon name="edit" @click="titleEditor = !titleEditor"></unicon>
          </div>
          <div id="inputs-wraper" v-if="titleEditor">
            <label for="title" class="form-label">Tytuł oferty</label>
            <input type="text" name="userName" class="form-field" v-model="offer.title" />
          </div>
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
      titleEditor: false,
      offer: {
        title: 'Ustaw Tytuł Oferty',
      },
    };
  },
};
</script>

<style lang="scss" scoped>
#creator-wraper {
  margin: 0.5rem;
  padding: 1rem;
  border: 1px solid gainsboro;

  #title-wraper {
    display: flex;
    align-items: center;
    justify-content: center;

    h1 {
      margin: 0 0.5rem 0 0;
    }
  }

  #inputs-wraper {
    display: flex;
    flex-direction: column;
  }
}
</style>
