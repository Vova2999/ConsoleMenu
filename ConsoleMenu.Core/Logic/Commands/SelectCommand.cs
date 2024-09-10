using System;

namespace ConsoleMenu.Core.Logic.Commands;

public class SelectCommand<TSubValue> : ICommand
{
	public string Description { get; }

	private readonly ICommand<TSubValue> _command;
	private readonly Func<TSubValue> _selector;

	public SelectCommand(string description, ICommand<TSubValue> command, Func<TSubValue> selector)
	{
		Description = description;
		_command = command;
		_selector = selector;
	}

	public void Execute()
	{
		_command.Execute(_selector());
	}
}