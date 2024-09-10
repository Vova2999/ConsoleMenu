using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Extensions;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuBase
{
	protected abstract string BackCommandDescription { get; }

	public void Start()
	{
		while (true)
		{
			Console.Clear();
			PrintCommands();

			var selector = ReadSelector();
			if (selector == 0)
				break;

			ExecuteCommand(selector - 1);
		}
	}

	protected virtual void PrintCommands()
	{
		GetCommandDescriptions()
			.Select((description, i) => $"{i + 1}: {description}")
			.Concat($"0: {BackCommandDescription}".AsEnumerable())
			.ForEach(Console.WriteLine);
	}

	protected abstract IEnumerable<string> GetCommandDescriptions();

	protected abstract int ReadSelector();

	protected abstract void ExecuteCommand(int index);
}