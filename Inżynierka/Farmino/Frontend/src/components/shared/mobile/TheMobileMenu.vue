<template>
  <div id="mobile-menu" showMenu="showMenu">
    <ul v-if="showMenu && !isAuthorized">
      <router-link :to="{ name: 'auctions' }" exact="exact" id="list-fix"
        ><li><a>Aukcje</a></li></router-link
      >

      <router-link :to="{ name: 'offers' }" exact="exact" id="list-fix"
        ><li><a>Oferty</a></li></router-link
      >

      <router-link :to="{ name: 'register' }" exact="exact" id="list-fix"
        ><li><a>Rejestracja</a></li></router-link
      >

      <router-link :to="{ name: 'login' }" exact="exact" id="list-fix"
        ><li><a>Zaloguj się</a></li></router-link
      >
    </ul>

    <ul v-if="showMenu && isAuthorized">
      <router-link :to="{ name: 'offers' }" exact="exact" id="list-fix"
        ><li><a>Oferty</a></li></router-link
      >

      <router-link :to="{ name: 'offer-creator' }" exact="exact" id="list-fix"
        ><li><a>Stwórz Oferte</a></li></router-link
      >

      <router-link :to="{ name: 'my-offers' }" exact="exact" id="list-fix"
        ><li><a>Moje Oferty</a></li></router-link
      >

      <router-link :to="{ name: 'observed' }" exact="exact" id="list-fix"
        ><li><a>Obserwowane</a></li></router-link
      >
      <router-link :to="{ name: 'my-orders' }" exact="exact" id="list-fix"
        ><li><a>Moje Zamówienia</a></li></router-link
      >

      <router-link :to="{ name: 'my-delivers' }" exact="exact" id="list-fix"
        ><li><a>Moje Dostawy</a></li></router-link
      >

      <router-link :to="{ name: 'daily-delivers' }" exact="exact" id="list-fix"
        ><li><a>RealiDostawy</a></li></router-link
      >

      <router-link :to="{ name: 'profile', params: { id: userName } }" exact="exact" id="list-fix"
        ><li><a>MójProfil</a></li></router-link
      >

      <li><a @click.prevent="Logout">Wyloguj</a></li>
    </ul>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'mobile-menu',

  props: {
    showMenu: Boolean,
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

    async Logout() {
      await this.LogoutUser();
      await this.$router.push('/').catch(() => {});
    },
  },
};
</script>

<style lang="scss" scoped>
#mobile-menu {
  display: none;
  justify-content: center;
  align-items: center;
  background: rgb(253, 251, 251);

  ul {
    text-decoration: none;

    #list-fix {
      text-decoration: none;
    }

    li {
      list-style: none;
      padding: 0.5rem 0;
      transition: 0.34s;
      border-bottom: 0.3px solid rgb(199, 199, 199);

      a {
        display: flex;
        flex-direction: column;
        text-align: center;
        font-weight: 400;
        font-size: 1.15rem;
        padding: 0.3rem 100vw;
        color: rgb(0, 0, 0);
      }
    }
  }

  li:active,
  li:hover {
    background: rgb(117, 212, 236);
  }
}

@media screen and(max-width:$tablet) {
  #mobile-menu {
    display: flex;
    text-align: center;
  }
}
</style>
