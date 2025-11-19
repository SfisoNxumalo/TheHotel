import { ordersAnalyseEndpoint, roomServiceMenuEndpoint } from "../../endpoints/endpoints";
import { httpService } from "../../utils/httpService";

export async function getProductsData() {
   try{
      const result = await httpService.get(roomServiceMenuEndpoint);
      return result;
   }
   catch(error){
      console.error('failed to get products', error)
      throw error; // rethrow if you want the caller to handle it
   }
}

export async function getOrdersData() {
   try{
      const result = await httpService.get(ordersAnalyseEndpoint);
      return result;
   }
   catch(error){
      console.error('failed to get orders', error)
      throw error; // rethrow if you want the caller to handle it
   }
}