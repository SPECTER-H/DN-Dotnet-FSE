using NUnit.Framework;
using UtilLib;

namespace UtilLib.Tests;

[TestFixture]
public class UrlHostNameParserTests
{
    private UrlHostNameParser parser;

    [SetUp]
    public void Setup()
    {
        parser = new UrlHostNameParser();
    }

    [Test]
    public void ParseHostName_HttpUrl_ReturnsHostName()
    {
        var result =
            parser.ParseHostName(
                "http://www.google.com/search"
            );

        Assert.That(result,
            Is.EqualTo("www.google.com"));
    }

    [Test]
    public void ParseHostName_HttpsUrl_ReturnsHostName()
    {
        var result =
            parser.ParseHostName(
                "https://www.github.com/user"
            );

        Assert.That(result,
            Is.EqualTo("www.github.com"));
    }

    [Test]
    public void ParseHostName_InvalidProtocol_ThrowsException()
    {
        Assert.Throws<FormatException>(
            () => parser.ParseHostName(
                "ftp://files.server.com"
            )
        );
    }
}