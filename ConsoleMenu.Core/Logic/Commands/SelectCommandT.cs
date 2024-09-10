using System;
using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic.Commands;

public class SelectCommand<TValue, TSubValue> : ICommand<TValue>
{
	public string Description => _command.Description;
	public bool IsBackAfterExecute => _command.IsBackAfterExecute;

	private readonly ICommand<TSubValue> _command;
	private readonly Func<TValue, TSubValue> _selector;

	public SelectCommand(ICommand<TSubValue> command, Func<TValue, TSubValue> selector)
	{
		_command = command;
		_selector = selector;
	}

	public Task ExecuteAsync(TValue value)
	{
		return _command.ExecuteAsync(_selector(value));
	}
}