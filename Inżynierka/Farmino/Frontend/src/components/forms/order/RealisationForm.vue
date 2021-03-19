<template>
  <div>
    <div id="realisation-form">
      <div id="form-wraper">
        <h1>Ustaw Detale Realizacji</h1>
        <hr />

        <div id="inputs-wraper">
          <label for="date" class="form-label">Data Realizacji</label>
          <input type="date" name="date" id="date" class="form-field" v-model="realsationDate" />
        </div>

        <button class="btn" @click="releaseOrderAsync">Realizuj</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'realisation-form',

  props: {
    id: {
      type: String,
      required: true,
    },
  },

  data() {
    return {
      realsationDate: '',
    };
  },

  methods: {
    ...mapActions({
      releaseOrder: 'order/RELEASE_ORDER',
    }),

    releaseOrderAsync() {
      this.releaseOrder({
        orderId: this.id,
        realisationDate: this.realsationDate,
      });
      this.$router.push({ name: 'my-delivers' });
    },
  },
};
</script>

<style lang="scss" scoped>
#realisation-form {
  #form-wraper {
    padding: 2rem;
    @include container-border;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    background: rgba(243, 243, 243, 0.856);

    hr {
      margin-top: 0.2rem;
      width: 240px;
      border: solid 3px rgb(255, 125, 4);
    }

    h1 {
      text-align: center;
      color: rgb(119, 119, 119);
    }

    #inputs-wraper {
      display: flex;
      flex-direction: column;
    }

    .btn {
      margin-top: 1rem;
      height: 30px;
      width: 15vw;
      background: none;
      border: 1px solid rgb(165, 165, 165);
      transition: 0s ease-in;
      font-size: 1rem;
    }

    .btn:hover {
      color: orange;
      border: 1px solid orange;
    }
  }
}
</style>
