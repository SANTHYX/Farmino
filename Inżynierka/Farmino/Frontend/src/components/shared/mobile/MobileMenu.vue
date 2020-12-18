<template>
  <div id="mobile-menu" showMenu="showMenu">
    <ul v-if="showMenu">
      <router-link to="auctions" tag="li" exact="exact"><a>Aukcje</a></router-link>
      <router-link to="auctions" tag="li" exact="exact"><a>Aukcje</a></router-link>
      <router-link to="auctions" tag="li" exact="exact"><a>Aukcje</a></router-link>
      <router-link to="auctions" tag="li" exact="exact"><a>Aukcje</a></router-link>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'mobile-menu',
  props: {
    showMenu: Boolean,
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

    a {
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
  }
}
</style>
