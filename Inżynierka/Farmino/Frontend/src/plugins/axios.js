import axios from 'axios';

const devFarminoAPI = axios.create({
  baseURL: 'http://localhost:8080',
});

export default devFarminoAPI;
