namespace ConsoleMenu.Core.Logic.Menus.WithCommands;

public class MainMenuWithCommands<TValue> : MenuWithCommands<TValue>, IMenu<TValue>
{
	protected override string BackCommandDescription => "Выход";

	public MainMenuWithCommands(params ICommand<TValue>[] commands) : base(commands)
	{
	}

	public MainMenuWithCommands(bool isBackAfterExecute, params ICommand<TValue>[] commands) : base(isBackAfterExecute, commands)
	{
	}
}