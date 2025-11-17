import * as signalR from "@microsoft/signalr";

export const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:7114/hubs/notifications")
  .withAutomaticReconnect()
  .build();