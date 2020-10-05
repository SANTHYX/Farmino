<template>
  <div id="showcase">
    <div id="hero-image">
      <div id="text-wraper">
        <h1><span>Wymieniaj I Nabywaj</span> Nie Ruszajac Się Z Domu</h1>
        <p>Licytuj oraz kupuj przedmioty szybko, wygodnie i bezpiecznie</p>
        <a href="#"></a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'showcase',
};
</script>

<style lang="scss" scoped>
#showcase {
  display: flex;
  justify-content: center;
  font-family: 'Roboto Condensed', sans-serif;

  #hero-image {
    position: absolute;
    display: flex;
    z-index: -1;
    top: 5%;
    background: linear-gradient(0deg, rgba(250, 246, 172, 0.66) 0%, rgba(209, 163, 13, 0.64) 100%),
      url('../../assets/images/noah-buscher-tractor-unsplash.jpg') no-repeat center center/cover;
    height: 100vh;
    width: 100vw;

    #text-wraper {
      display: flex;
      flex-direction: column;
      width: 30vw;
      align-self: center;
      font-weight: 700;
      font-size: 1.7rem;
      margin: 0 2rem;

      span {
        color: rgb(255, 255, 255);
      }

      p {
        margin-top: 0.5rem;
        font-size: 1.3rem;
      }
    }
  }
}
</style>
