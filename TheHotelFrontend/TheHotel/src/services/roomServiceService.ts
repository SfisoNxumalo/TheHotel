import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { getMenuItemByIdEndpoint, getOrderDetailsEndpoint, getOrdersEndpoint, placeOrderEndpoint, roomServiceMenuEndpoint, updateOrderStatusEndpoint } from "../endpoints/endpoints";
import { httpService } from "../utils/httpService";
import { Product } from "../Interfaces/products";
import { Checkout } from "../Interfaces/CartItem";
import { OrderDetails } from "../Interfaces/OrderDetails";

export async function getAllProducts() {
    
   return await httpService.get(roomServiceMenuEndpoint)
      .then((res) => {return res.data;}
      )
      .catch((err) => console.error('Failed to fetch products:', err))
      .finally(() => {});
}

export const useFetchProducts = (): UseQueryResult<Product[]> => {
   return useQuery<Product[]>({
      queryKey: ["products"],
      queryFn: async (): Promise<Product[]> => getAllProducts(),
      staleTime: 15 * 1000,
      
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

export async function placeOrder(CheckoutDetails:Checkout){
   try{
      const result = await httpService.post(placeOrderEndpoint, CheckoutDetails);
      return result;
   }
   catch(error){
      console.error('Failed to fetch product:', error)
      throw error; // rethrow if you want the caller to handle it
   }
}

export async function getOrderById(orderId:string) {
    
   return await httpService.get(getOrderDetailsEndpoint(orderId))
      .then((res) => {return res.data;}
      )
      .catch((err) => console.error('Failed to fetch products:', err))
      .finally(() => {});
}

export const useFetchOrderDetails = (orderId:string): UseQueryResult<OrderDetails> => {
   return useQuery<OrderDetails>({
      queryKey: ["order", orderId],
      queryFn: async (): Promise<OrderDetails> => getOrderById(orderId),
      staleTime: 15 * 1000,
      enabled: !!orderId
   })
}

export async function getAllOrdersByUserId(userId:string) {
    
   return await httpService.get(getOrdersEndpoint(userId))
      .then((res) => {return res.data;}
      )
      .catch((err) => console.error('Failed to fetch products:', err))
      .finally(() => {});
}

export const useFetchAllOrders = (userId:string): UseQueryResult<OrderDetails[]> => {
   return useQuery<OrderDetails[]>({
      queryKey: ["orders"],
      queryFn: async (): Promise<OrderDetails[]> => getAllOrdersByUserId(userId),
      staleTime: 15 * 1000
   })
}

export async function updateOrderStatus(orderId:string, status:string) {
    
    try{

      console.log(updateOrderStatusEndpoint(orderId, status));
      
      const result = await httpService.patch(updateOrderStatusEndpoint(orderId, status));
      return result;
   }
   catch(error){
      console.error('Failed to update order:', error)
      throw error; // rethrow if you want the caller to handle it
   }
}