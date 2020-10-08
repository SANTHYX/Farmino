<template>
  <div id="mobile-menu" showMenu="showMenu">
    <ul v-if="showMenu">
      <router-link to="auctions" tag="li" exact="exact"><a>Aukcje</a></router-link>
      <li><a>Second</a></li>
      <li><a>Thrid</a></li>
      <li><a>Forth</a></li>
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
  font-family: 'Roboto Condensed', sans-serif;
  background: rgb(255, 255, 255);

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
