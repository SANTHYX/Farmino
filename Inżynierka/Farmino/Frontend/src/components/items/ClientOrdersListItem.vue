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
      <button class="btn">Szczegóły</button>
      <button class="btn">Wyznacz Trasę</button>
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

  methods: {
    setAsReleased() {},
  },
};
</script>

<style lang="scss" scoped>
#client-order-item {
  display: flex;
  justify-content: space-evenly;
  justify-items: center;
  border-top: 1px solid rgb(211, 211, 211);
  border-bottom: 1px solid rgb(211, 211, 211);
  min-width: 20vw;
  padding: 0.5rem;

  .list-positioning {
    display: flex;
    flex-direction: column;
    text-align: center;
    margin: 0 0.7rem 0 0;
  }

  .btn {
    padding: 0.2rem;
    cursor: pointer;
  }
}

@media screen and(max-width: $tablet) {
  #client-order-item {
    width: 88vw;
  }
}
</style>
