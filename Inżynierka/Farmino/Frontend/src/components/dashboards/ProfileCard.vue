<template>
  <div id="profile-card">
    <div id="profile-card-wraper" userName="userName">
      <div id="showcase"></div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';

export default {
  name: 'profile-card',
  props: ['userName'],
  computed: {
    ...mapGetters({
      user: 'user/GET_USER',
    }),
  },
  methods: {
    ...mapActions({
      getUserAsync: 'user/GET_USER',
    }),
  },

  async created() {
    if (this.$store.state[('user', 'login')] !== this.userName) {
      await this.getUserAsync(this.userName);
    }
  },
};
</script>

<style lang="scss" scoped></style>
