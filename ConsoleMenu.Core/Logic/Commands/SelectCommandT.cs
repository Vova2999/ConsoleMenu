using System;
using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic.Commands;

public class SelectCommand<TValue, TSubValue> : ICommand<TValue>
{
	public string Description => _command.Description;
	public bool IsBackAfterExecute => _command.IsBackAfterExecute;

	private readonly ICommand<TSubValue> _command;
	private readonly Func<TValue, Task<TSubValue>> _selector;

	public SelectCommand(ICommand<TSubValue> command, Func<TValue, Task<TSubValue>> selector)
	{
		_command = command;
		_selector = selector;
	}

	public async Task ExecuteAsync(TValue value)
	{
		var subValue = await _selector(value).ConfigureAwait(false);
		await _command.ExecuteAsync(subValue).ConfigureAwait(false);
	}
}