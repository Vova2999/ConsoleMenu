using System;

namespace ConsoleMenu.Core.Logic.Commands;

public class SelectCommand<TSubValue> : ICommand
{
	public string Description => _command.Description;
	public bool IsBackAfterExecute => _command.IsBackAfterExecute;

	private readonly ICommand<TSubValue> _command;
	private readonly Func<TSubValue> _selector;

	public SelectCommand(ICommand<TSubValue> command, Func<TSubValue> selector)
	{
		_command = command;
		_selector = selector;
	}

	public void Execute()
	{
		_command.Execute(_selector());
	}
}