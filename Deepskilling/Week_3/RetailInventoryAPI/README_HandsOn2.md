# Hands-on 2 - Swagger, Postman and Routing

## Objective

Configure Swagger for API documentation, test the API using Postman and demonstrate custom routes and named HTTP actions.

## Implemented

- Installed `Swashbuckle.AspNetCore`
- Added Swagger document information
- Enabled Swagger and Swagger UI
- Retained the Values controller action listing
- Created an Employee GET endpoint
- Changed the Employee controller route to `/api/Emp`
- Added named GET actions
- Added documented response types

## Endpoints

| Verb | Route | Action name |
|---|---|---|
| GET | `/api/values` | Values GET action |
| GET | `/api/values/{id}` | Values GET-by-ID action |
| GET | `/api/Emp` | `GetEmployees` |
| GET | `/api/Emp/{id}` | `GetEmployeeById` |

## Build and Run

```bash
dotnet build
dotnet run
```

## Swagger

Open:

```text
http://localhost:PORT/swagger
```

Swagger displays the Values and Employee controller endpoints and allows them to be tested using **Try it out**.

## Postman

Send a GET request to:

```text
http://localhost:PORT/api/Emp
```

The response body contains the employee list and returns HTTP status `200 OK`.