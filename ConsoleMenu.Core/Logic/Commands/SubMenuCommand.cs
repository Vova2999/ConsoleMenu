namespace ConsoleMenu.Core.Logic.Commands;

public class SubMenuCommand : ICommand
{
	public string Description => _subMenu.Description;

	private readonly ISubMenu _subMenu;

	public SubMenuCommand(ISubMenu subMenu)
	{
		_subMenu = subMenu;
	}

	public void Execute()
	{
		_subMenu.Start();
	}
}