import axios from 'axios';

const devFarminoAPI = axios.create({
  baseURL: 'https://localhost:5006',
});

export default devFarminoAPI;
