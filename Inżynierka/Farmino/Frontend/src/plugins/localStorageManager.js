const localStorageManager = {
  storeTokens(token, refresh, expiresAt, userName) {
    if (token && refresh && expiresAt && userName) {
      localStorage.setItem('token', token);
      localStorage.setItem('refresh', refresh);
      localStorage.setItem('expiresAt', expiresAt);
      localStorage.setItem('userName', userName);
    }
  },
  clearTokens() {
    localStorage.removeItem('token');
    localStorage.removeItem('refresh');
  },

  Logout() {
    localStorage.clear();
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

  getExpiresAt() {
    return localStorage.getItem('expiresAt');
  },
};

export default localStorageManager;
