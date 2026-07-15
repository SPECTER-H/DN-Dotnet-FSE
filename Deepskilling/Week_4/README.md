# Week 4 — Microservices and JWT Authentication

This folder contains the completed Week 4 hands-on exercises for the Cognizant Digital Nurture **.NET Angular FSE** Deep Skilling program.

The implementation follows the official `1. Microservices - JWT.pdf` exercise document.

## Exercise Mapping

The mandatory hands-on spreadsheet identifies Question 1 as mandatory. Questions 2–4 from the official document were also completed to cover all additional exercises.

| Question | Topic | Status | Documentation |
|---|---|---|---|
| 1 | Implement JWT authentication | Completed | [README_Question1.md](MicroservicesJwtApi/README_Question1.md) |
| 2 | Secure an API endpoint using JWT | Completed | [README_Question2.md](MicroservicesJwtApi/README_Question2.md) |
| 3 | Add role-based authorization | Completed | [README_Question3.md](MicroservicesJwtApi/README_Question3.md) |
| 4 | Validate token expiry and handle unauthorized access | Completed | [README_Question4.md](MicroservicesJwtApi/README_Question4.md) |

## Project Structure

```text
Week_4/
├── MicroservicesJwtApi/
│   ├── Controllers/
│   │   ├── AdminController.cs
│   │   ├── AuthController.cs
│   │   └── SecureController.cs
│   ├── Models/
│   │   ├── LoginModel.cs
│   │   └── User.cs
│   ├── Program.cs
│   ├── appsettings.json
│   ├── README_Question1.md
│   ├── README_Question2.md
│   ├── README_Question3.md
│   └── README_Question4.md
└── README.md
```

## Features Implemented

- JWT Bearer authentication
- Secure login endpoint
- Username and password validation
- Signed JWT token generation
- Issuer and audience validation
- Token lifetime validation
- HMAC-SHA256 signing
- Protected API endpoints
- Role claims
- Admin-only authorization
- Expired-token detection
- Custom `401 Unauthorized` responses
- Custom `403 Forbidden` responses

## Test Users

| Username | Password | Role |
|---|---|---|
| `admin` | `Admin@123` | Admin |
| `user` | `User@123` | User |

These users are stored in memory only for the hands-on demonstration.

## Endpoints

| Method | Endpoint | Access |
|---|---|---|
| POST | `/api/auth/login` | Anonymous |
| GET | `/api/secure/data` | Authenticated users |
| GET | `/api/admin/dashboard` | Admin role only |

## Build

```bash
dotnet build MicroservicesJwtApi/MicroservicesJwtApi.csproj
```

## Run

```bash
dotnet run \
  --project MicroservicesJwtApi/MicroservicesJwtApi.csproj \
  --no-launch-profile -- \
  --urls http://localhost:5214
```

## Verification

The following scenarios were tested successfully:

- Valid login returns a JWT token
- Invalid credentials return `401 Unauthorized`
- Protected endpoint without a token returns `401`
- Protected endpoint with a valid token returns `200`
- Admin endpoint without a token returns `401`
- User role accessing the Admin endpoint returns `403`
- Admin role accessing the Admin endpoint returns `200`
- Invalid JWT returns a custom unauthorized response
- Expired JWT returns the `Token-Expired` header
- Expired JWT returns a custom expiry message

## Technologies

- C#
- .NET
- ASP.NET Core Web API
- JWT Bearer Authentication
- Role-Based Authorization
- Microsoft IdentityModel Tokens

## Security Note

The credentials and JWT signing key are stored directly in the project only for training purposes. Production systems should use a database, password hashing, environment variables and a secure secrets-management service.

## Status

**Week 4 completed:** The mandatory JWT authentication exercise and all additional exercises from the official document have been implemented, tested and documented.