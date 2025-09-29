import axios from "axios";
import { baseURL } from "../endpoints/endpoints";

export const httpService = axios.create({baseURL:baseURL, headers:{}, timeout:10000});