import { AuthenticationResult } from '@azure/msal-browser';
import axios from 'axios';
import { getTokenRedirect } from '../auth/_authRedirect';
import { renderAlert } from '../components/_alert';

const API_BASE_URL = 'https://localhost';
const PORT = 7214;
const API_URL = `${API_BASE_URL}:${PORT}`;

const axiosInstance = axios.create({
  baseURL: API_URL,
  headers: {
    withCredentials: true,
    'Access-Control-Allow-Origin': '*',
    'Content-Type': 'application/json'
  }
});

const tokenAxios = axios.create({
  baseURL: 'https://login.microsoftonline.com/ccb176fe-8010-4cf0-a10c-0a3c789a1cef',
  headers: {
    'Access-Control-Allow-Origin': '*',
    'Content-Type': 'application/x-www-form-urlencoded'
  }
});

axiosInstance.interceptors.request.use(
  async config => {
    const res = (await getTokenRedirect()) as AuthenticationResult;

    const token = res.accessToken;

    if (token) {
      config.headers.set('Authorization', `Bearer ${token}`);
    }
    return config;
  },
  error => {
    renderAlert(error.message);
  }
);

axiosInstance.interceptors.response.use(
  response => response,
  error => {
    renderAlert(error.message);
  }
);

export default axiosInstance;
