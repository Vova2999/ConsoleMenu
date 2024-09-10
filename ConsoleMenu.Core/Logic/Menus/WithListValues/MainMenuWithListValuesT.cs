using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Logic.Menus.WithListValues;

public class MainMenuWithListValues<TValue> : MenuWithListValues<TValue>, IMenu<IReadOnlyList<TValue>>
{
	protected override string BackCommandDescription => "Выход";

	public MainMenuWithListValues(ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(command, getValueDescription)
	{
	}

	public MainMenuWithListValues(bool isBackAfterExecute, ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(isBackAfterExecute, command, getValueDescription)
	{
	}
}