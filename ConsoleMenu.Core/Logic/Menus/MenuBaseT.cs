using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.Core.Extensions;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuBase<TValue>
{
	private readonly bool _isBackAfterExecute;

	protected abstract string BackCommandDescription { get; }

	protected MenuBase(bool isBackAfterExecute = false)
	{
		_isBackAfterExecute = isBackAfterExecute;
	}

	public async Task StartAsync(TValue value)
	{
		while (true)
		{
			Console.Clear();
			PrintCommands(value);

			var selector = ReadSelector(value);
			if (selector == 0)
				break;

			await ExecuteCommandAsync(value, selector - 1).ConfigureAwait(false);
			if (_isBackAfterExecute || IsBackAfterExecuteCommand(selector - 1))
				break;
		}
	}

	protected virtual void PrintCommands(TValue value)
	{
		GetCommandDescriptions(value)
			.Select((description, i) => $"{i + 1}: {description}")
			.Concat($"0: {BackCommandDescription}".AsEnumerable())
			.ForEach(Console.WriteLine);
	}

	protected abstract IEnumerable<string> GetCommandDescriptions(TValue value);

	protected abstract int ReadSelector(TValue value);

	protected abstract Task ExecuteCommandAsync(TValue value, int index);

	protected abstract bool IsBackAfterExecuteCommand(int index);
}