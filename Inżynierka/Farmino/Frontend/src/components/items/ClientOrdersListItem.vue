<template>
  <div>
    <div id="client-order-item" :orderItem="orderItem">
      <div class="list-positioning">
        <div id="marker-circle" :style="{ background: generatedColor }" @click="generateColor">
          <div id="marker-inner-circle"></div>
        </div>
      </div>
      <div id="title" class="list-positioning">
        <h4>Tytuł</h4>
        <p>{{ orderItem.offer.title }}</p>
      </div>
      <div id="title" class="list-positioning">
        <h4>Tytuł</h4>
        <p>{{ orderItem.offer.title }}</p>
      </div>
      <button class="btn" @click="checkDetails"><unicon name="map-marker-info" /></button>
      <button
        class="btn"
        @click="
          getRouteNode({
            farmerNodes: user.profile.address.node,
            clientNodes: orderItem.orderDetails.address.node,
          })
        "
      >
        Trasa
      </button>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'client-order-list-item',

  props: {
    orderItem: {
      type: Object,
      required: true,
    },
  },

  data() {
    return {
      generatedColor: '#3fb1ce',
    };
  },

  computed: {
    ...mapGetters({
      user: 'user/GET_STATE_USER',
    }),
  },

  methods: {
    ...mapActions({
      getRouteNode: 'direction/GET_ROUTE_NODES',
    }),

    checkDetails() {
      this.$router.push({
        name: 'daily-deliver-overview',
        params: { id: this.orderItem.id },
      });
    },

    generateColor() {
      this.generatedColor = `#${Math.random()
        .toString(16)
        .slice(2, 8)}`;
    },
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
    justify-content: center;
    text-align: center;
    margin: 0 0.7rem 0 0;

    #marker-circle {
      height: 38px;
      width: 38px;
      border-radius: 300px;
      border: 2px solid rgba(0, 0, 0, 0.418);
      display: flex;
      justify-content: center;
      align-items: center;

      #marker-inner-circle {
        height: 18px;
        width: 18px;
        border-radius: 300px;
        background: rgb(246, 246, 246);
      }
    }
  }

  .btn {
    padding: 0.2rem;
    cursor: pointer;
    background: none;
  }
}

@media screen and(max-width: 845px) {
  #client-order-item {
    width: 88vw;
  }
}
</style>
