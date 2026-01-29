# The Hotel
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) ![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB) ![TypeScript](https://img.shields.io/badge/typescript-%23007ACC.svg?style=for-the-badge&logo=typescript&logoColor=white) ![Vite](https://img.shields.io/badge/vite-%23646CFF.svg?style=for-the-badge&logo=vite&logoColor=white) ![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens) ![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)  ![React Query](https://img.shields.io/badge/-React%20Query-FF4154?style=for-the-badge&logo=react%20query&logoColor=white) ![MUI](https://img.shields.io/badge/MUI-%230081CB.svg?style=for-the-badge&logo=mui&logoColor=white) ![NPM](https://img.shields.io/badge/NPM-%23CB3837.svg?style=for-the-badge&logo=npm&logoColor=white)

**The Hotel** is a full-stack hotel management system built as my Portfolio of Evidence (POE) during my internship at 1Nebula.  
The project showcases my understanding and ability to architecture and build a complete real-world application that supports both hotel visitors and hotel staff, with a focus on digitising room service.

The idea behind the project is simple:  
Room service is still commonly handled via telephone calls and hand written notes, which is often a manual, slow, and error-prone process. The Hotel modernises this by introducing a digital, e-commerce-style room service experience with real-time updates and messaging.

[Demo video on Youtube: https://youtu.be/oFofIzm1wIs](https://youtu.be/oFofIzm1wIs)

- [Backend README.md](/TheHotelAPI/README.md)
- [Frontend README.md](/TheHotelFrontend/TheHotel/README.md)

---

## Project Purpose

This project was built to demonstrate:

- Full-stack application development
- Secure authentication and authorization
- Real-time communication using SignalR
- Clean and maintainable architecture
- Practical AI integration using Google Gemini

I’ve included a [Design Choices](/TheHotelAPI/README.md#design-choices) section to explain some of the decisions I made while building this project. If you come across something that seems unusual or unclear (hopefully not 😄), please refer to that section first. If your question isn’t answered there, feel free to reach out, I’d love to hear your thoughts and discuss it further

---
## High-level Architectural Diagram
![alt text](./DocumentationImages/high_level_architectural_diagram.png)  


### Tech Stack

#### Frontend
- **React**
- TypeScript  
- Vite  
- Material UI  
- Axios  
- TanStack Query  
- SignalR  
- Zustand  
- Recharts  

Architecture: Bulletproof Architecture

#### Backend
- **ASP.NET Core 8**
- **C#**  
- **Entity Framework Core**
- JWT Authentication  
- SignalR
- Gemini AI

Architecture: Onion Architecture


#### Backend Testing
- NUnit  
- FluentAssertions  
- Moq  
- AutoFixture  


#### Database
- SQL Server  


#### Cloud Resources
- Microsoft Azure  

---

## System Users

The application supports two main user roles:

##### Hotel Visitor (Guest)
Guests can manage their stay and order room service digitally.

##### Hotel Staff
Staff can manage incoming orders, communicate with guests, and monitor hotel activity.

---

## Key Features

#### Guest Features
- Secure login and registration
- View booking details
- Browse the hotel menu
- View meal details
- Add meals to a cart
- Add notes or special instructions to meals  
  - These notes are validated using Google Gemini AI to prevent profanity or inappropriate content
- Checkout and place room service orders
- View order history and order details
- Receive real-time order status updates via SignalR  
  - When staff updates an order, a toast notification is shown to the guest
- Real-time chat with hotel staff using SignalR
- Explore nearby activities and places around the hotel


#### Staff Features
- Secure staff login
- View all incoming orders
- View detailed order information
- Update order statuses (e.g. preparing, on the way, completed)
- Send and receive messages from guests in real time
- View basic analytics and insights

--- 

## Screenshots

### Authentication
***Login Page***
![alt text](./DocumentationImages/LoginPage.png)
***Register Page***
![alt text](./DocumentationImages/registerPage.png)

### Guest Views
***User Dashboard***
![alt text](./DocumentationImages/userDashboard.png)

***Menu List Page***
![alt text](./DocumentationImages/userMenuListPage.png)

***Meal Details Page***  
![alt text](./DocumentationImages/userMenuItemPage.png)

***Cart Page***
![alt text](./DocumentationImages/userCartPage.png)  

***Messages Page***
![alt text](./DocumentationImages/userMessagePage.png)  

***Explore Page***
![alt text](./DocumentationImages/userExplorePage.png)  

### Staff Views
***Staff Dashboard***
![alt text](./DocumentationImages/adminDashboardPage.png)  

***Order Details Page***
![alt text](./DocumentationImages/adminOrderPage.png) 

***Messages Page***
![alt text](./DocumentationImages/adminMessagePage.png) 

***Analytics Page***
![alt text](./DocumentationImages/adminAnalyticsPage.png)  
