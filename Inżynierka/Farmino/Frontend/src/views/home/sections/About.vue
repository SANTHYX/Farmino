<template>
  <div>
    <div id="content">
      <div id="about-section">
        <div class="content-wraper">
          <div class="img-wrap" id="hands"></div>
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
        <div class="content-wraper">
          <div class="text-wraper">
            <div class="text-fix">
              <h1>Szukaj Okazji W Aukcjach</h1>
              <hr />
              <p>
                Ceny są nieprzychylne? Chcesz kupić coś w wiekszej ilości oszczędzając? Szukaj
                okazji w aukcjach.Moduł pozwala na wystawianie towarów gdzie to użytkownicy podają
                swoje propozycje.Dzięki niemu możesz nabyć hurtowo dużą ilość surowca bądź produktu.
              </p>
            </div>
          </div>
          <div class="img-wrap" id="hands"></div>
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
  min-height: 100vh;
  display: flex;
  justify-content: center;
  background: linear-gradient(0deg, rgba(240, 240, 240, 0.623) 0%, rgba(255, 255, 255, 0.692) 100%);

  #about-section {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;

    .content-wraper {
      display: flex;
      justify-content: center;
      align-items: center;
      flex-wrap: wrap;
      margin-bottom: 1rem;
      border: 1px solid rgb(218, 218, 218);

      .img-wrap {
        width: 30vw;
        min-height: 40vh;
      }

      #hands {
        background: linear-gradient(
            0deg,
            rgba(245, 200, 118, 0.71) 0%,
            rgba(253, 221, 205, 0.59) 100%
          ),
          url('../../../assets/images/gabriel-jimenez-unsplash.jpg') no-repeat center center/cover;
      }

      #id {
        background: grey;
      }

      .text-wraper {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        width: 40vw;
        background: rgb(214, 214, 214);
        min-height: 40vh;

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
      margin: 5rem 0;
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
