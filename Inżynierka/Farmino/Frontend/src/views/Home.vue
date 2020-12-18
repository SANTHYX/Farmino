<template>
  <div id="home">
    <div id="content">
      <div id="showcase">
        <div id="hero-image">
          <div id="text-wraper">
            <h1><span>Wymieniaj I Nabywaj</span> Nie Ruszajac Się Z Domu</h1>
            <p>Licytuj oraz kupuj przedmioty szybko, wygodnie i bezpiecznie</p>
          </div>
          <a href="#about-us" id="btn">Dowiedz się więcej</a>
        </div>
      </div>
      <div></div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'home',
};
</script>

<style lang="scss" scoped>
#content {
  #showcase {
    display: flex;
    justify-content: center;

    #hero-image {
      display: flex;
      flex-direction: column;
      justify-content: center;
      background: linear-gradient(0deg, rgba(226, 221, 137, 0.66) 0%,rgba(184, 144, 15, 0.64) 100%),
        url('../assets/images/noah-buscher-tractor-unsplash.jpg') no-repeat center center/cover;
      height: 100vh;
      width: 100%;
      #text-wraper {
        display: flex;
        flex-direction: column;
        width: 30vw;
        align-self: flex-start;
        font-weight: 700;
        font-size: 1.7rem;
        margin: 0 3rem;
        span {
          color: rgb(255, 255, 255);
        }
        p {
          margin-top: 0.5rem;
          font-size: 1.3rem;
        }
      }
      #btn {
        margin: 1rem 3rem;
        padding: 0.5rem;
        border: 2px solid rgb(255, 255, 255);
        background: rgba(91, 92, 33, 0.774);
        border-radius: 7px;
        text-align: center;
        width: 150px;
        text-decoration: none;
        color: white;
      }
    }
  }
}
@media screen and(max-width:880px) {
  #content {
    #showcase {
      #hero-image {
        #text-wraper {
          width: 70vw;
          text-align: center;
          align-self: center;
          margin: 0;
          font-size: 1.6rem;
        }
        #btn {
          margin: 1rem 0;
          align-self: center;
        }
      }
    }
  }
}
</style>
