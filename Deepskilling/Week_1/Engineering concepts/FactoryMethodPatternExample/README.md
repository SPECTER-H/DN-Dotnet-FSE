# Implementing the Factory Method Pattern

Exercise: Implement the Factory Method design pattern to create different types of documents.

## Files

- `IDocument.cs` — Interface for document operations.
- `DocumentFactory.cs` — Abstract factory class.
- `WordDocument.cs` — Word document implementation.
- `PdfDocument.cs` — PDF document implementation.
- `ExcelDocument.cs` — Excel document implementation.
- `WordFactory.cs` — Factory for Word documents.
- `PdfFactory.cs` — Factory for PDF documents.
- `ExcelFactory.cs` — Factory for Excel documents.
- `Program.cs` — Demonstrates document creation using factories.

## How to build and run

```bash
dotnet build
dotnet run
```

## Sample Output

```text
Word document opened.
PDF document opened.
Excel document opened.
```

## Explanation

The Factory Method Pattern delegates object creation to subclasses.

Each concrete factory is responsible for creating one specific document type, thereby reducing tight coupling between the client and concrete classes.

## Notes

- Implemented using .NET 10 Console Application.
- Demonstrates the Factory Method Design Pattern.