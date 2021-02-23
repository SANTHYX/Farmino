<template>
  <div>
    <div id="tools-section">
      <div id="text-content">
        <h1>Serwis zapewnia</h1>
        <hr />
        <div id="cards-wraper">
          <div
            class="logic-card"
            @mouseover="showFreeOffers = true"
            @mouseleave="showFreeOffers = false"
          >
            <div class="img-wrap"></div>
            <transition name="fade">
              <div class="text-wraper" v-if="showFreeOffers">
                <h2>Darmowe Ogłoszenia</h2>
                <hr />
                <p>
                  Wszelkie funkcje i możliwości serwisu są darmowe, wystarczy tylko założyć konto by
                  cieszyć sie wszystkimi funkcjami bez limitu.
                </p>
              </div>
            </transition>
          </div>

          <div class="logic-card" @mouseover="showComfort = true" @mouseleave="showComfort = false">
            <div class="img-wrap" id="comfort-img"></div>
            <transition name="fade">
              <div class="text-wraper" v-if="showComfort">
                <h2>Wygoda</h2>
                <hr />
                <p>
                  Aplikacja jest wygodna,model biznesowy zoptymalizowany tak że jako platforma nie
                  ingerujemy w interesy klienta czy rolnika, jedyne czego oczekujemy to uczciwość po
                  obydwu stronach
                </p>
              </div>
            </transition>
            <div></div>
          </div>

          <div
            class="logic-card"
            @mouseover="showLogistics = true"
            @mouseleave="showLogistics = false"
          >
            <div class="img-wrap" id="logistic-img">
              <h1>Logistyka</h1>
            </div>
            <transition name="fade">
              <div class="text-wraper" v-if="showLogistics">
                <h2>Logistyka</h2>
                <hr />
                <p>
                  Każdy rolnik ma wsparcie ze strony aplikacji odnosnie podejmowania decyzji oraz
                  zarządzania zamówieniami oraz mapy wspierające dojazdy do klientów
                </p>
              </div>
            </transition>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      showLogistics: false,
      showFreeOffers: false,
      showComfort: false,
    };
  },
};
</script>

<style lang="scss" scoped>
#tools-section {
  min-height: 30vh;
  background: linear-gradient(0deg, rgb(240, 240, 240) 0%, rgb(255, 255, 255) 100%);

  #text-content {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

    h1 {
      margin-top: 3rem;
      color: rgb(66, 66, 66);
    }

    h3 {
      color: rgb(66, 66, 66);
    }

    hr {
      margin: 0.6rem 0;
      width: 30vw;
      color: whitesmoke;
    }

    #cards-wraper {
      display: flex;
      justify-content: space-evenly;
      flex-wrap: wrap;
      align-items: center;
      width: 100%;
      margin: 2rem 0;

      .logic-card {
        display: flex;
        background: rgb(255, 255, 255);
        border: 1px solid rgb(187, 187, 187);
        box-shadow: 1px 1px 6px rgb(179, 179, 179);
        flex-wrap: wrap;
        width: 25vw;
        height: 50vh;
        transition: 0.1s ease-in;

        .img-wrap {
          height: 49.8vh;
          display: flex;
          justify-content: center;
          text-align: center;
          align-items: flex-start;

          h1 {
            color: rgb(230, 230, 230);
            font-size: 3rem;
          }
        }

        .text-wraper {
          z-index: 1;
          padding: 1rem;
          border-top: 1px solid rgb(187, 187, 187);
          align-self: flex-end;
          position: fixed;
          background: whitesmoke;

          hr {
            width: 15vw;
            border: 2px solid rgba(251, 172, 82, 0.767);
          }
        }

        #logistic-img {
          background: linear-gradient(0deg, rgba(83, 83, 83, 0.63) 0%, rgba(0, 0, 0, 0.678) 100%),
            url('../../../assets/images/mapbox.png') no-repeat center center/cover;
          width: 50vw;
        }

        #comfort-img {
          background: linear-gradient(0deg, rgba(83, 83, 83, 0.63) 0%, rgba(0, 0, 0, 0.678) 100%),
            url('../../../assets/images/coen-staal-unsplash.jpg') no-repeat center center/cover;
          width: 50vw;
        }
      }
    }

    .logic-card:hover {
      transform: translateY(-6px);
    }
  }
}

@media screen and(max-width: $tablet) {
  #tools-section {
    #text-content {
      #cards-wraper {
        flex-direction: column;

        .logic-card {
          width: 80vw;
          margin: 0rem 0 3rem 0;

          .text-wraper {
            align-self: flex-end;

            hr {
              width: 45vw;
              border: 2px solid rgba(251, 172, 82, 0.767);
            }
          }
          #logistic-img,
          #comfort-img {
            width: 80vw;
          }
        }
      }
    }
  }
}
</style>
