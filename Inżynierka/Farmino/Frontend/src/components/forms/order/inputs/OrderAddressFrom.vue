<template>
  <div>
    <div id="form-wraper">
      <h1>
        Czy posiadasz profil?
      </h1>
      <hr />
      <h3>Jeśli tak, to czy chcesz go wykorzystać jako dane odbiory?</h3>
      <div id="interface">
        <button class="btn" @click="$router.push({ name: 'summary' }), setCustomAddress(false)">
          Tak
        </button>
        <button class="btn" @click="$router.push({ name: 'custom-address' })">Nie</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapMutations } from 'vuex';

export default {
  methods: {
    ...mapMutations({
      setCustomAddress: 'offer/SET_CUSTOM_ADDRESS',
    }),
  },
};
</script>

<style lang="scss" scoped>
#form-wraper {
  height: 25vh;
  width: 35vw;
  border: 1px solid rgb(224, 224, 224);
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-evenly;
  background: rgba(240, 240, 240, 0.877);
  box-shadow: 1px 1px 6px rgba(179, 179, 179, 0.746);

  h1 {
    color: rgb(95, 95, 95);
  }

  h3 {
    color: rgb(151, 151, 151);
  }

  hr {
    width: 18vw;
    border: 2px solid orange;
  }

  #interface {
    display: flex;
    align-items: center;
    justify-content: space-around;
    width: 30vw;
  }

  .btn {
    margin-top: 1rem;
    min-width: 10vw;
    padding: 0.2rem;
    font-size: 1rem;
    background: none;
    border: 1px solid rgb(202, 202, 202);
    transition: 0.1s ease-in;
    cursor: pointer;
  }

  .btn:hover {
    border: 1px solid orange;
    color: orange;
  }
}

@media screen and(max-width:$tablet) {
  #form-wraper {
    width: 80vw;
    height: 30vh;
    text-align: center;

    #interface {
      width: 80vw;
    }

    .btn {
      width: 30vw;
    }
  }
}
</style>
