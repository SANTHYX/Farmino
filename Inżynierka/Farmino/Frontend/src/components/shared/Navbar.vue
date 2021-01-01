<template>
  <div id="navbar">
    <div id="logo">
      <router-link to="home" tag="h1"><a>FARMINO</a></router-link>
    </div>
    <div id="navbar">
      <search-bar />
      <div id="nav-menu" v-if="!isAuthorized">
        <ul>
          <router-link tag="li" :to="{ name: 'auctions' }" exact="exact"><a>Aukcje</a></router-link>
          <router-link tag="li" :to="{ name: 'offers' }" exact="exact"><a>Oferty</a></router-link>
          <router-link tag="li" :to="{ name: 'register' }" exact="exact" id="registery-btn"
            ><a>Zarejestruj się</a></router-link
          >
          <router-link tag="li" :to="{ name: 'signin' }" exact="exact" id="registery-btn"
            ><a>Zaloguj się</a></router-link
          >
        </ul>
      </div>
      <div id="nav-menu" v-else>
        <ul>
          <router-link :to="{ name: 'auctions' }" exact="exact"
            ><li><a>Aukcje</a></li></router-link
          >
          <router-link tag="li" :to="{ name: 'offers' }" exact="exact"><a>Oferty</a></router-link>
          <router-link :to="{ name: 'profile', params: { id: userName } }" exact="exact"
            ><li><a>Mój Profil</a></li></router-link
          >
          <li><a href="#" @click.prevent="Logout">Wyloguj</a></li>
        </ul>
      </div>
      <menu-button @mobile-menu-event="ShowMenu" />
    </div>
    <moblie-menu :showMenu="showMenu" />
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
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
      isAuthorized: 'auth/IS_AUTHORIZED',
      userName: 'auth/GET_USERNAME',
    }),
  },
  methods: {
    ...mapActions({
      LogoutUser: 'auth/LOGOUT',
    }),
    ShowMenu(input) {
      this.showMenu = input;
    },
    async Logout() {
      await this.LogoutUser();
      this.$router.push('/');
    },
  },
};
</script>

<style lang="scss" scoped>
#navbar {
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
