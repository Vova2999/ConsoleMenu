using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuWithListValues<TValue> : MenuBase<IList<TValue>>
{
	private readonly ICommand<TValue> _command;
	private readonly Func<TValue, string> _getValueDescription;

	protected MenuWithListValues(ICommand<TValue> command, Func<TValue, string> getValueDescription)
	{
		_command = command;
		_getValueDescription = getValueDescription;
	}

	protected override IEnumerable<string> GetCommandDescriptions(IList<TValue> values)
	{
		return values.Select(_getValueDescription);
	}

	protected override int ReadSelector(IList<TValue> values)
	{
		return ConsoleReadHelper.ReadInt(" => ", 0, values.Count);
	}

	protected override void ExecuteCommand(IList<TValue> values, int index)
	{
		_command.Execute(values[index]);
	}
}