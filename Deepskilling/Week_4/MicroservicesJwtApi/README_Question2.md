# Question 2 — Secure an API Endpoint Using JWT

## Objective

Restrict access to a sensitive API endpoint using JWT Bearer authentication.

## Scenario

The microservice contains protected information that must only be accessible to authenticated users carrying a valid JWT token.

## Files

- `Controllers/SecureController.cs` — contains the JWT-protected endpoint.
- `Controllers/AuthController.cs` — generates JWT tokens after successful login.
- `Program.cs` — configures JWT authentication and authorization.
- `appsettings.json` — contains the JWT validation configuration.

## Protected Endpoint

```http
GET /api/secure/data
```

The endpoint uses the `[Authorize]` attribute:

```csharp
[HttpGet("data")]
[Authorize]
public IActionResult GetSecureData()
{
    return Ok("This is protected data.");
}
```

## Test Without a Token

```bash
curl -i http://localhost:5214/api/secure/data
```

Expected response:

```text
HTTP/1.1 401 Unauthorized
```

## Generate a Valid Token

```bash
TOKEN=$(
  curl -s \
    -X POST \
    -H "Content-Type: application/json" \
    -d '{"username":"admin","password":"Admin@123"}' \
    http://localhost:5214/api/auth/login |
  python3 -c 'import json,sys; print(json.load(sys.stdin)["token"])'
)
```

## Test With a Valid Token

```bash
curl -i \
  -H "Authorization: Bearer $TOKEN" \
  http://localhost:5214/api/secure/data
```

Expected response:

```text
HTTP/1.1 200 OK
```

```text
This is protected data.
```

## Authentication Behaviour

| Request | Result |
|---|---|
| No JWT token | `401 Unauthorized` |
| Invalid JWT token | `401 Unauthorized` |
| Valid JWT token | `200 OK` |
| Expired JWT token | `401 Unauthorized` |

## Result

The endpoint was successfully protected using `[Authorize]`. Requests without a valid JWT token were rejected, while authenticated requests received the protected response.