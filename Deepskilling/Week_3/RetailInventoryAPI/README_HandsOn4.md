# Hands-on 4 - Employee CRUD Operations

## Objective

Perform create, read, update and delete operations on hardcoded Employee data using ASP.NET Core Web API.

## Implemented Operations

| Verb | Route | Operation |
|---|---|---|
| GET | `/api/Emp` | Retrieve all employees |
| GET | `/api/Emp/{id}` | Retrieve one employee |
| POST | `/api/Emp` | Create an employee |
| PUT | `/api/Emp/{id}` | Update an employee |
| DELETE | `/api/Emp/{id}` | Delete an employee |

## PUT Validation

The PUT action validates the route ID before updating an employee.

The following conditions return `400 Bad Request`:

- ID is less than or equal to zero
- ID is positive but does not exist in the employee list

Response message:

```text
Invalid employee id
```

A valid ID updates the corresponding employee using data supplied through `[FromBody]` and returns the updated record.

## DELETE Validation

The DELETE action applies the same ID validation before removing an employee.

A successful deletion returns:

```text
204 No Content
```

## Authorization Header

Employee endpoints require:

```text
Authorization: Bearer demo-token
```

## Build and Run

```bash
dotnet build
dotnet run
```

## Testing

The CRUD endpoints can be tested using Swagger, Postman or curl.