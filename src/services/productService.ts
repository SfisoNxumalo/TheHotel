import { productsEndpoint } from "../endpoints/endpoints";
import { httpService } from "../utils/httpService";
import jsonData from '../../public/mock/products.json'
import axios from "axios";
export async function getAllProducts(){
    
   return await httpService.get('../mock/products.json')
      .then((res) => {return res.data;}
      )
      .catch((err) => console.error('Failed to fetch products:', err))
      .finally(() => {});

//    return response;
}