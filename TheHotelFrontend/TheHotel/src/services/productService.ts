import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { productsEndpoint } from "../endpoints/endpoints";
import { httpService } from "../utils/httpService";
import { Product } from "../Interfaces/products";

export async function getAllProducts() {
    
   return await httpService.get(productsEndpoint)
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