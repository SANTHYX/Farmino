<template>
  <div id="profile-card">
    <div id="profile-card-wraper">
      <div id="showcase">
        <h1>{{ user.userName }}</h1>
        <h5>{{ user.email }}</h5>
        <h1>Address</h1>
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
    isAccountUser() {
      return this.user.userName === this.userName;
    },
  },

  methods: {
    ...mapActions({
      getUserAsync: 'user/GET_USER',
    }),
  },

  async created() {
    await this.getUserAsync(this.id);
  },
};
</script>

<style lang="scss" scoped></style>
