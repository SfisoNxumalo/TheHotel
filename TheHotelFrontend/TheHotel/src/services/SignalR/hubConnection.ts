import * as signalR from "@microsoft/signalr";

export const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("https://thehotelapi.azurewebsites.net/hubs/hotel")  //Hardcoded for demo purposes only, you should never hardcode this. Preferably store this in the .env
  .withAutomaticReconnect()
  .build();