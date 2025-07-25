import axios from "axios";

export const httpService = axios.create({baseURL:"", headers:{}, timeout:10000});