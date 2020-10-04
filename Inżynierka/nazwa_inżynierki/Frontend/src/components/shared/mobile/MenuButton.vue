<template>
  <div id="menu-button" @click="sendState">
    <div id="wrapper">
      <div id="lines"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'menu-button',
  data() {
    return {
      clicked: false,
    };
  },
  methods: {
    sendState() {
      this.clicked = !this.clicked;
      this.$emit('button-state', this.clicked);
    },
  },
};
</script>

<style lang="scss" scoped>
#menu-button {
  display: none;

  #wrapper {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 45px;
    height: 45px;
    margin: 0.6rem;
    border: 2px solid white;
    border-radius: 7px;
    cursor: pointer;

    #lines {
      display: flex;
      width: 26.7px;
      border: 2px solid white;
      position: relative;
      border-radius: 10px;
    }

    #lines::before,
    #lines::after {
      content: '';
      position: absolute;
      display: flex;
      justify-self: center;
      align-self: center;
      width: 19px;
      border: 2px solid white;
      border-radius: 10px;
    }
    #lines::before {
      transform: translateY(12px);
    }
    #lines::after {
      transform: translateY(-12px);
    }
  }
}
@media screen and(max-width: $tablet) {
  #menu-button {
    display: flex;
  }
}
</style>
