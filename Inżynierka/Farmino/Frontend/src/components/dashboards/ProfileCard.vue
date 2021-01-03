<template>
  <div id="profile-card">
    <div id="profile-card-wraper">
      <div id="showcase">
        <h1>{{ user.userName }}</h1>
        <h5>{{ user.email }}</h5>
        <h1>Address</h1>
      </div>
      <div id="user-panel" v-if="isAuthorizedUser">
        <button v-if="user.profile === null" @click="createProfile">
          Stwórz profil
        </button>
        <button v-if="user.profile !== null" @click="editProfile">Edytuj profil</button>
        <button v-if="user.profile.address !== null" @click="editAddress">Edytuj adres</button>
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
      this.$router.push({ name: 'edit-profile' });
    },
  },

  async created() {
    await this.getUserAsync(this.id);
  },
};
</script>

<style lang="scss" scoped></style>
