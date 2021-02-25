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
      this.$emit('mobile-menu-event', this.clicked);
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
    width: 36px;
    height: 36px;
    margin: 0.8rem 0.6rem;
    border: 2px solid rgb(42, 42, 42);
    border-radius: 7px;
    cursor: pointer;

    #lines {
      display: flex;
      width: 25.7px;
      border: 2px solid rgb(42, 42, 42);
      position: relative;
      border-radius: 10px;
    }

    #lines::before,
    #lines::after {
      content: '';
      position: absolute;
      z-index: 1;
      display: flex;
      justify-self: center;
      align-self: center;
      width: 18px;
      border: 2px solid rgb(42, 42, 42);
      border-radius: 10px;
      transition: 0.34s;
    }

    #lines::before {
      transform: translateY(7px);
    }

    #lines::after {
      transform: translateY(-7px);
    }
  }
}

@media screen and(max-width: $tablet) {
  #menu-button {
    display: flex;
  }
}
</style>
