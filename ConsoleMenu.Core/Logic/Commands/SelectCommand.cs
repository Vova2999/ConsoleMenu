using System;
using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic.Commands;

public class SelectCommand<TValue, TSubValue> : ICommand<TValue>
{
	public string Description { get; }

	private readonly ICommand<TSubValue> _command;
	private readonly Func<TValue, TSubValue> _selector;

	public SelectCommand(string description, ICommand<TSubValue> command, Func<TValue, TSubValue> selector)
	{
		Description = description;
		_command = command;
		_selector = selector;
	}

	public Task ExecuteAsync(TValue value)
	{
		return _command.ExecuteAsync(_selector(value));
	}
}