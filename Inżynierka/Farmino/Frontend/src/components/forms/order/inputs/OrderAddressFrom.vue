<template>
  <div>
    <div id="form-wraper">
      <h1>
        Czy posiadasz profil?
      </h1>
      <hr />
      <h3>Jeśli tak, to czy chcesz go wykorzystać jako dane odbiory?</h3>
      <div id="interface">
        <button class="btn" @click="$router.push({ name: 'custom-address' })">Nie</button>
        <button class="btn" @click="$router.push({ name: 'summary' }), setCustomAddress(true)">
          Tak
        </button>
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
  height: 20vh;
  width: 30vw;
  border: 1px solid rgb(224, 224, 224);
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-evenly;
  background: rgb(240, 240, 240);

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
    justify-self: center;
    align-items: center;
  }

  .btn {
    min-width: 10vw;
  }
}
</style>
