import { hubConnection } from "./hubConnection";

interface hubResponse{
  orderId:string,
  status:string
}

export const registerOrderHandlers = (
  onStatusUpdated: (order: hubResponse) => void
) => {
  hubConnection.on("OrderStatusUpdated", onStatusUpdated);
  console.log("----");
  
};
