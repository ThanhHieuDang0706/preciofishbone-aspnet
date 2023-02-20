import axios from 'axios';

const API_BASE_URL = 'https://localhost';
const PORT = 7214;
const API_URL = `${API_BASE_URL}:${PORT}`;

const axiosInstance = axios.create({
  baseURL: API_URL,
});

export default axiosInstance;
