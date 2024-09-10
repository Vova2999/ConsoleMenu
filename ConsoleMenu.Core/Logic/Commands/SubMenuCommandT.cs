namespace ConsoleMenu.Core.Logic.Commands;

public class SubMenuCommand<TValue> : ICommand<TValue>
{
	public string Description => _subMenu.Description;
	public bool IsBackAfterExecute { get; }

	private readonly ISubMenu<TValue> _subMenu;

	public SubMenuCommand(ISubMenu<TValue> subMenu)
	{
		_subMenu = subMenu;
	}

	public SubMenuCommand(bool isBackAfterExecute, ISubMenu<TValue> subMenu)
	{
		IsBackAfterExecute = isBackAfterExecute;
		_subMenu = subMenu;
	}

	public void Execute(TValue value)
	{
		_subMenu.Start(value);
	}
}