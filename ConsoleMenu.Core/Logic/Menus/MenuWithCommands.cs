using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus;

public abstract class MenuWithCommands : MenuBase
{
	private readonly ICommand[] _commands;

	protected MenuWithCommands(params ICommand[] commands)
	{
		_commands = commands;
	}

	protected MenuWithCommands(bool isBackAfterExecute, params ICommand[] commands) : base(isBackAfterExecute)
	{
		_commands = commands;
	}

	protected override IEnumerable<string> GetCommandDescriptions()
	{
		return _commands.Select(command => command.Description);
	}

	protected override int ReadSelector()
	{
		return ConsoleReadHelper.ReadInt(" => ", 0, _commands.Length);
	}

	protected override Task ExecuteCommandAsync(int index)
	{
		return _commands[index].ExecuteAsync();
	}

	protected override bool IsBackAfterExecuteCommand(int index)
	{
		return _commands[index].IsBackAfterExecute;
	}
}