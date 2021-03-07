<template>
  <div>
    <div id="my-auction-item">
      <div id="auction-img">
        <img
          :src="`http://localhost:4800/Images/Auction/${auctionItem.imageName}`"
          :alt="auctionItem.imageName"
          id="img"
        />
      </div>

      <div id="auction-details">
        <div id="title-wraper">
          <h2>{{ auctionItem.title }}</h2>
          <div id="end">
            <unicon name="clock-two" fill="#494949" width="20" />
            <h3>Koniec</h3>
          </div>
        </div>

        <div id="region">
          <div id="location">
            <unicon name="globe" fill="gray" width="22" />
            <p>Pomorskie</p>
          </div>
          <p>{{ auctionItem.endDate | date }}</p>
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
  props: {
    auctionItem: {
      typ: Object,
      required: true,
    },
  },

  filters: {
    date(value) {
      let date = new Date(value).toLocaleDateString();

      if (date === '1.01.1') {
        date = 'Brak';
      }

      return date;
    },
  },
};
</script>

<style lang="scss" scoped>
#my-auction-item {
  display: flex;
  flex-direction: column;
  margin: 1rem;
  border: 1px solid rgb(177, 177, 177);
  background: rgb(245, 245, 245);
  width: 17vw;
  min-width: 240px;
  box-shadow: 1px 1px 6px rgb(179, 179, 179);
  transition: 0.3s all;
  color: rgb(73, 73, 73);

  #auction-img {
    display: flex;
    flex-direction: column;
    align-items: flex-end;
    height: 250px;
    width: 17vw;
    min-width: 240px;
    background: rgb(192, 192, 192);
    transition: 0.1s all;

    #img {
      height: 250px;
      width: 16.9vw;
    }
  }

  #auction-details {
    display: flex;
    flex-direction: column;
    padding: 1rem;

    #title-wraper {
      display: flex;
      align-items: center;
      justify-content: space-between;

      #end {
        display: flex;
      }
    }

    #region {
      display: flex;
      align-items: center;
      justify-content: space-between;

      #location {
        display: flex;
        align-items: center;
      }
    }
  }

  #interface {
    display: flex;
    justify-content: space-between;
    padding: 1rem;

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

#my-auction-item:hover {
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
  #my-auction-item {
    width: 73vw;

    #auction-img {
      width: 73vw;

      #img {
        width: 73vw;
      }
    }
  }
}
</style>
