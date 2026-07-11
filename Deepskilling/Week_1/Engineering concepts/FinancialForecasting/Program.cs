namespace FinancialForecasting;
class Program
{
    static void Main(string[] args)
    {
        var calculator =
            new ForecastCalculator();

        double currentValue = 10000;
        double growthRate = 0.10;
        int years = 5;

        double futureValue =
            calculator.PredictFutureValue(
                currentValue,
                growthRate,
                years
            );

        Console.WriteLine(
            $"Future Value after {years} years: {futureValue:F2}"
        );
    }
}