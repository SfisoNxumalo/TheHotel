# The Hotel – Backend API


The Hotel API is an ASP.NET Core Web API built as part of my POE during my internship at 1Nebula.

## Architecture Overview


The API follows Onion Architecture, ensuring clear separation of concerns and maintainability.


##### Layers:
- **Domain**
Core entities, DTOs, and domain exceptions
- **Application**
Business logic, services, interfaces, and validations
- **Infrastructure**
Database access, repositories, external integrations (JWT, Gemini AI)
- **API**
Controllers, SignalR hubs, dependency injection, configuration


This approach keeps business logic independent of frameworks and infrastructure.

### Folder Structure

```
├── TheHotel.Domain                 # Core business entities and domain rules
│   ├── DomainExceptions            # Domain-specific exceptions
│   ├── DTOs                        # Data Transfer Objects shared across layers
│   ├── Entities                    # Core domain models (e.g. User, Order, Booking)
│   └── Interfaces                  # Domain-level contracts and abstractions
│
├── TheHotel.Application            # Application business logic
│   ├── Interfaces                  # Service interfaces
│   ├── Models                      # Application-specific models
│   ├── Services                    # Core business services 
│   ├── ServiceExceptions           # Application-level exceptions
│   └── ServiceExtensions           # Dependency Injection registration for application services methods
│
├── TheHotel.Infrastructure         # External concerns and implementations
│   ├── Constants                   # Application-wide constants
│   ├── DatabaseContext             # Entity Framework Core DbContext
│   ├── InfrastructureExtensions   # Dependency Injection registration for infrastructure services
│   ├── Integration                 # External service integrations
│   │   ├── Auth                    # JWT and authentication helpers
│   │   └── GeminiService           # Google Gemini AI integration for content moderation
│   ├── Migrations                  # EF Core database migrations
│   ├── Repositories                # Data access and repository implementations
│   └── Seeding                     # Database seed data
│
├── TheHotelAPI                     # ASP.NET Core Web API layer
│   ├── Controllers                 # API endpoints and request handling
│   ├── SignalR                     # SignalR hubs for real-time communication
│   ├── Properties                  
│   ├── Connected Services          
│   ├── appsettings.json            
│   └── Program.cs                  
│
├── Tests                           #  tests
│   ├── TheHotel.Application.UnitTests
│   │   ├── MessageServiceTests     # Unit tests for message-related logic
│   │   │   ├── BaseSetup
│   │   │   │   └── TestBase_MessageService.cs  # Shared test setup
│   │   │   └── MessageServiceTests.cs           # Message service test cases
│   │
│   ├── TheHotel.Domain.UnitTests   # Domain logic unit tests
│   │
│   └── TheHotel.Infrastructure.UnitTests  # Infrastructure-related tests
│
└── TheHotelAPI.sln                 
```
##### API Endpoints Used by the Frontend
These are  the endpoints that are actively consumed by the frontend. Endpoints not listed here are  reserved for future use.
##### Authentication


| Method | Endpoint | Description |
|------|---------|-------------|
| POST | `/api/auth/login` | Authenticates a user and returns JWT access and refresh tokens |
| POST | `/api/auth/register` | Registers a new hotel guest account |

##### Room Service Menu

| Method | Endpoint | Description |
|------|---------|-------------|
| GET | `/api/RoomService/menu` | Retrieves the list of meals available for room service |
| GET | `/api/RoomService/menu/{menuItemId}` | Retrieves detailed information for a specific meal |

##### Room Service Orders

| Method | Endpoint | Description |
|------|---------|-------------|
| POST | `/api/RoomServiceOrder` | Places a new room service order |
| GET | `/api/RoomServiceOrder/user/{userId}` | Retrieves all orders for a specific guest |
| GET | `/api/RoomServiceOrder/{orderId}` | Retrieves detailed information for a specific order |
| PATCH | `/api/RoomServiceOrder/{orderId}/{status}` | Updates the status of an order (staff action) |
| GET | `/api/RoomServiceOrder/all` | Retrieves all orders for analytics and staff dashboards |

##### Messaging
| Method | Endpoint | Description |
|------|---------|-------------|
| POST | `/api/Message` | Sends a message between guest and staff |
| GET | `/api/Message/{userId}` | Retrieves the message history for a specific user |

##### Users
| Method | Endpoint | Description |
|------|---------|-------------|
| GET | `/api/User/user` | Retrieves the currently authenticated guest user |
| GET | `/api/User/staff` | Retrieves staff users for messaging and assignment |

---
### External package usage
##### Real-Time Communication (SignalR)

SignalR is used in the application to improve user experience:

- Instant order status updates for guests
- Real-time chat between guests and staff

##### AI Content Moderation (Gemini AI)

Google Gemini AI is integrated as a content moderation layer.

When a guest adds a note or instruction to a room service item:
- The note is sent to Gemini AI from the backend
- The AI checks for profanity or inappropriate language
---
## Installation


**Prerequisites**

Make sure you have the following installed:

- .NET SDK 8
- SQL Server (LocalDB)
- Visual Studio 2022 (recommended)
- Bruno or any API testing tool
- A Google Gemini API key


##### Clone the Repository

```bash
# Open your bash/CMD terminal and enter the following commands
git clone https://github.com/SfisoNxumalo/TheHotel
cd TheHotelAPI
```

##### Update the configurations

```json
"ConnectionStrings": {
  "DefaultConnection": "YOUR_SQL_CONNECTION_STRING"
},
"JwtConfig": {
  "Issuer": "https://localhost:7114",
  "Audience": "http://localhost:5173",
  "AccessTokenSecret": "YOUR_ACCESS_TOKEN_SECRET",
  "RefreshTokenSecret": "YOUR_REFRESH_TOKEN_SECRET",
  "TokenValidityMins": 60,
  "RefreshTokenDays": 7
},
"Gemini": {
  "ApiKey": "YOUR_GEMINI_API_KEY"
}
```

##### Apply Database Migrations

```bash
dotnet ef database update
```

If you prefer using the Package Manager Console like me ;)
```bash
update-database
```

##### Run the API

Start the API using Visual Studio or the command line:

```bash
dotnet run
```

By default, the API will run on:
https://localhost:7114

---

### Design Choices

This section explains some of the key design decisions made while building the backend API and the reasoning behind them.

#### Onion Architecture.

I chose Onion Architecture to keep the system clean, maintainable, and testable. Additionally, this is the architecture used at 1Nebula.

- Business logic lives at the center of the application
- Infrastructure concerns are kept separate
- This makes the code easier to modify and easier to test over time


#### Dependency Injection via Extension Methods

Instead of registering all dependencies in `Program.cs`, I moved dependency registration into:

- `ServiceExtensions` (Application layer)
- `InfrastructureExtensions` (Infrastructure layer)

Reason:
- Keeps `Program.cs` minimal and readable
- Groups dependency registration by responsibility
- Makes the solution easier to scale as the project grows

`Program.cs` acts only as the root for calling these extensions.

#### Backend AI Content Moderation (Gemini AI)

I integrated Google Gemini AI in the backend to validate meal notes during checkout.

Why in the backend:
- The backend is the source of truth and client-side validation alone is not secure. This prevents inappropriate content from ever being stored or processed

#### Soft Deletes Instead of Hard Deletes

I implemented soft deletes rather than permanently removing records.

Reasons:
- Preserves historical data
- Useful for auditing and analytics