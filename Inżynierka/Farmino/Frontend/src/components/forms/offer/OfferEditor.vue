<template>
  <div>
    <div id="offer-creator">
      <div id="creator-form">
        <h1>Edytor Ofert</h1>
        <hr />

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Tytuł</label>
          <input
            type="text"
            name="userName"
            :class="[!$v.offer.title.$error ? 'form-field' : 'error-field']"
            @blur="$v.offer.title.$touch()"
            v-model="offer.title"
          />

          <div id="error-message-wraper" v-if="$v.offer.title.$error">
            <p class="error-message" v-if="!$v.offer.title.required">Pole jest wymagane</p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Opis oferty</label>
          <textarea
            name=""
            :class="[!$v.offer.description.$error ? 'form-field' : 'error-field']"
            cols="30"
            rows="10"
            @blur="$v.offer.description.$touch()"
            v-model="offer.description"
          ></textarea>

          <div id="error-message-wraper" v-if="$v.offer.description.$error">
            <p class="error-message" v-if="!$v.offer.description.required">Pole jest wymagane</p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Cena jednostkowa</label>
          <input
            type="number"
            name="userName"
            :class="[!$v.offer.product.basePrice.$error ? 'form-field' : 'error-field']"
            @blur="$v.offer.product.basePrice.$touch()"
            v-model.number="offer.product.basePrice"
          />

          <div id="error-message-wraper" v-if="$v.offer.product.basePrice.$error">
            <p class="error-message" v-if="!$v.offer.product.basePrice.required">
              Pole jest wymagane
            </p>
            <p class="error-message" v-if="!$v.offer.product.basePrice.minValue">
              Wartosć musi być większa od zera
            </p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label">Jednostka Wagi</label>
          <select
            class="form-field"
            @blur="$v.offer.product.baseWeightUnit.$touch()"
            v-model.number="offer.product.baseWeightUnit"
          >
            <option value="mg">mg</option>
            <option value="dkg">dkg</option>
            <option value="g">g</option>
            <option value="kg">kg</option>
            <option value="T">T</option>
            <option value="szt">sztuka</option>
          </select>

          <div id="error-message-wraper" v-if="$v.offer.product.baseWeightUnit.$error">
            <p class="error-message" v-if="!$v.offer.product.baseWeightUnit.required">
              Pole jest wymagane
            </p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label for="userName" class="form-label"
            >Próg Ilości({{ offer.product.baseWeightUnit }})</label
          >
          <input
            type="text"
            name="userName"
            :class="[!$v.offer.minQuantity.$error ? 'form-field' : 'error-field']"
            @blur="$v.offer.minQuantity.$touch()"
            v-model.number="offer.minQuantity"
          />

          <div id="error-message-wraper" v-if="$v.offer.minQuantity.$error">
            <p class="error-message" v-if="!$v.offer.minQuantity.required">Pole jest wymagane</p>
            <p class="error-message" v-if="!$v.offer.minQuantity.minValue">
              Warartość musi być odatnia
            </p>
          </div>
        </div>

        <div>
          <button @click="update" class="btn" :disabled="$v.offer.$invalid">Edytuj</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import { required, minValue, decimal } from 'vuelidate/lib/validators';

export default {
  name: 'offer-editor',

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
        baseWeightUnit: { required },
      },
    },
  },

  computed: {
    ...mapGetters({
      userName: 'auth/GET_USERNAME',
    }),
  },

  methods: {
    ...mapActions({
      updateOffer: 'offer/UPDATE_OFFER',
    }),

    async update() {
      await this.updateOffer({
        id: this.$route.params.id,
        userName: this.userName,
        ...this.offer,
      });
      this.$router.push({ name: 'offers' });
    },
  },
};
</script>

<style lang="scss" scoped>
#offer-creator {
  margin: 9rem 0;
  display: flex;
  align-items: center;
  @include container-border;
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
