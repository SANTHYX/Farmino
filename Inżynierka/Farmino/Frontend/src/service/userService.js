import api from '@/plugins/axios';

const userService = {
  async register({ login, password, email }) {
    try {
      await api.post('/auth/register', { login, password, email });
    } catch (err) {
      console.log(err.message);
    }
  },
  async login({ login, password }) {
    try {
      const loginResponse = await api.post('/auth/login', { login, password });
      const userResponse = await userService.getUser(login);
      return { token: loginResponse.data.token, userObj: userResponse };
    } catch (err) {
      return err.message;
    }
  },
  async createProfile({
    login, firstName, lastName, phoneNumber,
  }) {
    try {
      const response = await api.post('/profiles', {
        login,
        firstName,
        lastName,
        phoneNumber,
      });
      return response;
    } catch (err) {
      return err.message;
    }
  },
  async editProfile({
    login, firstName, lastName, phoneNumber,
  }) {
    try {
      const response = await api.put('/profiles', {
        login,
        firstName,
        lastName,
        phoneNumber,
      });
      return response.data;
    } catch (err) {
      return err.message;
    }
  },
  async addAddress({
    login, city, street, postalCode, houseNumber,
  }) {
    try {
      await api.post('/address', {
        login,
        city,
        street,
        postalCode,
        houseNumber,
      });
    } catch (err) {
      console.log(err.message);
    }
  },
  async editAddress({
    login, city, street, postalCode, houseNumber,
  }) {
    try {
      await api.put('/address', {
        login,
        city,
        street,
        postalCode,
        houseNumber,
      });
    } catch (err) {
      console.log(err.message);
    }
  },
  async getUser(login) {
    try {
      const response = await api.get(`users/single?login=${login}`);
      return response.data;
    } catch (err) {
      return err.message;
    }
  },
};

export default userService;
