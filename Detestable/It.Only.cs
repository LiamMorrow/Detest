﻿using System.Runtime.CompilerServices;
using static Detestable.TestBuilder;

namespace Detestable;

public static partial class It
{
  /// <summary>
  /// Creates a test that will be the only test being run.
  /// </summary>
  /// <param name="description">The description of the test</param>
  /// <param name="body">The test body. Assertions should go in here</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Only(
    string description,
    Func<Task> body,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Only(description, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a test that will be the only test being run.
  /// </summary>
  /// <param name="description">The description of the test</param>
  /// <param name="body">The test body. Assertions should go in here</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Only(
    string description,
    Action body,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Only(description, lineNumber, filePath).When(body);

  /// <summary>
  /// A fluent api for creating a test that will be the only test being run.
  /// See <see cref="ItBlock.When(Func{Task})"/>.
  /// </summary>
  /// <param name="description">The description of the test</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static ItBlock Only(
    string description,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) =>
    new(
      Description: description,
      IsOnly: true,
      IsSkipped: false,
      LineNumber: lineNumber,
      FilePath: filePath
    );

  /// <summary>
  /// Creates a suite of tests that will be the only tests being run for every element in the <paramref name="values"/> collection.
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionFormatString">A format string that is used to generate the test's description.  Each value from <paramref name="values"/> is used as the 0th param.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Only<T>(
    IEnumerable<T> values,
    string descriptionFormatString,
    Action<T> body,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Only(values, descriptionFormatString, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be the only tests being run for every element in the <paramref name="values"/> collection.
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionFormatString">A format string that is used to generate the test's description.  Each value from <paramref name="values"/> is used as the 0th param.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Only<T>(
    IEnumerable<T> values,
    string descriptionFormatString,
    Func<T, Task> body,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Only(values, descriptionFormatString, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be the only tests being run for every element in the <paramref name="values"/> collection.
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionResolver">A function that is used to generate the test's description.  Each value from <paramref name="values"/> is passed to it.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Only<T>(
    IEnumerable<T> values,
    Func<T, string> descriptionResolver,
    Action<T> body,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Only(values, descriptionResolver, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be the only tests being run for every element in the <paramref name="values"/> collection.
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionResolver">A function that is used to generate the test's description.  Each value from <paramref name="values"/> is passed to it.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Only<T>(
    IEnumerable<T> values,
    Func<T, string> descriptionResolver,
    Func<T, Task> body,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Only(values, descriptionResolver, lineNumber, filePath).When(body);

  /// <summary>
  /// A fluent api for creating a suite of tests that will be the only tests being run for every element in the <paramref name="values"/> collection.
  /// See <see cref="ItEachBlock{T}.When(Action{T})"/>.
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionFormatString">A format string that is used to generate the test's description.  Each value from <paramref name="values"/> is used as the 0th param.</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static ItEachBlock<T> Only<T>(
    IEnumerable<T> values,
    string descriptionFormatString,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) =>
    new(
      values,
      v => SafeFormat(descriptionFormatString, v),
      IsOnly: true,
      IsSkipped: false,
      lineNumber,
      filePath
    );

  /// <summary>
  /// A fluent api for creating a suite of tests for every element in the <paramref name="values"/> collection.
  /// See <see cref="ItEachBlock{T}.When(Action{T})"/>.
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionResolver">A function that is used to generate the test's description.  Each value from <paramref name="values"/> is passed to it.</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static ItEachBlock<T> Only<T>(
    IEnumerable<T> values,
    Func<T, string> descriptionResolver,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => new(values, descriptionResolver, IsOnly: true, IsSkipped: false, lineNumber, filePath);
}
