using System;
using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic.Commands;

public class SelectCommand<TSubValue> : ICommand
{
	public string Description => _command.Description;
	public bool IsBackAfterExecute => _command.IsBackAfterExecute;

	private readonly ICommand<TSubValue> _command;
	private readonly Func<Task<TSubValue>> _selector;

	public SelectCommand(ICommand<TSubValue> command, Func<Task<TSubValue>> selector)
	{
		_command = command;
		_selector = selector;
	}

	public async Task ExecuteAsync()
	{
		var subValue = await _selector().ConfigureAwait(false);
		await _command.ExecuteAsync(subValue).ConfigureAwait(false);
	}
}