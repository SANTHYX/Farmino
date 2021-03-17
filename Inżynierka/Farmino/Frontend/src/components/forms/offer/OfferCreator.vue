<template>
  <div>
    <div id="offer-creator">
      <div id="picture-add">
        <picture-picker @sendImage="setImage" />
      </div>

      <div id="creator-form">
        <h1>Kretor Ofert</h1>
        <hr />

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Tytuł</label>
          <input type="text" name="userName" class="form-field" v-model="offer.title" />
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Opis oferty</label>
          <textarea
            name=""
            class="form-field"
            cols="30"
            rows="10"
            v-model="offer.description"
          ></textarea>
        </div>

        <div id="fix">
          <div id="inputs-wraper">
            <label for="region" class="form-label">Województwo</label>
            <select name="region" id="region" class="small-form-field" v-model="offer.region">
              <option value="Dolnośląskie">Dolnoslaskie</option>
              <option value="KujawskoPomorskie">Kujawsko-Pomorskie</option>
              <option value="Lubelskie">Lubelskie</option>
              <option value="Lubuskie">Lubuskie</option>
              <option value="Łódzkie">Łódzkie</option>
              <option value="Małopolskie">Małopolskie</option>
              <option value="Mazowieckie">Mazowieckie</option>
              <option value="Opolskie">Opolskie</option>
              <option value="Podkarpackie">Podkarpackie</option>
              <option value="Podlaskie">Podlaskie</option>
              <option value="Pomorskie">Pomorskie</option>
              <option value="Śląskie">Śląskie</option>
              <option value="Świętokrzyskie">Świętokrzyskie</option>
              <option value="WarmińskoMazurskie">Warmińsko-Mazurskie</option>
              <option value="Wielkopolskie">Wielkopolskie</option>
              <option value="ZachodnioPomorskie">Zachodniopomorskie</option>
            </select>
          </div>

          <div id="inputs-wraper">
            <label for="" class="form-label">Kategoria</label>
            <select name="category" id="category" class="small-form-field" v-model="offer.category">
              <option value="warzywa">Warzywa</option>
              <option value="owoce">Owoce</option>
              <option value="przetwory">Przetwory</option>
              <option value="wedliny">Wędliny</option>
              <option value="nabial">Nabiał</option>
              <option value="pieczywo">Pieczywo</option>
            </select>
          </div>
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Cena jednostkowa</label>
          <input
            type="number"
            name="userName"
            class="form-field"
            v-model.number="offer.product.basePrice"
          />
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Jednostka Wagi</label>
          <select class="form-field" v-model.number="offer.product.baseWeightUnit">
            <option value="mg">mg</option>
            <option value="dkg">dkg</option>
            <option value="g">g</option>
            <option value="kg">kg</option>
            <option value="T">T</option>
            <option value="szt">sztuka</option>
          </select>
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label"
            >Próg Ilości({{ offer.product.baseWeightUnit }})</label
          >
          <input
            type="text"
            name="userName"
            class="form-field"
            v-model.number="offer.minQuantity"
          />
        </div>

        <div>
          <button @click="create" class="btn" :disabled="$v.offer.$invalid">Stwórz</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import { required, minValue, decimal } from 'vuelidate/lib/validators';
import PicturePicker from '../../utils/PicturePicker.vue';

export default {
  name: 'offer-creator',

  data() {
    return {
      offer: {
        title: '',
        description: '',
        minQuantity: 0,
        image: '',
        region: '',
        category: '',
        product: {
          basePrice: 0,
          baseWeightUnit: 0,
        },
      },
    };
  },

  validations: {
    offer: {
      title: { required },
      description: { required },
      minQuantity: { required, minValue: minValue(1) },
      image: { required },
      region: { required },
      category: { required },
      product: {
        basePrice: { required, decimal, minValue: minValue(1) },
        baseWeightUnit: { required },
      },
    },
  },

  components: {
    PicturePicker,
  },

  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      createOffer: 'offer/CREATE_OFFER',
    }),

    setImage(input) {
      this.offer.image = input;
    },

    create() {
      this.createOffer({
        userName: this.userName,
        ...this.offer,
      });
      this.$router.push({ name: 'offers' });
    },
  },

  async created() {
    await this.$store.dispatch('offer/CREATE_FARMER', {
      userName: this.$store.state.auth.userName,
    });
  },
};
</script>

<style lang="scss" scoped>
#offer-creator {
  margin: 9rem 0;
  display: flex;
  align-items: center;
  border: 1px solid rgb(216, 216, 216);
  background: rgba(185, 185, 185, 0.794);

  #creator-form {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    padding: 1rem;
    background: rgba(243, 243, 243, 0.835);
    border-bottom: 4px solid orange;

    h1 {
      color: rgb(117, 117, 117);
    }

    hr {
      display: flex;
      border: 2px solid orange;
      width: 10vw;
    }

    #fix {
      display: flex;
      justify-content: space-evenly;
    }

    #inputs-wraper {
      display: flex;
      flex-direction: column;

      .form-field {
        min-width: 20vw;
      }

      textarea {
        resize: none;
        height: 20vh;
        font-size: 1rem;
      }
    }
  }

  .btn {
    margin: 1rem 0;
    height: 40px;
    background: none;
    border: 1px solid rgb(182, 182, 182);
    width: 20vw;
    font-size: 1rem;
    background: none;
    color: rgb(255, 255, 255);
    background: rgb(233, 153, 4);
    transition: 0.2s ease-in;
  }

  .btn:hover {
    border: 1px solid orange;
    color: orange;
    background: none;
  }

  #picture-add {
    width: 30vw;
    height: auto;
  }
}

@media screen and(max-width: $tablet) {
  #offer-creator {
    margin: 12rem 0;
    flex-direction: column;

    #picture-add,
    #creator-form {
      width: 80vw;
    }

    #inputs-wraper {
      width: 80vw;

      .form-field {
        width: 74vw;
      }
    }

    .btn {
      width: 74vw;
    }
  }
}
</style>
