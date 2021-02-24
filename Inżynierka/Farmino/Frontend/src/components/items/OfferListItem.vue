<template>
  <div>
    <div id="offer-list-item" :offerItem="offerItem">
      <div id="offer-img"></div>
      <div id="offer-detail">
        <h2>{{ offerItem.title }}</h2>
        <div>
          <unicon name="globe" fill="red" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'offer-list-item',

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
  margin: 1rem;
  border: 1px solid rgb(177, 177, 177);
  background: rgb(255, 255, 255);
  width: 17vw;
  min-width: 240px;
  box-shadow: 1px 1px 6px rgb(179, 179, 179);
  transition: 0.1s all;

  #offer-img {
    height: 250px;
    width: 17vw;
    min-width: 240px;
    align-self: center;
    background: rgb(122, 122, 122);
    transition: 0.1s all;
  }

  #offer-detail {
    display: flex;
    justify-content: space-between;
    padding: 1rem;

    h2 {
      color: rgb(73, 73, 73);
    }
  }
}

#offer-list-item:hover {
  box-shadow: 1px 1px 12px rgb(156, 156, 156);
  transform: translateY(-5px);
  transition: all 0.1s ease;
  -moz-transition: all 0.5s ease;
  -webkit-transition: all 0.5s ease;
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
