﻿using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuWithCommands<TValue> : MenuBase<TValue>
{
	private readonly ICommand<TValue>[] _commands;

	protected MenuWithCommands(params ICommand<TValue>[] commands)
	{
		_commands = commands;
	}

	protected MenuWithCommands(bool isBackAfterExecute, params ICommand<TValue>[] commands) : base(isBackAfterExecute)
	{
		_commands = commands;
	}

	protected override IEnumerable<string> GetCommandDescriptions(TValue value)
	{
		return _commands.Select(command => command.Description);
	}

	protected override int ReadSelector(TValue value)
	{
		return ConsoleReadHelper.ReadInt(" => ", 0, _commands.Length);
	}

	protected override void ExecuteCommand(TValue value, int index)
	{
		_commands[index].Execute(value);
	}

	protected override bool IsBackAfterExecuteCommand(int index)
	{
		return _commands[index].IsBackAfterExecute;
	}
}