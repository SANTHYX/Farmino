<template>
  <header id="navbar-wraper">
    <nav id="navbar">
      <router-link to="Home" tag="h1"><a>Logo</a></router-link>
      <search-bar></search-bar>
      <div id="standard-menu">
        <ul>
          <router-link to="auctions" tag="li" exact="exact"><a>Aukcje</a></router-link>
          <router-link to="offers" tag="li" exact="exact"><a>Oferty</a></router-link>
          <router-link to="register" tag="li" exact="exact" id="registery-btn"
            ><a>Zarejestruj się</a></router-link
          >
          <router-link to="login" tag="li" exact="exact" id="login-btn"
            ><a>Zaloguj się</a></router-link
          >
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
  display: flex;
  justify-content: space-around;
  background: rgb(51, 102, 149);
  font-family: 'Roboto Condensed', sans-serif;

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
        padding: 1.4rem;
        transition: 0.34s;

        a {
          padding: 0.3rem;
          font-weight: 400;
        }
      }
      li:hover {
        background: rgb(152, 152, 241);
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
