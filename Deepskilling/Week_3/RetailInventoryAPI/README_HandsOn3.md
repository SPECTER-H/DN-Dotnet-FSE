# Hands-on 3 - Custom Models and Filters

## Objective

Create an Employee API using custom model classes, request-body binding, documented responses, a custom authorization filter and a custom exception filter.

## Models

- `Employee`
- `Department`
- `Skill`

## Implemented

- Standard employee list
- GET employee actions
- POST using `[FromBody]`
- PUT using `[FromBody]`
- `ProducesResponseType` documentation
- Custom Authorization-header filter
- Custom exception filter
- Exception logging to `Logs/exceptions.log`
- Swagger Authorization-header support

## Authorization Filter

Requests to `/api/Emp` require an `Authorization` header beginning with:

```text
Bearer
```

Missing headers return:

```text
Invalid request - No Auth token
```

Invalid schemes return:

```text
Invalid request - Token present but Bearer unavailable
```

## Exception Filter

The endpoint below deliberately raises an exception:

```text
GET /api/Emp/exception
```

The exception is logged locally and returned as HTTP status `500`.

## Build and Run

```bash
dotnet build
dotnet run
```