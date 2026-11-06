
# ServiceDesk API

A RESTful ticket management API built with **C# and ASP.NET Core**.

The project demonstrates backend API development, dependency injection, request validation, and separation of concerns using a controller-service architecture.

## Tech Stack

- C#
- .NET 10
- ASP.NET Core Web API
- RESTful APIs
- Dependency Injection
- Data Annotations

## Features

- Retrieve all support tickets
- Retrieve a ticket by ID
- Create new support tickets
- Automatically generate ticket IDs
- Validate incoming requests
- Return appropriate HTTP status codes
- Manage ticket data through a dedicated service layer

## API Endpoints

| Method | Endpoint | Description | Response |
|--------|----------|-------------|----------|
| GET | `/api/health` | Check API health | 200 OK |
| GET | `/api/tickets` | Retrieve all tickets | 200 OK |
| GET | `/api/tickets/{id}` | Retrieve a ticket by ID | 200 OK / 404 Not Found |
| POST | `/api/tickets` | Create a new ticket | 201 Created / 400 Bad Request |

## Example Request

### Create a Ticket

**POST** `/api/tickets`

Request body:

```json
{
  "title": "Laptop won't start",
  "description": "Laptop does not power on."
}
```

Example response (`201 Created`):

```json
{
  "id": 4,
  "title": "Laptop won't start",
  "description": "Laptop does not power on.",
  "status": "Open",
  "createdAt": "2026-11-06T12:00:00Z"
}
```

## Project Structure

```text
ServiceDesk.Api/
├── Controllers/
│   ├── HealthController.cs
│   └── TicketsController.cs
├── Models/
│   ├── Ticket.cs
│   └── CreateTicketRequest.cs
├── Services/
│   └── TicketService.cs
└── Program.cs
```

## Getting Started

### Prerequisites

- .NET 10 SDK
- Visual Studio, VS Code, or another compatible IDE

### Installation

1. Clone the repository:

   ```bash
   git clone <repository-url>
   ```

2. Navigate to the API project:

   ```bash
   cd ServiceDesk/ServiceDesk.Api
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

5. Use the local URL displayed in the terminal to test the API endpoints.

## Architecture

The application follows a **controller-service architecture** to separate responsibilities.

- **Controllers:** Handle HTTP requests and return appropriate responses.
- **Services:** Manage ticket-related business logic and data operations.
- **Models:** Define ticket entities and request contracts.
- **Dependency Injection:** Provides a shared instance of `TicketService` using `AddSingleton()`.

### Request Flow

```text
HTTP Request
     |
     v
TicketsController
     |
     v
TicketService
     |
     v
In-Memory Ticket Collection
     |
     v
HTTP Response
```

## Request Validation

The API uses ASP.NET Core Data Annotations to validate incoming requests.

Current validation rules:

| Field | Rules |
|-------|-------|
| Title | Required, maximum 100 characters |
| Description | Required, maximum 500 characters |

Invalid requests automatically return `400 Bad Request` with validation error details.

## Data Storage

The application currently uses an **in-memory ticket collection** managed through a singleton service.

Newly created tickets remain available across HTTP requests while the application is running.

**Note:** Data is reset when the application restarts. Persistent database storage is planned for a future iteration.

## Planned Enhancements

- [ ] Update existing tickets
- [ ] Delete tickets
- [ ] Integrate a relational database
- [ ] Implement authentication and authorization
- [ ] Add unit and integration tests
- [ ] Improve error handling and logging

## Project Status

**Active Development**

ServiceDesk API is being developed incrementally, with a focus on building maintainable backend services using C# and ASP.NET Core.
