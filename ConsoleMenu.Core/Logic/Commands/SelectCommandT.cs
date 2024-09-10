using System;

namespace ConsoleMenu.Core.Logic.Commands;

public class SelectCommand<TValue, TSubValue> : ICommand<TValue>
{
	public string Description => _command.Description;

	private readonly ICommand<TSubValue> _command;
	private readonly Func<TValue, TSubValue> _selector;

	public SelectCommand(ICommand<TSubValue> command, Func<TValue, TSubValue> selector)
	{
		_command = command;
		_selector = selector;
	}

	public void Execute(TValue value)
	{
		_command.Execute(_selector(value));
	}
}