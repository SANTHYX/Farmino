<template>
  <div>
    <div id="offer-list-item" :offerItem="offerItem">
      <div id="offer-img"></div>
      <div id="info-wraper">
        <h2>{{ offerItem.title }}</h2>
        <h3>{{ offerItem.product.basePrice + 'zł/' + offerItem.product.baseWeightUnit }}</h3>
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
  background: rgb(243, 243, 243);
  width: 25vw;
  min-width: 240px;
  box-shadow: 1px 1px 6px rgb(179, 179, 179);

  #offer-img {
    height: 220px;
    width: 25vw;
    min-width: 240px;
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
      margin: 0.3rem 0;
    }

    h3 {
      color: rgb(199, 161, 36);
    }

    button {
      margin: 0.5rem 0;
    }
  }
}

@media screen and(max-width: $tablet) {
  #offer-list-item {
    width: 73vw;
    #offer-img {
      width: 73vw;
    }
  }
}
</style>
