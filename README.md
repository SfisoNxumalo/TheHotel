# The Hotel

**The Hotel** is a full-stack hotel management system built as my Portfolio of Evidence (POE) during my internship at 1Nebula.  
The project showcases my understanding and ability to design and build a complete, real-world application that supports both hotel visitors and hotel staff, with a strong focus on digitising room service.

The idea behind the project is simple:  
Room service is still commonly handled via telephone calls, which is often a manual, slow, and error-prone process.  
The Hotel modernises this by introducing a digital, e-commerce-style room service experience with real-time updates and messaging.

[Demo video on Youtube: https://youtu.be/d-QtRmSQfEQ](https://youtu.be/d-QtRmSQfEQ)

---

## Project Purpose

This project was built to demonstrate:

- Full-stack application development
- Secure authentication and authorization
- Real-time communication using SignalR
- Clean and maintainable architecture
- Practical AI integration using Google Gemini

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

## Tech Stack

#### Frontend
- React  
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
- ASP.NET Core 8  
- C#  
- Entity Framework Core  
- JWT Authentication  
- SignalR  

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

### External package usage
##### Real-Time Communication (SignalR)

SignalR is used in the application to improve user experience:

- Instant order status updates for guests
- Real-time chat between guests and staff
- No page refresh needed to see changes

---

##### AI Content Moderation (Gemini AI)

Google Gemini AI is integrated as a content moderation layer.

When a guest adds a note or instruction to a room service item:
- The note is sent to Gemini AI from the backend
- The AI checks for profanity or inappropriate language
- Messages that do not meet the rules are rejected

This helps maintain respectful communication and protects hotel staff.

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
![alt text](./DocumentationImages/userMenuItemPage.png)

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


---
Separate README files will be provided for:
- Backend API
- Frontend Application