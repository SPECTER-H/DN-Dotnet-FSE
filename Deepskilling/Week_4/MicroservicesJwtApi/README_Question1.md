# Question 1 — Implement JWT Authentication

## Objective

Implement JWT-based authentication in an ASP.NET Core Web API microservice.

## Scenario

The microservice requires a secure login mechanism. When valid credentials are submitted, the API generates and returns a JSON Web Token.

## Files

- `Models/User.cs` — represents a valid application user.
- `Models/LoginModel.cs` — represents the submitted login credentials.
- `Controllers/AuthController.cs` — validates credentials and generates JWT tokens.
- `Program.cs` — configures JWT authentication and authorization.
- `appsettings.json` — contains the JWT issuer, audience, key and token duration.

## Login Endpoint

```http
POST /api/auth/login
```

### Valid Request

```json
{
  "username": "admin",
  "password": "Admin@123"
}
```

### Successful Response

```text
HTTP/1.1 200 OK
```

```json
{
  "token": "eyJ..."
}
```

### Invalid Credentials

Invalid credentials return:

```text
HTTP/1.1 401 Unauthorized
```

## JWT Configuration

The token contains the authenticated username as a claim and is signed using the HMAC-SHA256 algorithm.

The following values are configured in `appsettings.json`:

- Issuer: `MyAuthServer`
- Audience: `MyApiUsers`
- Duration: 60 minutes
- Signing algorithm: HMAC-SHA256

The signing key from the official exercise was extended to meet the minimum key-length requirement enforced by current JWT libraries.

## Build

```bash
dotnet build
```

## Run

```bash
dotnet run --no-launch-profile -- \
  --urls http://localhost:5214
```

## Test

### Valid Login

```bash
curl -i \
  -X POST \
  -H "Content-Type: application/json" \
  -d '{"username":"admin","password":"Admin@123"}' \
  http://localhost:5214/api/auth/login
```

### Invalid Login

```bash
curl -i \
  -X POST \
  -H "Content-Type: application/json" \
  -d '{"username":"admin","password":"wrong"}' \
  http://localhost:5214/api/auth/login
```

## Result

JWT authentication was configured successfully. Valid credentials return a signed JWT token, while invalid credentials return `401 Unauthorized`.

## Security Note

The users and JWT key are stored directly in the project only for this hands-on exercise. Production applications should store user credentials securely and keep signing keys outside source control using secrets or environment variables.