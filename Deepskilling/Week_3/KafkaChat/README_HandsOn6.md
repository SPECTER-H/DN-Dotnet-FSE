# Hands-on 6 - Kafka Chat Application

## Objective

Create C# chat applications that publish and consume messages using Apache Kafka as the streaming platform.

## Projects

```text
KafkaChat/
├── KafkaChat.Producer/
├── KafkaChat.Consumer/
├── KafkaChat.sln
└── README_HandsOn6.md
```

## Implemented

- Apache Kafka broker using KRaft
- `chat-message` topic
- C# console producer
- C# console consumer
- Multiple independent consumer clients
- Graceful producer and consumer shutdown
- Message delivery partition and offset output

## macOS Adaptation

The official exercise demonstrates a Windows Forms client. Windows Forms cannot execute on macOS without a Windows virtual machine.

To avoid a multi-gigabyte virtual machine, this implementation uses multiple cross-platform C# console clients. Each client runs independently and receives the streamed chat messages, preserving the required Kafka producer, consumer and multi-client behavior.

## Kafka Configuration

```text
Bootstrap server: localhost:9092
Topic: chat-message
Partitions: 1
Replication factor: 1
```

## Build

```bash
dotnet build KafkaChat.sln
```

## Run Consumer Clients

Terminal 1:

```bash
dotnet run \
--project KafkaChat.Consumer \
-- client-one
```

Terminal 2:

```bash
dotnet run \
--project KafkaChat.Consumer \
-- client-two
```

## Run Producer

Terminal 3:

```bash
dotnet run \
--project KafkaChat.Producer
```

Messages entered into the producer appear in both consumer terminals.

## Storage Management

The Kafka broker is downloaded under `/private/tmp` and is not committed to GitHub. Its broker data and downloaded files can be deleted after testing.