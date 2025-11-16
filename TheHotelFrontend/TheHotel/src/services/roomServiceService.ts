import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { getMenuItemByIdEndpoint, RoomServiceEndpoint } from "../endpoints/endpoints";
import { httpService } from "../utils/httpService";
import { Product } from "../Interfaces/products";

export async function getAllProducts() {
    
   return await httpService.get(RoomServiceEndpoint)
      .then((res) => {return res.data;}
      )
      .catch((err) => console.error('Failed to fetch products:', err))
      .finally(() => {});

//    return response;
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