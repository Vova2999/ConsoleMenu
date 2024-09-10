using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuWithListValues<TValue> : MenuBase<IEnumerable<TValue>>
{
	private readonly ICommand<TValue> _command;
	private readonly Func<TValue, string> _getValueDescription;

	protected MenuWithListValues(ICommand<TValue> command, Func<TValue, string> getValueDescription)
	{
		_command = command;
		_getValueDescription = getValueDescription;
	}

	protected MenuWithListValues(bool isBackAfterExecute, ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(isBackAfterExecute)
	{
		_command = command;
		_getValueDescription = getValueDescription;
	}

	protected override IEnumerable<string> GetCommandDescriptions(IEnumerable<TValue> values)
	{
		return values.Select(_getValueDescription);
	}

	protected override int ReadSelector(IEnumerable<TValue> values)
	{
		return ConsoleReadHelper.ReadInt(" => ", 0, values.Count());
	}

	protected override void ExecuteCommand(IEnumerable<TValue> values, int index)
	{
		_command.Execute(values.ElementAt(index));
	}

	protected override bool IsBackAfterExecuteCommand(int index)
	{
		return _command.IsBackAfterExecute;
	}
}