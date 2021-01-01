const localStorageManager = {
  storeTokens(token, refresh, expiresAt, userName) {
    if (token && refresh) {
      localStorage.setItem('token', token);
      localStorage.setItem('expiresAt', expiresAt);
      localStorage.setItem('refresh', refresh);
      localStorage.setItem('userName', userName);
    }
  },
  clearTokens() {
    localStorage.removeItem('token');
    localStorage.removeItem('refresh');
  },

  getToken() {
    return localStorage.getItem('token');
  },

  getRefresh() {
    return localStorage.getItem('refresh');
  },

  getUserName() {
    return localStorage.getItem('userName');
  },

  getExpirationDate() {
    return localStorage.getItem('expireAt');
  },
};

export default localStorageManager;
