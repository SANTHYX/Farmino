<template>
  <div>
    <div id="showcase">
      <div id="hero-image">
        <div id="text-wraper">
          <h1><span>Wymieniaj I Nabywaj</span> Nie Ruszajac Się Z Domu</h1>
          <p>Licytuj oraz kupuj przedmioty szybko, wygodnie i bezpiecznie</p>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
#showcase {
  display: flex;
  justify-content: center;
  #hero-image {
    display: flex;
    flex-direction: column;
    justify-content: center;
    background: linear-gradient(0deg, rgba(226, 221, 137, 0.66) 0%, rgba(184, 144, 15, 0.64) 100%),
      url('../../../assets/images/Farmino_background.png') no-repeat center center/cover;
    height: 80vh;
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
  }
}
@media screen and(max-width:880px) {
  #content {
    #showcase {
      #hero-image {
        height: 100vh;
        #text-wraper {
          width: 70vw;
          text-align: center;
          align-self: center;
          margin: 3rem 0 0 0;
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
