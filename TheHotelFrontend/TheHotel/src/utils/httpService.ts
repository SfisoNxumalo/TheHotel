import axios from "axios";
import { baseURL } from "../endpoints/endpoints";
import { useAuthStore } from "../stores/authStore";

export const httpService = axios.create({baseURL:baseURL, headers:{}, timeout:10000});
  
httpService.interceptors.request.use((config) => {
    const user = useAuthStore.getState().user;

  if (user?.token) {
    config.headers.Authorization = `Bearer ${user.token}`;
  }

  return config;
});