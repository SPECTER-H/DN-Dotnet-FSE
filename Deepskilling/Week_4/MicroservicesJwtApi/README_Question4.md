# Question 4 — JWT Expiry and Unauthorized Access

## Objective

Detect expired or invalid JWT tokens and return clear responses when authentication or authorization fails.

## Scenario

The microservice must reject missing, invalid and expired tokens. It should also distinguish authentication failures from role-based authorization failures.

## Implementation

JWT Bearer events were configured in `Program.cs`:

- `OnAuthenticationFailed`
- `OnChallenge`
- `OnForbidden`

## Expired Token Detection

When JWT validation throws `SecurityTokenExpiredException`, the API adds the following response header:

```text
Token-Expired: true
```

The API also returns:

```json
{
  "message": "The JWT token has expired."
}
```

## Missing or Invalid Token

Requests without a valid JWT return:

```text
HTTP/1.1 401 Unauthorized
```

```json
{
  "message": "A valid JWT token is required."
}
```

## Forbidden Access

An authenticated user without the required role receives:

```text
HTTP/1.1 403 Forbidden
```

```json
{
  "message": "You do not have permission to access this resource."
}
```

## Authentication Behaviour

| Request | Status | Response |
|---|---:|---|
| Missing token | 401 | A valid JWT token is required |
| Invalid token | 401 | A valid JWT token is required |
| Expired token | 401 | The JWT token has expired |
| Valid token without the required role | 403 | Permission denied |
| Valid token with the required role | 200 | Protected data returned |

## Testing Token Expiry

The application was started with a temporary configuration override:

```bash
Jwt__DurationInMinutes=0 \
dotnet run --no-launch-profile -- \
  --urls http://localhost:5214
```

This override applied only to the running process and did not modify the 60-minute duration stored in `appsettings.json`.

The generated token was then used against a protected endpoint:

```bash
curl -i \
  -H "Authorization: Bearer $EXPIRED_TOKEN" \
  http://localhost:5214/api/secure/data
```

The API returned `401 Unauthorized`, the `Token-Expired` header and the custom expiry message.

## Result

JWT expiry detection and custom authentication responses were implemented successfully. The API now handles missing, invalid, expired and unauthorized tokens with appropriate HTTP status codes and messages.