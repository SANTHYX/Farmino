<template>
  <div id="navbar">
    <div id="logo">
      <router-link to="/" tag="h1"><a>FARMINO</a></router-link>
    </div>
    <div id="navbar">
      <search-bar></search-bar>
      <div id="nav-menu">
        <ul v-if="!isLogged">
          <router-link to="auctions" tag="li" exact="exact"><a>Aukcje</a></router-link>
          <router-link to="offers" tag="li" exact="exact"><a>Oferty</a></router-link>
          <router-link to="register" tag="li" exact="exact" id="registery-btn"
            ><a>Zarejestruj się</a></router-link
          >
          <router-link to="signin" tag="li" exact="exact" id="login-btn"
            ><a>Zaloguj się</a></router-link
          >
        </ul>
        <ul v-else>
          <router-link
            :to="{ name: 'Profile', params: { login: userLogin } }"
            tag="li"
            exact="exact"
            ><a>Mój Profil</a></router-link
          >
        </ul>
      </div>
      <menu-button @mobile-menu-event="ShowMenu"></menu-button>
    </div>
    <moblie-menu :showMenu="showMenu"></moblie-menu>
  </div>
</template>

<script>
import { mapGetters, mapState } from 'vuex';
import MenuButton from './mobile/MenuButton.vue';
import MoblieMenu from './mobile/MobileMenu.vue';
import SearchBar from './SearchBar.vue';

export default {
  name: 'navbar',
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
  computed: {
    ...mapGetters({
      isLogged: 'user/isLogged',
    }),
    ...mapState('user', {
      userLogin(state) {
        return state.user.login;
      },
    }),
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
  position: fixed;
  width: 100vw;
  #logo {
    display: flex;
    justify-content: center;
    background: rgb(253, 253, 253);
    border-bottom: 0.3px solid rgb(199, 199, 199);
    a {
      text-decoration: none;
      color: black;
    }
  }
  #navbar {
    display: flex;
    justify-content: space-around;
    background: rgb(253, 253, 253);
    border-bottom: 0.3px solid rgb(199, 199, 199);
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
    #nav-menu {
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
  #nav-menu {
    display: none;
  }
}
</style>
