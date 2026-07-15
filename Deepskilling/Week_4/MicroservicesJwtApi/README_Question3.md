# Question 3 — Role-Based Authorization

## Objective

Restrict selected API endpoints so that only authenticated users with the `Admin` role can access them.

## Scenario

The microservice contains an administrative dashboard. An authenticated user without the required role must not be allowed to access it.

## Files

- `Models/User.cs` — stores the username, password and assigned role.
- `Controllers/AuthController.cs` — adds the user's role to the generated JWT.
- `Controllers/AdminController.cs` — contains the Admin-only endpoint.
- `Program.cs` — configures JWT authentication and authorization.

## Test Users

| Username | Password | Role |
|---|---|---|
| `admin` | `Admin@123` | Admin |
| `user` | `User@123` | User |

These in-memory users are included only for the hands-on demonstration.

## Role Claim

The authenticated user's role is added to the JWT:

```csharp
var claims = new[]
{
    new Claim(ClaimTypes.Name, user.Username),
    new Claim(ClaimTypes.Role, user.Role)
};
```

## Admin Endpoint

```http
GET /api/admin/dashboard
```

The endpoint is restricted using:

```csharp
[Authorize(Roles = "Admin")]
```

## Test Without a Token

```bash
curl -i http://localhost:5214/api/admin/dashboard
```

Expected:

```text
HTTP/1.1 401 Unauthorized
```

## Test With a User Token

Generate a token for the ordinary user:

```bash
USER_TOKEN=$(
  curl -s \
    -X POST \
    -H "Content-Type: application/json" \
    -d '{"username":"user","password":"User@123"}' \
    http://localhost:5214/api/auth/login |
  python3 -c 'import json,sys; print(json.load(sys.stdin)["token"])'
)
```

Access the Admin endpoint:

```bash
curl -i \
  -H "Authorization: Bearer $USER_TOKEN" \
  http://localhost:5214/api/admin/dashboard
```

Expected:

```text
HTTP/1.1 403 Forbidden
```

The token is valid, but the user does not have the required role.

## Test With an Admin Token

Generate an Admin token:

```bash
ADMIN_TOKEN=$(
  curl -s \
    -X POST \
    -H "Content-Type: application/json" \
    -d '{"username":"admin","password":"Admin@123"}' \
    http://localhost:5214/api/auth/login |
  python3 -c 'import json,sys; print(json.load(sys.stdin)["token"])'
)
```

Access the Admin endpoint:

```bash
curl -i \
  -H "Authorization: Bearer $ADMIN_TOKEN" \
  http://localhost:5214/api/admin/dashboard
```

Expected:

```text
HTTP/1.1 200 OK
```

```text
Welcome to the admin dashboard.
```

## Authorization Behaviour

| Request | Result |
|---|---|
| No token | `401 Unauthorized` |
| Valid User token | `403 Forbidden` |
| Valid Admin token | `200 OK` |
| Invalid or expired token | `401 Unauthorized` |

## Result

Role-based authorization was implemented successfully. Only a JWT containing the `Admin` role claim can access the administrative dashboard.