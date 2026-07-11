namespace FactoryMethodPatternExample;

public class ExcelDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Excel document opened.");
    }
}