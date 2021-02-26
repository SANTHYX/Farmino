<template>
  <div>
    <div id="auction-list-item" :auctionItem="auctionItem">
      <div id="auction-img">
        <h2>{{ '01:00:01' }}</h2>
      </div>

      <div id="auction-details">
        <h2>{{ auctionItem.title }}</h2>

        <div id="region">
          <unicon name="globe" fill="gray" width="22" />
          <p>Lubelskie-Pomorskie</p>
        </div>
      </div>

      <div id="interface">
        <h2>{{ 'XDD' }}</h2>
        <button id="btn" @click="$router.push({ name: 'auction', params: { id: auctionItem.id } })">
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
  transition: 0.3s all;

  #auction-img {
    height: 250px;
    width: 17vw;
    min-width: 240px;
    align-self: center;
    background: rgb(192, 192, 192);
    transition: 0.1s all;
  }

  #auction-details {
    display: flex;
    flex-direction: column;
    padding: 1rem;
    color: rgb(73, 73, 73);

    #region {
      display: flex;
      align-items: center;
    }
  }

  #interface {
    display: flex;
    justify-content: space-between;
    padding: 1rem;
    color: rgb(73, 73, 73);

    #btn {
      background: none;
      padding: 0.4rem;
      cursor: pointer;
      border: 1px solid rgb(185, 185, 185);
      width: 40%;
      font-size: 0.9rem;
    }
  }
}

#auction-list-item:hover {
  box-shadow: 1px 1px 12px rgb(156, 156, 156);
  transform: translateY(-5px);
  transition: all 0.3s ease;
  border-bottom: orange 5px solid;

  #interface {
    #btn:hover {
      transition: 0.3s ease-in;
      background: none;
      border: 1px solid orange;
      color: rgb(233, 153, 4);
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
