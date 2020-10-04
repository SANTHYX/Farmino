<template>
  <header id="navbar-wraper">
    <nav id="navbar">
      <router-link to="Home" tag="h1"><a>Logo</a></router-link>
      <search-bar></search-bar>
      <div id="standard-menu">
        <ul>
          <router-link to="auctions" tag="li" exact="exact"><a>Aukcje</a></router-link>
          <li><a href="#">Item2</a></li>
          <li><a href="#">Item3</a></li>
          <li><a href="#">Item4</a></li>
        </ul>
      </div>
      <menu-button @button-state="ShowMenu"></menu-button>
    </nav>
    <moblie-menu :showMenu="showMenu"></moblie-menu>
  </header>
</template>

<script>
import MenuButton from './mobile/MenuButton.vue';
import MoblieMenu from './mobile/MobileMenu.vue';
import SearchBar from './SearchBar.vue';

export default {
  name: 'navbar-wraper',
  components: {
    MenuButton,
    MoblieMenu,
    SearchBar,
  },
  data() {
    return {
      showMenu: false,
    };
  },
  methods: {
    ShowMenu(input) {
      this.showMenu = input;
    },
  },
};
</script>

<style lang="scss" scoped>
#navbar {
  font-family: 'Roboto Condensed', sans-serif;
  display: flex;
  justify-content: space-around;
  background: rgb(59, 179, 216);

  a {
    font-weight: 400;
    color: white;
    text-decoration: none;
  }

  h1 {
    font-size: 1.8rem;
    color: white;
    align-self: center;

    a {
      font-weight: 700;
    }
  }

  #standard-menu {
    ul {
      display: flex;
      list-style: none;

      li {
        font-size: 1.1rem;
        margin: 0 0.5rem;
        padding: 1.3rem;
        transition: 0.34s;
      }
      li:hover {
        background: rgb(103, 103, 236);
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
