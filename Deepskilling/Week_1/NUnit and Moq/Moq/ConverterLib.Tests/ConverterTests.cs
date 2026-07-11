using NUnit.Framework;
using Moq;
using ConverterLib;
using CurrencyConverterApp;

namespace ConverterLib.Tests;

[TestFixture]
public class ConverterTests
{
    [Test]
    public void USDToEuro_ValidDollar_ReturnsEuroValue()
    {
        var mockFeed =
            new Mock<IDollarToEuroExchangeRateFeed>();

        mockFeed.Setup(x =>
                x.GetActualUSDollarValue())
                .Returns(0.9);

        var converter =
            new Converter(mockFeed.Object);

        double result =
            converter.USDToEuro(100);

        Assert.That(result,
            Is.EqualTo(90));
    }
}