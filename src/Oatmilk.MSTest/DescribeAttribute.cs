using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oatmilk.Internal;

namespace Oatmilk.MSTest;

/// <summary>
/// Marks a test method as a method containing Oatmilk tests described with the various
/// <see cref="TestBuilder"/> methods. Implicitly begins a describe block.
/// </summary>
/// <param name="Description">The description of the test suite.</param>
/// <param name="FileName">The file path of the file containing the test suite.</param>
/// <param name="LineNumber">The line number of the test suite.</param>
///
/// <example>
/// <code>
/// [Describe("A test suite")]
/// public void Spec()
/// {
///    It("should pass", () => Assert.True(true));
/// }
/// </code>
/// </example>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class DescribeAttribute(
  string Description,
  [CallerFilePath] string FileName = "",
  [CallerLineNumber] int LineNumber = 0
) : TestMethodAttribute(Description)
{
  /// <summary>
  /// The description of the test suite.
  /// This is passed to the <see cref="TestBuilder.Describe(string, Action, TestOptions, int,string)"/> method.
  /// </summary>
  public string Description { get; } = Description;

  /// <summary>
  /// The file path of the file containing the test suite.
  /// </summary>
  public string FileName { get; } = FileName;

  /// <summary>
  /// The line number of the test suite.
  /// </summary>
  public int LineNumber { get; } = LineNumber;

  public override TestResult[] Execute(ITestMethod method)
  {
    TestBuilder.Describe(
      Description,
      () =>
      {
        method.Invoke(null);
      }
    );
    var rootScope = TestBuilder.ConsumeRootScope();
    var results = new List<TestResult>();
    foreach (var test in rootScope.EnumerateTests())
    {
      var testRunner = new OatmilkTestBlockRunner(
        test.TestScope,
        test.TestBlock,
        new DummyMessageBus()
      );
      var resultTask = testRunner.RunAsync();
      resultTask.Wait();
      var result = resultTask.Result;
      results.Add(Util.GetTestResult(result, test.TestScope, test.TestBlock));
    }
    return results.ToArray();
  }
}
