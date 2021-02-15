<template>
  <div>
    <div id="client-order-item" :orderItem="orderItem">
      <div id="title" class="list-positioning">
        <h4>Tytuł</h4>
        <p>{{ orderItem.offer.title }}</p>
      </div>
      <div id="title" class="list-positioning">
        <h4>Tytuł</h4>
        <p>{{ orderItem.offer.title }}</p>
      </div>
      <button>XD</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'client-order-list-item',

  props: {
    orderItem: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style lang="scss" scoped>
#client-order-item {
  display: flex;
  justify-content: space-evenly;
  justify-items: center;
  flex-wrap: wrap;
  border-bottom: 1px solid rgb(211, 211, 211);

  .list-positioning {
    display: flex;
    flex-direction: column;
    text-align: center;
    margin: 0 0.5rem 0 0;
  }
}

@media screen and(max-width: $tablet) {
}
</style>
