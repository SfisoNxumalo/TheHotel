import { productsEndpoint } from "../endpoints/endpoints";
import { httpService } from "../utils/httpService";
export async function getAllProducts(){
    
   return await httpService.get(productsEndpoint)
      .then((res) => {return res.data;}
      )
      .catch((err) => console.error('Failed to fetch products:', err))
      .finally(() => {});

//    return response;
}