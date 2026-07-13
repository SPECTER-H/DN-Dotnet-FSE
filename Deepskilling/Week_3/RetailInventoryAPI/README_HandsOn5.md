# Hands-on 5 - CORS and JWT Authentication

## Objective

Enable CORS and secure Employee API endpoints using JWT bearer authentication and role-based authorization.

## Implemented

- CORS policy for Angular at `http://localhost:4200`
- JWT generation through `AuthController`
- Bearer-token authentication
- Issuer, audience, lifetime and signature validation
- Two-minute token expiration
- Role claims
- POC-only authorization test
- Combined POC and Admin authorization
- Swagger JWT support

## Auth Endpoint

```text
GET /api/Auth?userId=1&userRole=Admin
```

## Protected Employee API

The Employee controller uses:

```csharp
[Authorize(Roles = "POC,Admin")]
```

Requests must include:

```text
Authorization: Bearer <token>
```

## Expected Responses

| Scenario | Status |
|---|---|
| Missing token | 401 Unauthorized |
| Invalid or modified token | 401 Unauthorized |
| Valid token with disallowed role | 403 Forbidden |
| Valid Admin or POC token | 200 OK |
| Expired token | 401 Unauthorized |

## CORS

Requests from the future Angular application are allowed from:

```text
http://localhost:4200
```

## Build and Run

```bash
dotnet build
dotnet run
```