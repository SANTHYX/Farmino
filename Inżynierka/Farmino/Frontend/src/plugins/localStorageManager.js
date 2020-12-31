const localStorageManager = {
  storeTokens(token, refresh) {
    if (token && refresh) {
      localStorage.setItem('token', token);
      localStorage.setItem('refresh', refresh);
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
};

export default localStorageManager;
