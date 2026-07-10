namespace SingletonPatternExample;

public sealed class Logger
{
    private static readonly Logger instance =
        new Logger();

    private Logger()
    {
    }

    public static Logger GetInstance()
    {
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine(
            $"[{DateTime.Now:HH:mm:ss}] {message}"
        );
    }
}