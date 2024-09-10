using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Extensions;

internal static class EnumerableExtensions
{
	internal static void ForEach<TValue>(this IEnumerable<TValue> values, Action<TValue> action)
	{
		foreach (var value in values)
			action(value);
	}

	internal static IEnumerable<T> AsEnumerable<T>(this T item)
	{
		yield return item;
	}
}