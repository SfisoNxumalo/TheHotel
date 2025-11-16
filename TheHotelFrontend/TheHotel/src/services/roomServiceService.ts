import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { getMenuItemByIdEndpoint, PlaceOrderEndpoint, RoomServiceMenuEndpoint } from "../endpoints/endpoints";
import { httpService } from "../utils/httpService";
import { Product } from "../Interfaces/products";
import { Checkout } from "../Interfaces/CartItem";

export async function getAllProducts() {
    
   return await httpService.get(RoomServiceMenuEndpoint)
      .then((res) => {return res.data;}
      )
      .catch((err) => console.error('Failed to fetch products:', err))
      .finally(() => {});
}

export const useFetchProducts = (): UseQueryResult<Product[]> => {
   return useQuery<Product[]>({
      queryKey: ["products"],
      queryFn: async (): Promise<Product[]> => getAllProducts(),
      staleTime: 120 * 60 * 1000

   })
}

export async function getMenuItemById(id:string) {
   try{
      const result = await httpService.get(getMenuItemByIdEndpoint(id));
      return result;
   }
   catch(error){
      console.error('Failed to fetch product:', error)
      throw error; // rethrow if you want the caller to handle it
   }
}

export async function PlaceOrder(CheckoutDetails:Checkout){
   try{
      const result = await httpService.post(PlaceOrderEndpoint, CheckoutDetails);
      return result;
   }
   catch(error){
      console.error('Failed to fetch product:', error)
      throw error; // rethrow if you want the caller to handle it
   }
}