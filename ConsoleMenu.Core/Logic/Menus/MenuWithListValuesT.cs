﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuWithListValues<TValue> : MenuBase<IReadOnlyList<TValue>>
{
	private readonly ICommand<TValue> _command;
	private readonly Func<TValue, string> _getValueDescription;

	protected MenuWithListValues(ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(false)
	{
		_command = command;
		_getValueDescription = getValueDescription;
	}

	protected MenuWithListValues(bool isBackAfterExecute, ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(isBackAfterExecute)
	{
		_command = command;
		_getValueDescription = getValueDescription;
	}

	protected override IEnumerable<string> GetCommandDescriptions(IReadOnlyList<TValue> values)
	{
		return values.Select(_getValueDescription);
	}

	protected override int ReadSelector(IReadOnlyList<TValue> values)
	{
		return ConsoleReadHelper.ReadInt(" => ", 0, values.Count);
	}

	protected override void ExecuteCommand(IReadOnlyList<TValue> values, int index)
	{
		_command.Execute(values[index]);
	}
}