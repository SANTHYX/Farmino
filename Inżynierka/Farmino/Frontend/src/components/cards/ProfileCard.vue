<template>
  <div id="profile-card" v-if="userState">
    <div id="profile-card-wraper">
      <div id="showcase">
        <div id="user-info">
          <h1>Witaj {{ userState.userName }}</h1>
          <unicon name="envelope"></unicon>
          <h4>{{ userState.email }}</h4>
        </div>
      </div>

      <div id="info-wraper" v-if="userState.profile">
        <div id="profile-info">
          <h3>Personalia</h3>
          <p>
            Imię i Nazwisko: {{ userState.profile.firstName + ' ' + userState.profile.lastName }}
          </p>
          <p>Nr.Telefonu: {{ userState.profile.phoneNumber }}</p>

          <button class="btn" @click="editProfile" v-if="isAuthorizedUser">
            Edytuj Personalia
          </button>
        </div>

        <div id="address-info">
          <h3>Adres</h3>
          <p>Miasto: {{ userState.profile.address.city }}</p>
          <p>Ulica: {{ userState.profile.address.street }}</p>
          <p>Kod Pocztowy: {{ userState.profile.address.postalCode }}</p>
          <p>Nr.Domu: {{ userState.profile.address.houseNumber }}</p>

          <button class="btn" @click="editAddress" v-if="isAuthorizedUser">Edytuj Address</button>
        </div>
      </div>

      <div id="no-profile-info" v-else>
        <unicon name="info-circle" width="50" height="50"></unicon>
        <p>{{ 'Profil nie istnieje należy go stworzyć' }}</p>
        <button id="btn" @click="createProfile">Stwórz Profil</button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
  name: 'profile-card',

  props: {
    id: {
      type: String,
    },
  },

  computed: {
    ...mapGetters({
      userState: 'user/GET_STATE_USER',
      userName: 'auth/GET_USERNAME',
      isAuthorized: 'auth/IS_AUTHORIZED',
    }),

    isAuthorizedUser() {
      return this.userName === this.id && this.isAuthorized;
    },
  },

  methods: {
    ...mapActions({
      getUserAsync: 'user/GET_USER',
    }),

    createProfile() {
      this.$router.push({ name: 'create-profile', redirect: this.$route.fullPath });
    },

    editProfile() {
      this.$router.push({ name: 'edit-profile' });
    },

    editAddress() {
      this.$router.push({ name: 'edit-address' });
    },
  },

  created() {
    this.getUserAsync(this.id);
  },
};
</script>

<style lang="scss" scoped>
#profile-card {
  margin: 12rem 0;
  #profile-card-wraper {
    border: 1px solid rgba(189, 189, 189, 0.932);
    box-shadow: 1px 1px 6px rgb(179, 179, 179);
    width: 30vw;
    flex-wrap: wrap;
    background: rgba(228, 228, 228, 0.884);

    #user-info {
      padding: 1rem;
      text-align: center;
      border: 1px solid rgba(185, 185, 185, 0.932);
      background: rgba(206, 206, 206, 0.911);
      border-top: 4px solid orange;
      color: rgb(95, 95, 95);
    }

    #info-wraper {
      display: flex;
      flex-direction: column;
      align-items: center;

      #profile-info {
        display: flex;
        flex-direction: column;
        text-align: center;
        align-items: center;
        padding: 1rem;
        border: 1px solid rgba(189, 189, 189, 0.932);
        width: 30vw;
      }

      #address-info {
        display: flex;
        flex-direction: column;
        text-align: center;
        justify-content: center;
        align-items: center;
        padding: 1rem;
        border: 1px solid rgba(189, 189, 189, 0.932);
        width: 30vw;
      }

      p {
        margin: 0.4rem;
        color: rgb(102, 102, 102);
      }

      h3 {
        color: rgb(82, 82, 82);
      }
    }

    #no-profile-info {
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      margin: 1rem 0;

      p {
        color: rgb(116, 116, 116);
      }
    }
  }
  .btn {
    margin: 1rem 0;
    padding: 0.5rem;
    background: none;
    border: 1px solid rgba(179, 179, 179, 0.733);
    font-weight: bold;
    font-size: 0.9rem;
    width: 200px;
    color: rgba(0, 0, 0, 0.658);
    transition: 0.1s ease-in;
  }

  .btn:hover {
    border: 1px solid rgb(241, 158, 2);
    color: rgb(240, 157, 4);
  }
}
</style>
