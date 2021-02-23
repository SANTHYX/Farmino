<template>
  <div>
    <div id="content">
      <div id="about-section">
        <div class="content-wraper">
          <div class="img-wrap"></div>
          <div class="text-wraper">
            <div class="text-fix">
              <h1>Oferty Z Całego Regionu</h1>
              <hr />
              <p>
                Z naszym serwisem będziesz mógł zamawiać produkty od małych gospodarstw zajmujących
                się przetwórstwem lub uprawami warzyw i czy owoców. Płatności są realizowane
                bezposrednio podczas dostaw. Model biznesowy aplikacji opiera się o złożenie
                zamówienia. Rolnik decyduje czy przyjmuje od ciebie ofertę czy nie. Pamiętaj, że
                możecie się ze sobą kontaktować i tak naprawdę serwis tylko informuje dwie strony o
                checi zawarcia transakcji.
              </p>
            </div>
          </div>
        </div>
      </div>
      <div id="auction-section">
        <div class="content-wraper">
          <div class="img-wrap"></div>
          <div class="text-wraper">
            <div class="text-fix">
              <h1>Oferty Z Całego Regionu</h1>
              <hr />
              <p>
                Z naszym serwisem będziesz mógł zamawiać produkty od małych gospodarstw zajmujących
                się przetwórstwem lub uprawami warzyw i czy owoców. Płatności są realizowane
                bezposrednio podczas dostaw. Model biznesowy aplikacji opiera się o złożenie
                zamówienia. Rolnik decyduje czy przyjmuje od ciebie ofertę czy nie. Pamiętaj, że
                możecie się ze sobą kontaktować i tak naprawdę serwis tylko informuje dwie strony o
                checi zawarcia transakcji.
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
#content {
  min-height: 60vh;
  background: linear-gradient(0deg, rgb(240, 240, 240) 0%, rgb(255, 255, 255) 100%);

  #about-section {
    margin-top: 5rem;
    display: flex;
    align-items: center;
    justify-content: center;

    .content-wraper {
      display: flex;
      justify-content: center;
      align-items: center;
      flex-wrap: wrap;
      margin-bottom: 1rem;

      .img-wrap {
        width: 30vw;
        min-height: 50vh;
        background: linear-gradient(
            0deg,
            rgba(245, 200, 118, 0.712) 0%,
            rgba(253, 221, 205, 0.596) 100%
          ),
          url('../../../assets/images/gabriel-jimenez-unsplash.jpg') no-repeat center center/cover;
      }

      .text-wraper {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        width: 40vw;
        background: rgb(231, 231, 231);
        min-height: 50vh;

        .text-fix {
          margin-left: 4rem;
          h1 {
            margin-bottom: 0.5rem;
            color: rgb(61, 61, 61);
          }

          p {
            color: rgb(61, 61, 61);
            width: 30vw;
          }

          hr {
            width: 22vw;
            align-self: flex-start;
            margin-bottom: 1rem;
            border: 2px solid rgba(251, 172, 82, 0.767);
          }
        }
      }
    }
  }
}

@media screen and(max-width: $tablet) {
  #content {
    #about-section {
      .content-wraper {
        flex-direction: column;

        .img-wrap {
          width: 80vw;
        }

        .text-wraper {
          width: 80vw;
          flex-direction: row;
          justify-content: center;
          align-items: center;

          .text-fix {
            margin: 0;
            width: 80vw;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;

            p {
              width: auto;
              text-align: center;
            }
            hr {
              align-self: center;
              width: 50vw;
            }
          }
        }
      }
    }
  }
}
</style>
