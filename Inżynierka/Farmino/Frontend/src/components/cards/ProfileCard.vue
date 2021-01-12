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
          <button @click="editProfile" v-if="isAuthorizedUser">Edytuj Personalia</button>
        </div>
        <div id="address-info">
          <h3>Adres</h3>
          <p>Miasto: {{ userState.profile.address.city }}</p>
          <p>Ulica: {{ userState.profile.address.street }}</p>
          <p>Kod Pocztowy: {{ userState.profile.address.postalCode }}</p>
          <p>Nr.Domu: {{ userState.profile.address.houseNumber }}</p>
          <button @click="editAddress" v-if="isAuthorizedUser">Edytuj Address</button>
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
      this.$router.push({ name: 'create-profile' });
    },
    editProfile() {
      this.$router.push({ name: 'edit-profile' });
    },
    editAddress() {
      this.$router.push({ name: 'edit-address' });
    },
  },
  async created() {
    await this.getUserAsync(this.id);
  },
};
</script>

<style lang="scss" scoped>
#profile-card {
  #profile-card-wraper {
    border: 1px solid rgba(189, 189, 189, 0.932);
    box-shadow: 1px 1px 6px rgb(179, 179, 179);
    border-radius: 10px;
    width: 30vw;
    min-width: 340px;
    flex-wrap: wrap;
    #user-info {
      padding: 1rem;
      text-align: center;
      border-radius: 10px 10px 0 0;
      border: 1px solid rgba(189, 189, 189, 0.932);
      background: rgb(252, 228, 162);
    }
    #info-wraper {
      display: flex;
      flex-direction: column;
      #profile-info {
        display: flex;
        flex-direction: column;
        text-align: center;
        padding: 1rem;
        border: 1px solid rgba(189, 189, 189, 0.932);
      }
      #address-info {
        display: flex;
        flex-direction: column;
        text-align: center;
        padding: 1rem;
        border-radius: 0px 0px 10px 10px;
        border: 1px solid rgba(189, 189, 189, 0.932);
      }
      button {
        align-self: center;
      }
      p {
        margin: 0.4rem;
      }
    }
    #no-profile-info {
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      margin: 1rem 0;
      #btn {
        margin: 1rem 0;
        padding: 0.2rem;
        background: rgb(235, 209, 63);
        border: 2px solid rgba(179, 179, 179, 0.733);
        border-radius: 7px;
        font-weight: bold;
        color: rgba(0, 0, 0, 0.658);
      }
    }
  }
}
</style>
