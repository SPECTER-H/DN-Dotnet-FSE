# Week 3 — ASP.NET Core Web API

This folder contains the completed Week 3 hands-on exercises for the Cognizant Digital Nurture **.NET Angular FSE** Deep Skilling program.

All six mandatory Web API hands-on documents from the official repository have been implemented, tested and documented.

## Completed Hands-ons

| Hands-on | Topics Covered | Documentation |
|---|---|---|
| 1 | REST API, controllers and HTTP action methods | [Hands-on 1](RetailInventoryAPI/README_HandsOn1.md) |
| 2 | Swagger, Postman and attribute routing | [Hands-on 2](RetailInventoryAPI/README_HandsOn2.md) |
| 3 | Employee models, custom authorization and exception filters | [Hands-on 3](RetailInventoryAPI/README_HandsOn3.md) |
| 4 | Employee CRUD operations and input validation | [Hands-on 4](RetailInventoryAPI/README_HandsOn4.md) |
| 5 | CORS, JWT authentication and role-based authorization | [Hands-on 5](RetailInventoryAPI/README_HandsOn5.md) |
| 6 | Kafka producer, consumer and chat messaging | [Hands-on 6](KafkaChat/README_HandsOn6.md) |

## Project Structure

```text
Week_3/
├── RetailInventoryAPI/
│   ├── Controllers/
│   ├── Filters/
│   ├── Models/
│   ├── Program.cs
│   ├── appsettings.json
│   └── README_HandsOn1.md ... README_HandsOn5.md
│
├── KafkaChat/
│   ├── KafkaChat.Producer/
│   ├── KafkaChat.Consumer/
│   ├── KafkaChat.sln
│   └── README_HandsOn6.md
│
└── README.md
```

## ASP.NET Core Web API

The `RetailInventoryAPI` project demonstrates:

- RESTful controller development
- GET, POST, PUT and DELETE action methods
- Attribute routing and named routes
- Swagger/OpenAPI documentation
- Employee, Department and Skill models
- Request-body model binding
- HTTP status-code handling
- Custom authorization filters
- Custom exception filters
- Exception logging
- Employee CRUD operations
- Request validation
- CORS configuration
- JWT token generation
- JWT Bearer authentication
- Role-based authorization
- Token-expiration handling

### Build

```bash
dotnet build RetailInventoryAPI/RetailInventoryAPI.csproj
```

### Run

```bash
dotnet run --project RetailInventoryAPI/RetailInventoryAPI.csproj
```

The application displays its local HTTP address after starting. The endpoints can be tested through Swagger, Postman or `curl`.

## Kafka Chat Application

The `KafkaChat` solution contains two .NET console applications:

- `KafkaChat.Producer` — publishes messages to the Kafka topic.
- `KafkaChat.Consumer` — receives messages using an independent consumer group.

The application uses the `chat-message` topic and supports multiple consumer instances.

### macOS Adaptation

The official hands-on includes a Windows desktop chat client. Because Windows Forms is Windows-specific, this implementation uses cross-platform .NET console clients while preserving the required Kafka producer, consumer and multi-client messaging behaviour.

Kafka was run temporarily in KRaft mode and removed after testing to avoid unnecessary internal-disk usage.

### Build

```bash
dotnet build KafkaChat/KafkaChat.sln
```

## Verification

The following functionality was successfully tested:

- Web API and Kafka project builds
- GET, POST, PUT and DELETE endpoints
- Valid and invalid employee requests
- Swagger API documentation
- Custom authorization-filter responses
- Exception handling and file logging
- CORS configuration
- JWT generation and validation
- Missing, invalid and expired token handling
- POC and Admin role authorization
- Kafka message production
- Message delivery to multiple independent consumers

## Technologies Used

- C#
- .NET
- ASP.NET Core Web API
- Swagger/OpenAPI
- JWT Bearer Authentication
- CORS
- Apache Kafka
- Confluent.Kafka
- KRaft

## Status

**Week 3 completed:** All six mandatory hands-on documents have been implemented, tested and documented successfully.