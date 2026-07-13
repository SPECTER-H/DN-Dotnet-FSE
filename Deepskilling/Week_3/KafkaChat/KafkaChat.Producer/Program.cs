using Confluent.Kafka;

const string topic = "chat-message";

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092",
    ClientId = "kafka-chat-producer"
};

using var producer =
    new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("Kafka Chat Producer");
Console.WriteLine("Type a message and press Enter.");
Console.WriteLine("Type 'exit' to stop.");
Console.WriteLine();

while (true)
{
    Console.Write("Message: ");

    var message = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(message))
    {
        continue;
    }

    if (message.Equals(
            "exit",
            StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    try
    {
        var result = await producer.ProduceAsync(
            topic,
            new Message<Null, string>
            {
                Value = message
            });

        Console.WriteLine(
            $"Sent to partition {result.Partition}, " +
            $"offset {result.Offset}.");
    }
    catch (ProduceException<Null, string> exception)
    {
        Console.WriteLine(
            $"Message delivery failed: " +
            $"{exception.Error.Reason}");
    }
}

producer.Flush(TimeSpan.FromSeconds(5));

Console.WriteLine("Producer stopped.");