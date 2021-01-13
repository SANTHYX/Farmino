<template>
  <div>
    <div id="offer-wizard">
      <div id="flex-column">
        <div id="flex-row">
          <photo-editor></photo-editor>
          <div id="flex-column">
            <title-editor></title-editor>
            <product-editor></product-editor>
          </div>
        </div>
        <description-editor></description-editor>
      </div>
    </div>
  </div>
</template>

<script>
import TitleEditor from './editors/TitleEditor.vue';
import ProductEditor from './editors/ProductEditor.vue';
import DescriptionEditor from './editors/DescriptionEditor.vue';
import PhotoEditor from './editors/PhotoEditor.vue';

export default {
  components: {
    TitleEditor,
    ProductEditor,
    DescriptionEditor,
    PhotoEditor,
  },
};
</script>

<style lang="scss" scoped>
#offer-wizard {
  padding: 1.2rem;
  border: 1px solid rgb(209, 209, 209);
  display: flex;
  flex-wrap: wrap;
  box-shadow: 2px 2px 8px rgba(128, 128, 128, 0.699);

  #flex-column {
    display: flex;
    justify-content: space-between;
    flex-direction: column;
  }

  #flex-row {
    display: flex;
    flex-direction: row;
  }
}
@media screen and(max-width: $tablet) {
  #offer-wizard {
    margin: 5rem 0;
    #flex-row {
      flex-direction: column;
    }
  }
}
</style>
