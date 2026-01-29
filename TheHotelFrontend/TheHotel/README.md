
# The Hotel – Frontend Application

The Hotel Frontend is a React with TypeScript web application built as part of my POE during my internship at 1Nebula. It provides a modern, user-friendly interface for both hotel guests and hotel staff, enabling digital room service ordering, real-time updates, and live messaging.

## Architecture Overview

The frontend follows [Bulletproof Architecture](https://github.com/alan2207/bulletproof-react/blob/master/docs/project-structure.md), which promotes feature-based folder organisation. The architecture’s emphasis on separation of concerns makes it possible to configure ESLint rules that forbid cross-feature imports, helping to enforce clear boundaries between features.

- **Tech stack**
| Category        | Technology / Library | Purpose |
|-----------------|----------------------|---------|
| Framework       | React                | Building the user interface |
| Language        | TypeScript           | Type-safe JavaScript development |
| Build Tool      | Vite                 | Fast development server and bundler |
| UI Library      | Material UI          | Prebuilt, accessible UI components |
| Data Fetching   | Axios                | HTTP client for API communication |
| Data Caching    | TanStack Query       | Server-state management and caching |
| Realtime        | SignalR              | Real-time messaging and live updates |
| State Management| Zustand              | Client-side global state management |
| Visualization  | Recharts             | Charts and data visualisation |


#### Folder Structure
Below is a high-level overview of the project’s folder structure and responsibilities:
```
src
├── app                             # Application entry structure (routing & pages)
│   └── pages                       # Route-level pages
│       ├── ActivitiesPage          # Explore activities around the hotel
│       ├── DashboardPage           # Main dashboard (role-based)
│       ├── LoginPage               # User login page
│       ├── RoomServicePage         # Menu browsing & room service ordering
│       ...
│
├── assets                          # Static assets (images, icons, fonts)
├── components                      # Reusable UI components (buttons, modals, cards)
├── config                          # Global configuration (API base URLs, constants)
├── contexts                        # React context providers (auth, theme, etc.)
├── endpoints                       # Centralised API endpoint definitions
├── features                        # Feature-based modules (Bulletproof Architecture)
│                                   # Each feature owns its logic, components, and hooks
├── globalStyles                    # Global styling and theme overrides
├── hooks                           # Reusable custom React hooks
├── interfaces                      # Shared TypeScript interfaces
├── lib                             # Shared libraries and setup code (Axios, SignalR)
├── services                        # API service layers
│   ├── analyseService              # Analytics-related API calls
│   ├── SignalR                     # SignalR connection and hub logic
│   ├── messageService.ts           # Messaging API calls
│   ...
│
├── stores                          # Zustand state stores
│   ├── authStore.ts                # Authentication and user session state
│   ├── cartStore.ts                # Room service cart state
│   └── messageStore.ts             # Chat and messaging state
│
├── testing                         # Frontend tests and test utilities
├── types                           # Shared and global TypeScript types
└── utils                           # Helper and utility functions

```

## Installation & Local Setup
### Prerequisites

Make sure you have the following installed:

- **Node.js** (LTS version recommended)
- **npm** (comes with Node.js)
- A running instance of **The Hotel Backend API**
- A modern web browser (Chrome, Edge, or Firefox)

---

### Clone the Repository

Open your terminal and run:

```bash
git clone https://github.com/SfisoNxumalo/TheHotel
cd TheHotel
```

#### Install Dependencies
```
npm install
```


#### Update Connection strings 
The frontend communicates with the backend via REST APIs and SignalR for real-time updates. Update the following values to match your local backend setup:
- Update the hubConnection string in `hubConnection.ts` to point to your SignalR hub.
- Update the baseURL in `endpoint.ts` to your local backend URL (e.g. https://localhost:7114).

#### Run the Frontend
```
npm run dev
```

By default, the frontend will run on:

http://localhost:5173