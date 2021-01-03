<template>
  <div id="profile-card">
    <div id="profile-card-wraper">
      <div id="showcase">
        <div id="user-info">
          <h1>{{ user.userName }}</h1>
          <h5>{{ user.email }}</h5>
        </div>
        <div v-if="user.profile">
          <h1>Profil</h1>
          <p><strong>Imie:</strong>{{ user.profile.firstName }}</p>
          <p><strong>Nazwisko:</strong>{{ user.profile.lastName }}</p>
          <p><strong>Telefon:</strong>{{ user.profile.lastName }}</p>
          <h1>Adres</h1>
          <p><strong>Miasto:</strong>{{ user.profile.address.city }}</p>
          <p><strong>Ulica:</strong>{{ user.profile.address.street }}</p>
          <p><strong>Kod-Pocztowy:</strong>{{ user.profile.address.postalCode }}</p>
          <p><strong>Numer Domu:</strong>{{ user.profile.address.houseNumber }}</p>
        </div>
      </div>
      <div id="user-panel" v-if="isAuthorizedUser">
        <button v-if="!user.profile" @click="createProfile">
          Stwórz profil
        </button>
        <button v-if="user.profile" @click="editProfile">Edytuj profil</button>
        <button v-if="user.profile" @click="editAddress">Edytuj Addres</button>
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
      user: 'user/GET_STATE_USER',
      userName: 'auth/GET_USERNAME',
    }),
    isAuthorizedUser() {
      return this.userName === this.id;
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
  border: 1px solid black;
}
</style>
