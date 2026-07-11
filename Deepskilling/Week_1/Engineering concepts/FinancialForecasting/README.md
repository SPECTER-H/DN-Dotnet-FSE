# Financial Forecasting

Exercise: Predict future financial value using recursion.

## Files

- `ForecastCalculator.cs` - Recursive forecasting logic.
- `Program.cs` - Demonstrates financial forecasting.

## How to build and run

```bash
dotnet build
dotnet run
```

## Sample Output

```text
Future Value after 5 years: 16105.10
```

## Explanation

The future value is calculated using compound growth:

Future Value = Present Value × (1 + Growth Rate)^Years

The implementation uses recursion to repeatedly apply the growth rate for each year.

## Notes

- Implemented using .NET 10 Console Application.
- Demonstrates recursion and forecasting techniques.