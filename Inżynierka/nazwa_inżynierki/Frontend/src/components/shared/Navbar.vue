<template>
  <header id="navbar-wraper">
    <div id="logo">
      <router-link to="/" tag="h1"><a>FARMINO</a></router-link>
    </div>
    <nav id="navbar">
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
#navbar-wraper {
  position: fixed;
  width: 100vw;
  font-family: 'Roboto Condensed', sans-serif;

  #logo {
    display: flex;
    justify-content: center;
    background: white;
    border-bottom: 0.3px solid rgb(199, 199, 199);

    a {
      text-decoration: none;
      color: black;
    }
  }

  #navbar {
    display: flex;
    justify-content: space-around;
    background: white;

    a {
      font-weight: 400;
      color: rgb(0, 0, 0);
      text-decoration: none;
    }

    h1 {
      font-size: 1.8rem;
      color: rgb(0, 0, 0);
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
          padding: 1rem;
          transition: 0.34s;

          a {
            padding: 0.3rem;
            font-weight: 400;
          }
        }
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
