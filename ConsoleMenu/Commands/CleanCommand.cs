using System.Threading.Tasks;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands;

public class CleanCommand<TValue> : ICommand<ValueWrapper<TValue>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	private readonly TValue _cleanValue;

	public CleanCommand(string description, TValue cleanValue = default)
	{
		Description = description;
		_cleanValue = cleanValue;
	}

	public CleanCommand(string description, bool isBackAfterExecute, TValue cleanValue = default)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
		_cleanValue = cleanValue;
	}

	public Task ExecuteAsync(ValueWrapper<TValue> wrapper)
	{
		wrapper.Value = _cleanValue;

		return Task.CompletedTask;
	}
}