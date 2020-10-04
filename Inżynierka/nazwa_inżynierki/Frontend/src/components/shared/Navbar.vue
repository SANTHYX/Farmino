<template>
  <nav id="navbar">
    <h1><a href="#">Logo</a></h1>
    <div id="standard-menu">
      <ul>
        <li><a href="#">Item1</a></li>
        <li><a href="#">Item2</a></li>
        <li><a href="#">Item3</a></li>
        <li><a href="#">Item4</a></li>
      </ul>
    </div>
    <menu-button @button-state="ShowMenu"></menu-button>
  </nav>
</template>

<script>
import MenuButton from './mobile/MenuButton.vue';

export default {
  name: 'navbar',
  data() {
    return {
      showMenu: false,
    };
  },
  methods: {
    ShowMenu(input) {
      this.showMenu = input;
      console.log(this.showMenu);
    },
  },
  components: {
    MenuButton,
  },
};
</script>

<style lang="scss" scoped>
#navbar {
  font-family: 'Lato', sans-serif;
  display: flex;
  justify-content: space-around;
  background: rgb(57, 77, 143);

  a {
    font-weight: 700;
    color: white;
    text-decoration: none;
  }

  h1 {
    font-weight: 900;
    color: white;
    align-self: center;
  }
  #standard-menu {
    ul {
      display: flex;
      list-style: none;

      li {
        margin: 0 0.5rem;
        padding: 1.4rem;
      }
    }
  }
}

@media screen and(max-width: $tablet) {
  #standard-menu {
    display: none;
  }
}
</style>
