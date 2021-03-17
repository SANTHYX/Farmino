import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:8080',
});

const geoApi = axios.create({
  baseURL: 'https://us1.locationiq.com/v1/search.php?key=pk.4ec8f781c1d03c710600d8c4f0482c62',
});

const directionsApi = axios.create({
  baseURL: 'https://api.mapbox.com/directions/v5/mapbox/driving',
});

export {
  api, geoApi, directionsApi,
};
