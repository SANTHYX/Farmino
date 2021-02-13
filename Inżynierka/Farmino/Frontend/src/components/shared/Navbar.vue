<template>
  <div>
    <div id="navbar-header">
      <div id="logo">
        <router-link to="home" tag="h1"><a>FARMINO</a></router-link>
      </div>
      <div id="navbar">
        <search-bar />
        <div id="nav-menu" v-if="!isAuthorized">
          <ul>
            <router-link :to="{ name: 'auctions' }" exact="exact" class="pop-up"
              ><li><a>Aukcje</a></li></router-link
            >
            <router-link :to="{ name: 'offers' }" exact="exact" class="pop-up"
              ><li><a>Oferty</a></li></router-link
            >
            <router-link :to="{ name: 'register' }" exact="exact" id="registery-btn" class="pop-up"
              ><li><a>Zarejestruj się</a></li></router-link
            >
            <router-link :to="{ name: 'login' }" exact="exact" id="login-btn" class="pop-up"
              ><li><a>Zaloguj się</a></li></router-link
            >
          </ul>
        </div>
        <div id="nav-menu" v-else>
          <ul>
            <div @mouseleave="showAuctionMenu = false">
              <router-link :to="{ name: 'auctions' }" exact="exact" class="pop-up"
                ><li @mouseover="showAuctionMenu = true">
                  <a>Aukcje</a>
                </li></router-link
              >
              <transition name="movedropdown">
                <div id="drop-menu" v-if="showAuctionMenu">
                  <router-link :to="{ name: 'home' }" exact="exact" class="pop-up"
                    ><li><a>Stwórz Aukcję</a></li></router-link
                  >
                  <router-link :to="{ name: 'home' }" exact="exact" class="pop-up"
                    ><li><a>Stwórz Aukcję</a></li></router-link
                  >
                </div>
              </transition>
            </div>
            <div @mouseleave="showOfferMenu = false">
              <router-link :to="{ name: 'offers' }" exact="exact" class="pop-up"
                ><li @mouseover="showOfferMenu = true"><a>Oferty</a></li></router-link
              >
              <transition name="movedropdown">
                <div id="drop-menu" v-if="showOfferMenu">
                  <router-link :to="{ name: 'offer-creator' }" exact="exact" class="pop-up"
                    ><li><a>Stwórz Oferte</a></li></router-link
                  >
                  <router-link :to="{ name: 'my-offers' }" exact="exact" class="pop-up"
                    ><li><a>Moje Oferty</a></li></router-link
                  >
                </div>
              </transition>
            </div>
            <div @mouseleave="showOrdersMenu = false">
              <router-link :to="{ name: 'orders' }" exact="exact" class="pop-up"
                ><li @mouseover="showOrdersMenu = true"><a>Zamówienia</a></li></router-link
              >
              <transition name="movedropdown">
                <div id="drop-menu" v-if="showOrdersMenu">
                  <router-link :to="{ name: 'my-orders' }" exact="exact" class="pop-up"
                    ><li><a>Moje Zamówienia</a></li></router-link
                  >
                  <router-link :to="{ name: 'my-delivers' }" exact="exact" class="pop-up"
                    ><li><a>Moje Dostawy</a></li></router-link
                  >
                  <router-link :to="{ name: 'daily-delivers' }" exact="exact" class="pop-up"
                    ><li><a>Realizuj Dostawy</a></li></router-link
                  >
                </div>
              </transition>
            </div>
            <router-link
              :to="{ name: 'profile', params: { id: userName } }"
              exact="exact"
              class="pop-up"
              ><li><a>Mój Profil</a></li></router-link
            >
            <li><a href="#" @click.prevent="Logout">Wyloguj</a></li>
          </ul>
        </div>
        <menu-button @mobile-menu-event="ShowMenu" />
      </div>
      <moblie-menu :showMenu="showMenu" />
    </div>
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
      showAuctionMenu: false,
      showOfferMenu: false,
      showOrdersMenu: false,
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
      await this.$router.push('/').catch(() => {});
    },
  },
};
</script>

<style lang="scss" scoped>
#navbar-header {
  position: fixed;
  width: 100%;
  box-shadow: 0 2px 1px rgba(204, 204, 204, 0.39);

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
      color: rgb(0, 0, 0);
      text-decoration: none;
    }

    h1 {
      font-size: 1.8rem;
      color: rgb(0, 0, 0);
      align-self: center;
    }

    #nav-menu {
      ul {
        display: flex;
        list-style: none;

        li {
          font-size: 1.1rem;
          padding: 1rem;

          a {
            padding: 0.3rem;
            font-weight: 400;
          }
        }
      }
    }
  }

  #drop-menu {
    display: flex;
    justify-content: flex-start;
    position: absolute;
    right: 0;
    top: 98.5%;
    width: 43vw;
    background: white;
    border: 1px solid rgb(204, 204, 204);
    box-shadow: 0 2px 1px rgba(211, 211, 211, 0.39);
  }
}

@media screen and(max-width: $tablet) {
  #navbar {
    #nav-menu {
      display: none;
    }
  }

  #auction-menu {
    display: none;
  }
}
</style>
