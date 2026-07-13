using Confluent.Kafka;

const string topic = "chat-message";

var clientName = args.Length > 0
    ? args[0]
    : $"client-{Guid.NewGuid():N}"[..13];

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = $"kafka-chat-{clientName}",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    EnableAutoCommit = true
};

using var consumer =
    new ConsumerBuilder<Ignore, string>(config).Build();

consumer.Subscribe(topic);

using var cancellation = new CancellationTokenSource();

Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    cancellation.Cancel();
};

Console.WriteLine($"Kafka Chat Consumer: {clientName}");
Console.WriteLine($"Listening to topic: {topic}");
Console.WriteLine("Press Control+C to stop.");
Console.WriteLine();

try
{
    while (!cancellation.IsCancellationRequested)
    {
        var result = consumer.Consume(
            cancellation.Token);

        Console.WriteLine(
            $"[{result.Message.Timestamp.UtcDateTime:HH:mm:ss}] " +
            $"{result.Message.Value}");
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine();
    Console.WriteLine("Stopping consumer...");
}
finally
{
    consumer.Close();
}