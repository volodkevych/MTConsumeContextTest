# MTConsumeContextTest
Test app to investigate MassTransit memory issues.

Steps to reproduce issue:

* Change RabbitSettings.cs to point to your Rabbit cluster.
* Publish `MTConsumeContextTest.Consumer.IMemoryIssuesTriggerMessage` message to **memory_issues_queue** queue.
* Check MemoryIssuesConsumer picks up the message - you are expected to see process memory growing now.
* If you publish `MTConsumeContextTest.Consumer.INoMemoryIssuesTriggerMessage` message to **no_memory_issues_queue**, MT publish behaves as expected.
