using System;
using System.Collections.Generic;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Books.Helpers;

public static class PrintHelper
{
	public static void ReadKeyForContinue()
	{
		Console.WriteLine("Нажмите любую клавишу для продолжения");
		Console.ReadKey();
	}

	public static void PrintWithPause<TValue>(IEnumerable<TValue> values, int pauseEveryPages = 5)
	{
		var index = 0;
		foreach (var value in values)
		{
			if (index != 0 && index % pauseEveryPages == 0)
			{
				Console.WriteLine();
				Console.WriteLine("1: Продолжить");
				Console.WriteLine("0: Прервать");

				var selector = ConsoleReadHelper.ReadInt(" => ", 0, 1);
				if (selector == 0)
					break;
			}

			index++;
			Console.WriteLine(value);
		}

		Console.WriteLine();
	}
}