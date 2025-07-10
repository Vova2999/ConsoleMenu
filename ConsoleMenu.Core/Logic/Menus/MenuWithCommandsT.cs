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

	protected override Task ExecuteCommandAsync(TValue value, int index)
	{
		return _commands[index].ExecuteAsync(value);
	}

	protected override bool IsBackAfterExecuteCommand(int index)
	{
		return _commands[index].IsBackAfterExecute;
	}
}