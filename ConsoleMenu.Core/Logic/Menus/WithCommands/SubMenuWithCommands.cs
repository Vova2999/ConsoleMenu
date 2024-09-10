using System;

namespace ConsoleMenu.Core.Logic.Menus.WithCommands;

public class SubMenuWithCommands : MenuWithCommands, ISubMenu
{
	protected override string BackCommandDescription => "Назад";

	public string Description { get; }
	public Func<string> GetDescription { get; }

	public SubMenuWithCommands(string description, params ICommand[] commands) : base(commands)
	{
		Description = description;
	}

	public SubMenuWithCommands(string description, bool isBackAfterExecute, params ICommand[] commands) : base(isBackAfterExecute, commands)
	{
		Description = description;
	}

	public SubMenuWithCommands(Func<string> getDescription, params ICommand[] commands) : base(commands)
	{
		GetDescription = getDescription;
	}

	public SubMenuWithCommands(Func<string> getDescription, bool isBackAfterExecute, params ICommand[] commands) : base(isBackAfterExecute, commands)
	{
		GetDescription = getDescription;
	}

	public SubMenuWithCommands(string description, Func<string> getDescription, params ICommand[] commands) : base(commands)
	{
		Description = description;
		GetDescription = getDescription;
	}

	public SubMenuWithCommands(string description, Func<string> getDescription, bool isBackAfterExecute, params ICommand[] commands) : base(isBackAfterExecute, commands)
	{
		Description = description;
		GetDescription = getDescription;
	}

	protected override void PrintCommands()
	{
		Console.WriteLine($"<{GetDescription?.Invoke() ?? Description}>");
		base.PrintCommands();
	}
}