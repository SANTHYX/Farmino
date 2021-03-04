<template>
  <div>
    <div id="auction-creator-form">
      <div id="picture-add">
        <picture-picker />
      </div>
      <div id="creator-form">
        <h1>Stwórz Aukcje</h1>
        <hr />
        <div id="inputs-wraper">
          <label for="title" :class="[!$v.auction.title.$error ? 'form-label' : 'error-label']"
            >Tytuł</label
          >
          <input
            type="text"
            name="title"
            :class="[!$v.auction.title.$error ? 'form-field' : 'error-field']"
            @blur="$v.auction.title.$touch()"
            v-model="$v.auction.title.$model"
          />
        </div>

        <div id="inputs-wraper">
          <label
            for="description"
            :class="[!$v.auction.description.$error ? 'form-label' : 'error-label']"
            >Opis Aukcji</label
          >
          <textarea
            name=""
            class="form-field"
            cols="30"
            rows="10"
            v-model="$v.auction.description.$model"
          ></textarea>
        </div>

        <div id="inputs-wraper">
          <label
            for="startDate"
            :class="[!$v.auction.startDate.$error ? 'form-label' : 'error-label']"
            >Początek</label
          >
          <input
            type="date"
            name=""
            id=""
            :class="[!$v.auction.startDate.$error ? 'form-field' : 'error-field']"
            v-model="$v.auction.startDate.$model"
          />
        </div>

        <div id="inputs-wraper">
          <label for="endDate" :class="[!$v.auction.endDate.$error ? 'form-label' : 'error-label']"
            >Koniec</label
          >
          <input
            type="date"
            name=""
            :class="[!$v.auction.endDate.$error ? 'form-field' : 'error-field']"
            v-model="$v.auction.endDate.$model"
          />
        </div>

        <div id="inputs-wraper">
          <label
            for="startingPrice"
            :class="[!$v.auction.startDate.$error ? 'form-label' : 'error-label']"
            >Cena Wywoławcza</label
          >
          <input
            type="number"
            name="startingPrice"
            :class="[!$v.auction.startingPrice.$error ? 'form-field' : 'error-field']"
            v-model.number="$v.auction.startingPrice.$model"
          />
        </div>
        <button @click="createAuctionAsync" :disabled="$v.auction.$invalid" class="btn">
          Stwórz
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import { required, decimal, minValue } from 'vuelidate/lib/validators';
import PicturePicker from '../../utils/PicturePicker.vue';

export default {
  name: 'auction-creator-form',

  data() {
    return {
      auction: {
        title: '',
        description: '',
        startDate: '',
        endDate: '',
        startingPrice: 0,
      },
    };
  },

  validations: {
    auction: {
      title: { required },
      description: { required },
      startDate: { required },
      endDate: { required },
      startingPrice: { required, decimal, minValue: minValue(0.1) },
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
      createAuction: 'auction/CREATE_AUCTION',
    }),

    createAuctionAsync() {
      this.createAuction({ ...this.auction, userName: this.userName });
    },
  },

  async created() {
    await this.$store.dispatch('auction/CREATE_AUCTIONER', this.$store.state.auth.userName);
  },
};
</script>

<style lang="scss" scoped>
#auction-creator-form {
  margin: 10rem 0;
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

      textarea {
        resize: none;
        height: 20vh;
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
  #auction-creator-form {
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
