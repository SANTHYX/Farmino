<template>
  <div>
    <div id="offer-list-item" :offerItem="offerItem">
      <div id="offer-img"></div>
      <div id="info-wraper">
        <h2>{{ offerItem.title }}</h2>
        <button @click="$router.push({ name: 'offer', params: { id: offerItem.id } })">
          Sprawdź
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'offer-item',

  props: {
    offerItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped>
#offer-list-item {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin: 1rem;
  border: 1px solid rgb(177, 177, 177);

  #offer-img {
    height: 220px;
    width: 20vw;
    align-self: center;
    background: rgb(122, 122, 122);
  }

  #info-wraper {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

    h2 {
      display: flex;
      text-align: center;
      margin: 0.4rem 0;
    }

    button {
      margin: 1rem 0;
    }
  }
}

@media screen and(max-width: $tablet) {
  #offer-list-item {
    #offer-img {
      width: 72vw;
    }
  }
}
</style>
