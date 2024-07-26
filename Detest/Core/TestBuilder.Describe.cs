﻿using System.Runtime.CompilerServices;

namespace Detest.Core;

/// <summary>
/// Provides methods for building test suites using a declarative syntax.
/// Generally should be used with the <c>using static Detest.Core.TestBuilder</c> directive.
/// </summary>
public static partial class TestBuilder
{
  /// <summary>
  /// Obsolete. Descriptions must be synchronous, and async bodies should be moved to <see cref="BeforeAll(Func{Task})"/>, <see cref="BeforeEach(Func{Task})" />.
  /// Use <see cref="Describe(string,Action)"/> instead.
  /// </summary>
  /// <param name="description"></param>
  /// <param name="body"></param>
  /// <exception cref="InvalidOperationException">This method will always throw an exception.</exception>
  [Obsolete(
    "Do not call Describe with an async body. Use BeforeAll, BeforeEach to perform asynchronous test setup. Remove async from the method signature to fix this error."
  )]
  public static void Describe(string description, Func<Task> body) =>
    throw new InvalidOperationException(
      @"Must call Describe methods with a synchronous body.
             Use BeforeAll, BeforeEach to perform asynchronous test setup.
             Remove async from the method signature to fix this error."
    );

  /// <summary>
  /// Describes a suite of tests.
  /// This method runs synchronously, and allows for the creation of nested test suites.
  /// </summary>
  /// <param name="description">The description of this block of the test suite.</param>
  /// <param name="body">A callback which is immediately invoked to describe tests</param>
  public static void Describe(string description, Action body)
  {
    if (RootScope == null)
    {
      CurrentScope = new TestScope(description, null);
      RootScope = CurrentScope;
    }
    else
    {
      var parent = CurrentScope;
      CurrentScope = new TestScope(description, parent);
      parent?.Children.Add(CurrentScope);
    }

    body();
    // Pop back to the parent scope after running all the inner scopes
    CurrentScope = CurrentScope.Parent;
  }

  /// <summary>
  /// Describes a suite of tests using a fluent syntax.  Specify the body of the suite using the <see cref="DescribeBlock.As" /> method.
  /// </summary>
  /// <param name="description">The description of this block of the test suite.</param>
  /// <returns>A <see cref="DescribeBlock" /> object which allows for the creation of nested test suites.</returns>
  public static DescribeBlock Describe(string description)
  {
    if (RootScope == null)
    {
      CurrentScope = new TestScope(description, null);
      RootScope = CurrentScope;
    }
    else
    {
      var parent = CurrentScope;
      CurrentScope = new TestScope(description, parent);
      parent?.Children.Add(CurrentScope);
    }

    return new DescribeBlock(description);
  }

  /// <summary>
  /// A builder object for creating nested test suites using a fluent syntax.
  /// </summary>
  /// <param name="Description">The description for the block of tests.</param>
  public record DescribeBlock(string Description)
  {
    /// <summary>
    /// Describes a suite of tests within the current scope.
    /// </summary>
    /// <param name="body">An action containing the tests to run in this scope.</param>
    public void As(Action body)
    {
      body();
      // Pop back to the parent scope after running all the inner scopes
      CurrentScope = CurrentScopeNotNull.Parent;
    }
  }
}
