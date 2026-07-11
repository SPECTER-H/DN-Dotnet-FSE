# Implementing the Singleton Pattern

Exercise: Implement the Singleton design pattern using the Singleton pattern.

## Files

- `Logger.cs` — thread-safe singleton implementation.
- `Program.cs` — demo runner that obtains the singleton and logs messages.

## How to build and run

```bash
dotnet build
dotnet run
```

## Sample Output

```text
[13:00:25] First Message
[13:00:25] Second Message
Same Instance : True
```

## Explanation

The `Logger` class ensures that only one instance of the class exists throughout the application's lifetime.

- The constructor is private, preventing object creation from outside the class.
- A static instance of `Logger` is maintained inside the class.
- `GetInstance()` returns the same object every time it is called.

Since both `logger1` and `logger2` refer to the same object, the expression:

```csharp
ReferenceEquals(logger1, logger2)
```

returns:

```text
True
```

## Notes

- Run the commands from this project directory.
- The project was created using `.NET 10 Console Application`.
- This exercise demonstrates the core concepts of the Singleton Design Pattern.