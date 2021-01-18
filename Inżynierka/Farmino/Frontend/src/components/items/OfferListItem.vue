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
  border-radius: 10px;
  background: rgb(243, 243, 243);
  width: 27vw;
  box-shadow: 1px 1px 6px rgb(179, 179, 179);

  #offer-img {
    height: 220px;
    width: 27vw;
    align-self: center;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
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
    width: 73vw;
    #offer-img {
      width: 73vw;
    }
  }
}
</style>
