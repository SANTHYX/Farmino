<template>
  <div>
    <div id="offer-creator">
      <div id="picture-add">
        <picture-picker />
      </div>
      <div id="creator-form">
        <h1>Kretor Ofert</h1>
        <hr />
        <div id="inputs-wraper">
          <label for="userName" class="form-label">Tytuł</label>
          <input type="text" name="userName" class="form-field" v-model="$v.offer.title.$model" />
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Opis oferty</label>
          <textarea
            name=""
            class="form-field"
            cols="30"
            rows="10"
            v-model="$v.offer.description.$model"
          ></textarea>
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Cena jednostkowa</label>
          <input
            type="number"
            name="userName"
            class="form-field"
            v-model.number="$v.offer.product.basePrice.$model"
          />
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Jednostka Wagi</label>
          <select class="form-field" v-model.number="$v.offer.product.baseWeightUnit.$model">
            <option value="0">mg</option>
            <option value="1">dkg</option>
            <option value="2">g</option>
            <option value="3">kg</option>
            <option value="4">T</option>
          </select>
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Ilość</label>
          <input
            type="text"
            name="userName"
            class="form-field"
            v-model.number="$v.offer.minQuantity.$model"
          />
        </div>

        <div>
          <button @click="create" :disabled="$v.offer.$invalid" class="btn">Stwórz</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import {
  required, minValue, maxValue, decimal,
} from 'vuelidate/lib/validators';
import PicturePicker from '../../utils/PicturePicker.vue';

export default {
  name: 'offer-creator',

  data() {
    return {
      offer: {
        title: '',
        description: '',
        minQuantity: 0,
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
      product: {
        basePrice: { required, decimal, minValue: minValue(1) },
        baseWeightUnit: { required, minValue: minValue(0), maxValue: maxValue(4) },
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

    create() {
      this.createOffer({
        userName: this.userName,
        ...this.offer,
      });
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
  display: flex;
  align-items: center;
  border: 1px solid rgb(216, 216, 216);

  #creator-form {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    padding: 1rem;
    background: rgb(243, 243, 243);
    border-bottom: 4px solid orange;

    h1 {
      color: rgb(117, 117, 117);
    }

    hr {
      display: flex;
      border: 2px solid orange;
      width: 10vw;
    }

    #inputs-wraper {
      display: flex;
      flex-direction: column;

      .form-field {
        min-width: 20vw;
      }
    }
  }

  .btn {
    margin: 1rem 0;
    height: 40px;
    background: none;
    border: 1px solid rgb(182, 182, 182);
    width: 20vw;
    background: none;
  }

  .btn:hover {
    transition: 0.2s ease-in;
    border: 1px solid orange;
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
