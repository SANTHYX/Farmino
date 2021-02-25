<template>
  <div>
    <div id="auction-list-item" :auctionItem="auctionItem">
      <div id="auction-img"></div>

      <div id="info-wraper">
        <h2>{{ auctionItem.title }}</h2>
        <button @click="$router.push({ name: 'auction', params: { id: auctionItem.id } })">
          Sprawdź
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'auction-list-item',

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
  margin: 1rem;
  border: 1px solid rgb(177, 177, 177);
  background: rgb(245, 245, 245);
  width: 17vw;
  min-width: 240px;
  box-shadow: 1px 1px 6px rgb(179, 179, 179);
  transition: 0.1s all;

  #auction-img {
    height: 250px;
    width: 17vw;
    min-width: 240px;
    align-self: center;
    background: rgb(192, 192, 192);
    transition: 0.1s all;
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
