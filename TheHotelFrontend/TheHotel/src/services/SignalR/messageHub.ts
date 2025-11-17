import { hubConnection } from "./hubConnection";

export const registerMessageHandlers = (
  onMessageReceived: (from: string, message: string) => void
) => {
  hubConnection.on("ReceiveMessage", onMessageReceived);
};

export const sendMessage = async (to: string, content: string) => {
  await hubConnection.invoke("SendMessage", to, content);
};
