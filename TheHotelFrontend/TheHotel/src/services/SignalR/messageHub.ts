import { Message } from "../../Interfaces/message";
import { hubConnection } from "./hubConnection";

export const registerMessageHandlers = (
  onStatusUpdated: (messsage: Message) => void
) => {
  hubConnection.on("ReceiveMessage", onStatusUpdated);
};
