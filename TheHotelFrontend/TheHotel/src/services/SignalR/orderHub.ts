import { hubConnection } from "./hubConnection";

export const registerOrderHandlers = (
  onStatusUpdated: (orderId: string, status: string) => void
) => {
  hubConnection.on("OrderStatusUpdated", onStatusUpdated);
};
