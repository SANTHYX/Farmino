<template>
  <div id="mobile-menu" showMenu="showMenu">
    <ul v-if="showMenu && !isAuthorized">
      <router-link :to="{ name: 'auctions' }" exact="exact"
        ><li><a>Aukcje</a></li></router-link
      >
      <router-link :to="{ name: 'offers' }" exact="exact"
        ><li><a>Oferty</a></li></router-link
      >
      <router-link :to="{ name: 'register' }" exact="exact"
        ><li><a>Rejestracja</a></li></router-link
      >
      <router-link :to="{ name: 'login' }" exact="exact"
        ><li><a>Zaloguj się</a></li></router-link
      >
    </ul>
    <ul v-if="showMenu && isAuthorized">
      <router-link :to="{ name: 'auctions' }" exact="exact"
        ><li><a>Aukcje</a></li></router-link
      >
      <router-link :to="{ name: 'offers' }" exact="exact"
        ><li><a>Oferty</a></li></router-link
      >
      <router-link :to="{ name: 'profile', params: { id: userName } }" exact="exact"
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

  li {
    list-style: none;
    padding: 1rem 0;
    transition: 0.34s;
    text-decoration: none;
    a {
      text-align: center;
      font-weight: 400;
      font-size: 1.15rem;
      padding: 1rem 100vw;
      text-decoration: none;
      color: rgb(0, 0, 0);
      border-bottom: 0.3px solid rgb(199, 199, 199);
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
