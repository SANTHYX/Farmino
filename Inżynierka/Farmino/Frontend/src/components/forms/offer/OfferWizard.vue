<template>
  <div>
    <div id="offer-wizard">
      <div id="flex-column">
        <div id="flex-row">
          <div id="title-wraper">
            <h1>Dodaj Fotografię</h1>
            <unicon name="plus-circle"></unicon>
          </div>
          <div id="flex-column">
            <div id="title-wraper">
              <div id="inputs-wraper">
                <input
                  type="text"
                  name="userName"
                  class="form-field"
                  v-model="$v.offer.title.$model"
                />
              </div>
            </div>
            <div id="title-wraper">
              <div id="inputs-wraper">
                <label for="userName" class="form-label">Cena</label>
                <input
                  type="text"
                  name="price"
                  class="form-field"
                  v-model.number="$v.offer.product.price.$model"
                />
              </div>
              <div id="inputs-wraper">
                <label for="userName" class="form-label">Ilosc</label>
                <input
                  type="text"
                  name="quantity"
                  class="form-field"
                  v-model.number="$v.offer.product.quantity.$model"
                />
              </div>
              <div id="inputs-wraper">
                <select class="form-field" v-model.number="$v.offer.product.weight.unit.$model">
                  <option value="0">g</option>
                  <option value="1">dkg</option>
                  <option value="2">g</option>
                  <option value="3">kg</option>
                  <option value="4">T</option>
                </select>
              </div>
              <div id="inputs-wraper">
                <label for="userName" class="form-label">Wartosc</label>
                <input
                  type="text"
                  name="userName"
                  class="form-field"
                  v-model.number="$v.offer.product.weight.value.$model"
                />
              </div>
            </div>
          </div>
        </div>
        <div id="title-wraper">
          <h1>Dodaj Opis</h1>
          <div id="inputs-wraper">
            <label for="userName" class="form-label">Login</label>
            <textarea
              name=""
              class="form-field"
              cols="30"
              rows="10"
              v-model="$v.offer.description.$model"
            ></textarea>
          </div>
        </div>
        <button :disabled="$v.offer.$invalid" @click="submit()">Submit</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import { required, minValue, maxValue } from 'vuelidate/lib/validators';

export default {
  data() {
    return {
      offer: {
        title: '',
        description: '',
        product: {
          price: 0,
          quantity: 0,
          weight: {
            unit: 0,
            value: 0,
          },
        },
      },
    };
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
    async submit() {
      await this.createOffer({
        userName: this.userName,
        title: this.offer.title,
        description: this.offer.description,
        product: this.offer.product,
      });
    },
  },

  validations: {
    offer: {
      title: { required },
      description: { required },
      product: {
        price: { required, minValue: minValue(1.0) },
        quantity: { minValue: minValue(1.0) },
        weight: {
          unit: { required, minValue: minValue(0), maxValue: maxValue(4) },
          value: { required, minValue: minValue(1) },
        },
      },
    },
  },

  async beforeCreate() {
    await this.$store
      .dispatch('offer/CREATE_FARMER', {
        userName: this.$store.state.auth.userName,
      })
      .catch(() => {});
  },
};
</script>

<style lang="scss" scoped>
#offer-wizard {
  padding: 1.2rem;
  border: 1px solid rgb(209, 209, 209);
  display: flex;
  flex-wrap: wrap;
  box-shadow: 2px 2px 8px rgba(128, 128, 128, 0.699);

  #flex-column {
    display: flex;
    justify-content: space-between;
    flex-direction: column;

    #title-wraper {
      h1 {
        font-weight: lighter;
        font-size: 1.8rem;
      }
    }
  }

  #flex-row {
    display: flex;
    flex-direction: row;
  }
}
@media screen and(max-width: $tablet) {
  #offer-wizard {
    margin: 5rem 0;
    #flex-row {
      flex-direction: column;
    }
  }
}
</style>
