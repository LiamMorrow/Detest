using Detest.Core;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Detest.Xunit;

internal class XunitDetestMessageBus(IMessageBus messageBus, IXunitTestCase xunitTestMethod)
  : IDetestMessageBus
{
  public void OnTestFailed(
    TestBlock testBlock,
    TestScope testScope,
    Exception ex,
    TimeSpan executionTime,
    string output
  )
  {
    messageBus.QueueMessage(
      new TestFailed(GetTest(testBlock, testScope), (decimal)executionTime.TotalSeconds, output, ex)
    );
  }

  public void OnTestFinished(
    TestBlock testBlock,
    TestScope testScope,
    TimeSpan executionTime,
    string output
  )
  {
    messageBus.QueueMessage(
      new TestFinished(GetTest(testBlock, testScope), (decimal)executionTime.TotalSeconds, output)
    );
  }

  public void OnTestOutput(TestBlock testBlock, TestScope testScope, string output)
  {
    messageBus.QueueMessage(new TestOutput(GetTest(testBlock, testScope), output));
  }

  public void OnTestPassed(
    TestBlock testBlock,
    TestScope testScope,
    TimeSpan executionTime,
    string output
  )
  {
    messageBus.QueueMessage(
      new TestPassed(GetTest(testBlock, testScope), (decimal)executionTime.TotalSeconds, output)
    );
  }

  public void OnTestSkipped(TestBlock testBlock, TestScope testScope, string reason)
  {
    messageBus.QueueMessage(new TestSkipped(GetTest(testBlock, testScope), reason));
  }

  public void OnTestStarting(TestBlock testBlock, TestScope testScope)
  {
    messageBus.QueueMessage(new TestStarting(GetTest(testBlock, testScope)));
  }

  private ITest GetTest(TestBlock testBlock, TestScope testScope) =>
    new XunitTest(xunitTestMethod, testBlock.GetDescription(testScope));
}
