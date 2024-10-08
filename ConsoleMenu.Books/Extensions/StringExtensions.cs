﻿namespace ConsoleMenu.Books.Extensions;

public static class StringExtensions
{
	public static bool IsNullOrEmpty(this string str)
	{
		return string.IsNullOrEmpty(str);
	}

	public static bool IsSignificant(this string str)
	{
		return !string.IsNullOrEmpty(str);
	}
}