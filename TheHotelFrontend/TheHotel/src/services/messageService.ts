import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { getMessageEndpoint, messageEndpoint } from "../endpoints/endpoints";
import { Message } from "../Interfaces/message";
import { httpService } from "../utils/httpService";
import { SendMessage } from "../Interfaces/SendMessage";

export async function getAllMessages(userId:string){

   try {
    const res = await httpService.get(getMessageEndpoint(userId))
    return res;
  } catch (err) {
    console.error('Failed to fetch messages:', err);
    throw err; // rethrow if you want the caller to handle it
  }
}

export const useFetchMessages = (userId:string): UseQueryResult<Message[]> => {
   return useQuery<Message[]>({
      queryKey: ["messages", userId],
      queryFn: async (): Promise<Message[]> => (await getAllMessages(userId)).data,
      staleTime: 120 * 60 * 1000
   })
}

export async function sendMessage(message: SendMessage) {
  try {
    const res = await httpService.post<Message>(messageEndpoint, message);
    return res;
  } catch (err) {
    console.error('Failed to send message:', err);
    throw err; // rethrow if you want the caller to handle it
  }
}