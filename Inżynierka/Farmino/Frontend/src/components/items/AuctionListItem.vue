<template>
  <div>
    <div id="auction-list-item" :auctionItem="auctionItem">
      <div id="auction-img"></div>
      <div id="info-wraper">
        <h2>{{ offerItem.title }}</h2>
        <button @click="$route.push({ name: 'auction', params: { id: auctionItem.id } })">
          Sprawdź
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'auction-item',

  props: {
    auctionItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped>
#auction-list-item {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin: 1rem;
  border: 1px solid rgb(177, 177, 177);
  box-shadow: 1px 1px 6px rgb(179, 179, 179);

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
      margin: 0.4rem 0;
    }

    button {
      margin: 1rem 0;
    }
  }
}

@media screen and(max-width: $tablet) {
  #auction-list-item {
    #auction-img {
      width: 73vw;
    }
  }
}
</style>
