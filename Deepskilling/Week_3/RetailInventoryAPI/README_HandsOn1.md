# Hands-on 1 - First ASP.NET Core Web API

## Objective

Create a controller-based ASP.NET Core Web API and demonstrate read and write actions using HTTP action verbs.

## Implemented Actions

| Verb | Route | Purpose |
|---|---|---|
| GET | `/api/values` | Return all values |
| GET | `/api/values/{id}` | Return one value |
| POST | `/api/values` | Add a value |
| PUT | `/api/values/{id}` | Update a value |
| DELETE | `/api/values/{id}` | Delete a value |

## Concepts Covered

- RESTful Web APIs
- HTTP requests and responses
- Controllers and action methods
- Attribute routing
- `HttpGet`, `HttpPost`, `HttpPut` and `HttpDelete`
- Action results and HTTP status codes
- `appsettings.json` and `launchSettings.json`

## Build and Run

```bash
dotnet build
dotnet run
```

## Sample Response

```json
["value1", "value2"]
```

## Notes

The official document uses the older `Startup.cs` hosting model. This project uses the current ASP.NET Core hosting model in `Program.cs` while preserving the required controller and action behavior.