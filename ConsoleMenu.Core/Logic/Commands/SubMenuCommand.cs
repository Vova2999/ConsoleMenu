namespace ConsoleMenu.Core.Logic.Commands;

public class SubMenuCommand : ICommand
{
	public string Description => _subMenu.Description;
	public bool IsBackAfterExecute { get; }

	private readonly ISubMenu _subMenu;

	public SubMenuCommand(ISubMenu subMenu)
	{
		_subMenu = subMenu;
	}

	public SubMenuCommand(bool isBackAfterExecute, ISubMenu subMenu)
	{
		IsBackAfterExecute = isBackAfterExecute;
		_subMenu = subMenu;
	}

	public Task ExecuteAsync()
	{
		return _subMenu.StartAsync();
	}
}