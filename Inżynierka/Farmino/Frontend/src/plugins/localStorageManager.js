const localStorageManager = {
  storeTokens(token, refresh, expiresAt, userName) {
    if (token && refresh && expiresAt && userName) {
      localStorage.setItem('token', token);
      localStorage.setItem('refresh', refresh);
      localStorage.setItem('expiresAt', expiresAt);
      localStorage.setItem('userName', userName);
    }
  },

  storeRefresh(token, refresh, expiresAt) {
    if (token && refresh && expiresAt) {
      localStorage.setItem('token', token);
      localStorage.setItem('refresh', refresh);
      localStorage.setItem('expiresAt', expiresAt);
    }
  },

  clearTokens() {
    localStorage.removeItem('token');
    localStorage.removeItem('refresh');
    localStorage.removeItem('expiresAt');
  },

  clearStorage() {
    localStorage.removeItem('token');
    localStorage.removeItem('refresh');
    localStorage.removeItem('expiresAt');
    localStorage.removeItem('userName');
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

  isAuthorized() {
    return (
      this.getRefresh() && this.getToken() && this.getUserName() && this.getExpiresAt() != null
    );
  },
};

export default localStorageManager;
