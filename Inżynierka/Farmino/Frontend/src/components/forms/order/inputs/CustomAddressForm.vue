<template>
  <div>
    <div id="custom-order-details">
      <div id="customer-details">
        <div id="inputs-wraper">
          <h1>Dane Klienta</h1>
          <hr />
          <label
            for="firstName"
            :class="[!$v.orderDetails.firstName.$error ? 'form-label' : 'error-label']"
            >Imię</label
          >
          <input
            type="text"
            name="firstName"
            :class="[!$v.orderDetails.firstName.$error ? 'form-field' : 'error-field']"
            @blur="$v.orderDetails.firstName.$touch()"
            v-model="orderDetails.firstName"
          />

          <div id="error-message-wraper" v-if="$v.orderDetails.firstName.$error">
            <p class="error-message" v-if="!$v.orderDetails.firstName.required">
              Pole jest wymagane
            </p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label
            for="lastName"
            :class="[!$v.orderDetails.lastName.$error ? 'form-label' : 'error-label']"
            >Nazwisko</label
          >
          <input
            type="text"
            name="lastName"
            :class="[!$v.orderDetails.lastName.$error ? 'form-field' : 'error-field']"
            @blur="$v.orderDetails.lastName.$touch()"
            v-model="orderDetails.lastName"
          />
          <div id="error-message-wraper" v-if="$v.orderDetails.lastName.$error">
            <p class="error-message" v-if="!$v.orderDetails.lastName.required">
              Pole jest wymagane
            </p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label
            for="phoneNumber"
            :class="[!$v.orderDetails.phoneNumber.$error ? 'form-label' : 'error-label']"
            >Numer Telefonu</label
          >
          <input
            type="text"
            name="phoneNumber"
            :class="[!$v.orderDetails.phoneNumber.$error ? 'form-field' : 'error-field']"
            @blur="$v.orderDetails.phoneNumber.$touch()"
            v-model="orderDetails.phoneNumber"
          />
          <div id="error-message-wraper" v-if="$v.orderDetails.phoneNumber.$error">
            <p class="error-message" v-if="!$v.orderDetails.phoneNumber.required">
              Pole jest wymagane
            </p>
            <p class="error-message" v-if="!$v.orderDetails.phoneNumber.numeric">
              Nie wymaga podania znaków
            </p>
            <p class="error-message" v-if="!$v.orderDetails.phoneNumber.isPhoneNumber">
              Nie prawidłowa długość numeru
            </p>
          </div>
        </div>
      </div>

      <div id="address-details">
        <h1>Adres Dostawy</h1>
        <hr />
        <div id="inputs-wraper">
          <label
            for="city"
            :class="[!$v.orderDetails.address.city.$error ? 'form-label' : 'error-label']"
            >Miasto</label
          >
          <input
            type="text"
            name="city"
            :class="[!$v.orderDetails.address.city.$error ? 'form-field' : 'error-field']"
            @blur="$v.orderDetails.address.city.$touch()"
            v-model="orderDetails.address.city"
          />
          <div id="error-message-wraper" v-if="$v.orderDetails.address.city.$error">
            <p class="error-message" v-if="!$v.orderDetails.address.city.required">
              Pole jest wymagane
            </p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label
            for="street"
            :class="[!$v.orderDetails.address.street.$error ? 'form-label' : 'error-label']"
            >Ulica</label
          >
          <input
            type="text"
            name="street"
            :class="[!$v.orderDetails.address.street.$error ? 'form-field' : 'error-field']"
            @blur="$v.orderDetails.address.street.$touch()"
            v-model="orderDetails.address.street"
          />
          <div id="error-message-wraper" v-if="$v.orderDetails.address.street.$error">
            <p class="error-message" v-if="!$v.orderDetails.address.street.required">
              Pole jest wymagane
            </p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label
            for="postalCode"
            :class="[!$v.orderDetails.address.postalCode.$error ? 'form-label' : 'error-label']"
            >Kod Pocztowy</label
          >
          <input
            type="text"
            name="postalCode"
            :class="[!$v.orderDetails.address.postalCode.$error ? 'form-field' : 'error-field']"
            @blur="$v.orderDetails.address.postalCode.$touch()"
            v-model="orderDetails.address.postalCode"
          />
          <div id="error-message-wraper" v-if="$v.orderDetails.address.postalCode.$error">
            <p class="error-message" v-if="!$v.orderDetails.address.postalCode.required">
              Pole jest wymagane
            </p>
          </div>
        </div>

        <div id="inputs-wraper">
          <label
            for="houseNumber"
            :class="[!$v.orderDetails.address.houseNumber.$error ? 'form-label' : 'error-label']"
            >Numer Domu</label
          >
          <input
            type="text"
            name="houseNumber"
            :class="[!$v.orderDetails.address.houseNumber.$error ? 'form-field' : 'error-field']"
            @blur="$v.orderDetails.address.houseNumber.$touch()"
            v-model="orderDetails.address.houseNumber"
          />
          <div id="error-message-wraper" v-if="$v.orderDetails.address.houseNumber.$error">
            <p class="error-message" v-if="!$v.orderDetails.address.houseNumber.required">
              Pole jest wymagane
            </p>
          </div>
        </div>

        <div id="button-wraper">
          <button @click="moveToSummary">Zatwierdź</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapMutations } from 'vuex';
import { required, numeric } from 'vuelidate/lib/validators';

export default {
  name: 'custom-order-details',

  data() {
    return {
      orderDetails: {
        firstName: '',
        lastName: '',
        phoneNumber: '',
        address: {
          city: '',
          street: '',
          postalCode: '',
          houseNumber: '',
        },
      },
    };
  },

  validations: {
    orderDetails: {
      firstName: { required },
      lastName: { required },
      phoneNumber: {
        required,
        numeric,
        isPhoneNumber(value) {
          return value.length === 9 || value.length === 11;
        },
      },
      address: {
        city: { required },
        street: { required },
        postalCode: { required },
        houseNumber: { required },
      },
    },
  },

  computed: {
    ...mapGetters({
      order: 'offer/GET_ORDER',
      offer: 'offer/GET_OFFER',
      user: 'user/GET_STATE_USER',
    }),
  },

  methods: {
    ...mapMutations({
      setCustomOrderDetails: 'offer/SET_CUSTOM_ORDER_DETAILS',
    }),

    moveToSummary() {
      this.$router.push({ name: 'summary' });
      this.setCustomOrderDetails(this.orderDetails);
    },
  },

  created() {
    this.$store.commit('offer/SET_CUSTOM_ADDRESS', true);
  },
};
</script>

<style lang="scss" scoped>
#custom-order-details {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;

  #customer-details {
    margin: 1rem 0.6rem;

    h1 {
      text-align: center;
    }
  }

  #address-details {
    margin: 1rem 0.6rem;

    h1 {
      text-align: center;
    }
  }

  #inputs-wraper {
    display: flex;
    flex-direction: column;
  }
  #button-wraper {
    margin: 0.5rem 0;
    display: flex;
    justify-content: center;
  }
}
</style>
