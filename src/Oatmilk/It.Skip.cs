﻿using System.Runtime.CompilerServices;
using static Oatmilk.TestBuilder;

namespace Oatmilk;

/// <summary>
/// Provides methods for creating variations of Tests, such as Only, Each, and Skip.
/// </summary>
public static partial class It
{
  /// <summary>
  /// Creates a suite of tests that will be skipped for every element in the <paramref name="values"/> collection..
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionFormatString">A format string that is used to generate the test's description.  Each value from <paramref name="values"/> is used as the 0th param.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip<T>(
    IEnumerable<T> values,
    string descriptionFormatString,
    Action<T, TestInput> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, descriptionFormatString, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be skipped for every element in the <paramref name="values"/> collection..
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionFormatString">A format string that is used to generate the test's description.  Each value from <paramref name="values"/> is used as the 0th param.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip<T>(
    IEnumerable<T> values,
    string descriptionFormatString,
    Func<T, TestInput, Task> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, descriptionFormatString, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be skipped for every element in the <paramref name="values"/> collection..
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionResolver">A function that is used to generate the test's description.  Each value from <paramref name="values"/> is passed to it.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip<T>(
    IEnumerable<T> values,
    Func<T, string> descriptionResolver,
    Action<T, TestInput> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, descriptionResolver, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be skipped for every element in the <paramref name="values"/> collection..
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionResolver">A function that is used to generate the test's description.  Each value from <paramref name="values"/> is passed to it.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>

  public static void Skip<T>(
    IEnumerable<T> values,
    Func<T, string> descriptionResolver,
    Func<T, TestInput, Task> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, descriptionResolver, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a test that will be skipped.
  /// </summary>
  /// <param name="description">The description of the test</param>
  /// <param name="body">The method body of the test where assertions should be put</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip(
    string description,
    Func<TestInput, Task> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(description, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a test that will be skipped.
  /// </summary>
  /// <param name="description">The description of the test</param>
  /// <param name="body">The method body of the test where assertions should be put</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip(
    string description,
    Action<TestInput> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(description, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be skipped for every element in the <paramref name="values"/> collection..
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionFormatString">A format string that is used to generate the test's description.  Each value from <paramref name="values"/> is used as the 0th param.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip<T>(
    IEnumerable<T> values,
    string descriptionFormatString,
    Action<T> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, descriptionFormatString, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be skipped for every element in the <paramref name="values"/> collection..
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionFormatString">A format string that is used to generate the test's description.  Each value from <paramref name="values"/> is used as the 0th param.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip<T>(
    IEnumerable<T> values,
    string descriptionFormatString,
    Func<T, Task> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, descriptionFormatString, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be skipped for every element in the <paramref name="values"/> collection..
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionResolver">A function that is used to generate the test's description.  Each value from <paramref name="values"/> is passed to it.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip<T>(
    IEnumerable<T> values,
    Func<T, string> descriptionResolver,
    Action<T> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, descriptionResolver, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a suite of tests that will be skipped for every element in the <paramref name="values"/> collection..
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionResolver">A function that is used to generate the test's description.  Each value from <paramref name="values"/> is passed to it.</param>
  /// <param name="body">The method body of the test where assertions should be put. Each value from <paramref name="values"/> is passed to this.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>

  public static void Skip<T>(
    IEnumerable<T> values,
    Func<T, string> descriptionResolver,
    Func<T, Task> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, descriptionResolver, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a test that will be skipped.
  /// </summary>
  /// <param name="description">The description of the test</param>
  /// <param name="body">The method body of the test where assertions should be put</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip(
    string description,
    Func<Task> body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(description, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// Creates a test that will be skipped.
  /// </summary>
  /// <param name="description">The description of the test</param>
  /// <param name="body">The method body of the test where assertions should be put</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static void Skip(
    string description,
    Action body,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(description, testOptions, lineNumber, filePath).When(body);

  /// <summary>
  /// A fluent api for creating a test that will be skipped. See <see cref="ItBlock.When(Action)"/>.
  /// </summary>
  /// <param name="description">The description of the test</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static ItBlock Skip(
    string description,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) =>
    new(
      Description: description,
      IsOnly: false,
      IsSkipped: true,
      TestOptions: testOptions,
      LineNumber: lineNumber,
      FilePath: filePath
    );

  /// <summary>
  /// A fluent api for creating a suite of tests that will be skipped. See <see cref="ItEachBlock{T}.When(Action{T})"/>.
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionFormatString">A format string that is used to generate the test's description.  Each value from <paramref name="values"/> is used as the 0th param.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static ItEachBlock<T> Skip<T>(
    IEnumerable<T> values,
    string descriptionFormatString,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) => Skip(values, x => SafeFormat(descriptionFormatString, x), testOptions, lineNumber, filePath);

  /// <summary>
  /// A fluent api for creating a suite of tests that will be skipped. See <see cref="ItEachBlock{T}.When(Action{T})"/>.
  /// </summary>
  /// <typeparam name="T">The type of the data to be passed to the test's method body</typeparam>
  /// <param name="values">A list of values to pass to the test</param>
  /// <param name="descriptionResolver">A function that is used to generate the test's description.  Each value from <paramref name="values"/> is passed to it.</param>
  /// <param name="testOptions">The options for the test, including the timeout</param>
  /// <param name="lineNumber">Leave unset, used by the runtime to support running tests via the IDE</param>
  /// <param name="filePath">Leave unset, used by the runtime to support running tests via the IDE</param>
  public static ItEachBlock<T> Skip<T>(
    IEnumerable<T> values,
    Func<T, string> descriptionResolver,
    TestOptions testOptions = default,
    [CallerLineNumber] int lineNumber = 0,
    [CallerFilePath] string filePath = ""
  ) =>
    new(
      values,
      descriptionResolver,
      IsOnly: false,
      IsSkipped: true,
      testOptions,
      lineNumber,
      filePath
    );
}
