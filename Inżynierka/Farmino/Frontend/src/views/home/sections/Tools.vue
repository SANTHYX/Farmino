<template>
  <div>
    <div id="tools-section">
      <div id="text-content">
        <h1>Serwis zapewnia</h1>
        <hr />
        <div id="cards-wraper">
          <div id="logic-card">
            <div id="img-wrap"></div>
            <div id="text">
              <h2>Darmowe Ogłoszenia</h2>
              <hr />
              <p>
                Wszelkie funkcje i możliwości serwisu są darmowe, wystarczy tylko założyć konto by
                cieszyć sie wszystkimi funkcjami bez limitu.
              </p>
            </div>
          </div>

          <div id="logic-card">
            <div id="img-wrap"></div>
            <div id="text">
              <h2>Logistyka</h2>
              <hr />
              <p>
                Każdy rolnik ma wsparcie ze strony aplikacji odnosnie podejmowania decyzji oraz
                zarządzania zamówieniami oraz mapy wspierające dojazdy do klientów
              </p>
            </div>
          </div>

          <div id="logic-card">
            <div id="img-wrap"></div>
            <div id="text">
              <h2>Logistyka</h2>
              <hr />
              <p>
                Każdy rolnik ma wsparcie ze strony aplikacji odnosnie podejmowania decyzji oraz
                zarządzania zamówieniami oraz mapy wspierające dojazdy do klientów
              </p>
            </div>
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

      #logic-card {
        display: flex;
        background: rgb(255, 255, 255);
        border: 1px solid rgb(187, 187, 187);
        box-shadow: 1px 1px 6px rgb(179, 179, 179);
        flex-wrap: wrap;
        width: 25vw;
        height: 50vh;
        transition: 0.1s ease-in;

        #text {
          padding: 1rem;
          border-top: 1px solid rgb(187, 187, 187);
          align-self: flex-end;

          hr {
            width: 15vw;
            border: 2px solid rgba(251, 172, 82, 0.767);
          }
        }
      }
    }

    #logic-card:hover {
      transform: translateY(-6px);
    }
  }
}

@media screen and(max-width: $tablet) {
  #tools-section {
    #text-content {
      h1 {
      }
      #cards-wraper {
        flex-direction: column;

        #logic-card {
          width: 80vw;
          margin: 3rem 0;

          #text {
            align-self: flex-end;

            hr {
              width: 45vw;
              border: 2px solid rgba(251, 172, 82, 0.767);
            }
          }
        }
      }
    }
  }
}
</style>
