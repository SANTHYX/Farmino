<template>
  <div>
    <div id="observed-list-item">
      <div id="offer-img">
        <img
          :src="`http://localhost:4800/Images/Offer/${observedItem.imageName}`"
          :alt="observedItem.imageName"
          id="img"
        />
      </div>
      <div id="offer-detail">
        <h2>{{ observedItem.title }}</h2>

        <div id="region">
          <unicon name="globe" fill="gray" width="23" />
          <p id="region-value">Lubelskie-Pomorskie</p>
        </div>
      </div>

      <div id="price-details">
        <h2>{{ `${observedItem.product.basePrice}zł/${observedItem.product.baseWeightUnit}` }}</h2>
        <button id="btn" @click="$router.push({ name: 'offer', params: { id: observedItem.id } })">
          Sprawdź
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    observedItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped>
#observed-list-item {
  display: flex;
  flex-direction: column;
  margin: 1rem;
  border: 1px solid rgb(177, 177, 177);
  background: rgb(245, 245, 245);
  width: 17vw;
  min-width: 240px;
  box-shadow: 1px 1px 6px rgb(179, 179, 179);
  transition: 0.1s all;

  #offer-img {
    height: 250px;
    width: 16.9vw;
    min-width: 240px;
    align-self: center;
    background: rgb(192, 192, 192);
    transition: 0.1s all;

    #img {
      height: 250px;
      width: 16.9vw;
    }
  }

  #offer-detail {
    display: flex;
    flex-direction: column;
    padding: 1rem;

    #region {
      display: flex;
      align-items: center;

      p {
        color: rgb(73, 73, 73);
      }
    }

    h2 {
      color: rgb(73, 73, 73);
    }
  }

  #price-details {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1rem;

    h2 {
      color: rgb(73, 73, 73);
      font-size: 1.3rem;
    }

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

#observed-list-item:hover {
  box-shadow: 1px 1px 12px rgb(156, 156, 156);
  transform: translateY(-5px);
  transition: all 0.3s ease;
  border-bottom: orange 5px solid;

  #price-details {
    #btn:hover {
      transition: 0.3s ease-in;
      background: none;
      border: 1px solid orange;
      color: rgb(233, 153, 4);
    }
  }
}

@media screen and(max-width: $tablet) {
  #observed-list-item {
    width: 73vw;

    #offer-img {
      width: 73vw;

      #img {
        width: 73vw;
      }
    }
  }
}
</style>
