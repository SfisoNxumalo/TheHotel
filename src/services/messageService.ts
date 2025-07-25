import { MessageEndpoint } from "../endpoints/endpoints";
import { httpService } from "../utils/httpService";

export async function getAllMessages(){
    
   return await httpService.get(MessageEndpoint)
      .then((res) => {return res.data;}
      )
      .catch((err) => console.error('Failed to fetch messages:', err))
      .finally(() => {});

//    return response;
}