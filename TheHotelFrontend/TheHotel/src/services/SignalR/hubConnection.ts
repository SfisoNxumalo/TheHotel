import * as signalR from "@microsoft/signalr";

export const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("https://thehotelapi.azurewebsites.net/hubs/hotel")
  .withAutomaticReconnect()
  .build();