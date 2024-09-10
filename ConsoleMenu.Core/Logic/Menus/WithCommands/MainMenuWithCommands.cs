namespace ConsoleMenu.Core.Logic.Menus.WithCommands;

public class MainMenuWithCommands : MenuWithCommands, IMenu
{
	protected override string BackCommandDescription => "Выход";

	public MainMenuWithCommands(params ICommand[] commands) : base(commands)
	{
	}
}