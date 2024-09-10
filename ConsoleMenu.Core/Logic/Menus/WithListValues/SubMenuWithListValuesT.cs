using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Logic.Menus.WithListValues;

public class SubMenuWithListValues<TValue> : MenuWithListValues<TValue>, ISubMenu<IReadOnlyList<TValue>>
{
	protected override string BackCommandDescription => "Назад";

	public string Description { get; }

	public SubMenuWithListValues(ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(command, getValueDescription)
	{
		Description = command.Description;
	}

	public SubMenuWithListValues(bool isBackAfterExecute, ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(isBackAfterExecute, command, getValueDescription)
	{
		Description = command.Description;
	}

	protected override void PrintCommands(IReadOnlyList<TValue> values)
	{
		Console.WriteLine($"<{Description}>");
		base.PrintCommands(values);
	}
}