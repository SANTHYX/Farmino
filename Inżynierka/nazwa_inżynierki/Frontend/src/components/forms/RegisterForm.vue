<template>
  <div id="register-form">
    <div id="form-wraper">
      <h1>Rejestracja</h1>
      <div class="form" id="account-form" v-if="form === 'account-form'">
        <h2>Konto</h2>
        <hr />
        <div class="inputs-wraper">
          <label for="login-field" class="form-label">Login</label>
          <input type="text" name="login" id="login-field" class="form-field" />
          <label for="password-field" class="form-label">Hasło</label>
          <input type="password" name="password" id="password-field" class="form-field" />
          <label for="email-field" class="form-label">Email</label>
          <input type="email" name="email" id="email-field" class="form-field" />
          <button type="submit" @click.prevent="form = 'personal-data-form'" class="move-btn">
            Przejdz do Personali
          </button>
        </div>
      </div>
      <div class="form" id="personal-data-form" v-else-if="form === 'personal-data-form'">
        <h2>Dane Personalne</h2>
        <hr />
        <div class="inputs-wraper"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'register-form',
  data() {
    return {
      form: 'account-form',
    };
  },
};
</script>

<style lang="scss" scoped>
#register-form {
  display: flex;
  justify-content: flex-end;
  align-items: center;
  font-family: 'Roboto Condensed', sans-serif;

  #form-wraper {
    height: 100vh;
    width: 35vw;
    display: flex;
    background: rgb(95, 240, 126);
    flex-direction: column;
    justify-content: center;
    align-items: center;
    min-width: 300px;

    #account-form {
      h2 {
        display: flex;
        align-self: center;
      }
      background: rgb(255, 255, 255);
      border-radius: 15px;
    }
  }
}

.form {
  display: flex;
  flex-direction: column;
  margin-top: 20px;
  padding: 4.5rem;
}

.inputs-wraper {
  display: flex;
  flex-direction: column;
}

.move-btn {
  align-self: center;
  margin-top: 30px;
  height: 40px;
  width: 140px;
  font-family: 'Roboto Condensed', sans-serif;
  font-weight: bold;
  font-size: 0.9rem;
  cursor: pointer;
  border-radius: 10px;
  background: rgba(164, 245, 42, 0.657);
  border: 2px solid rgba(117, 109, 109, 0.452);
}
</style>
