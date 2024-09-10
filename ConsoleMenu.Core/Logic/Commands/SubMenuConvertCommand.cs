using System;

namespace ConsoleMenu.Core.Logic.Commands;

public class SubMenuConvertCommand<TSubValue> : ICommand
{
	public string Description => _subMenu.Description;

	private readonly ISubMenu<TSubValue> _subMenu;
	private readonly Func<TSubValue> _selector;

	public SubMenuConvertCommand(ISubMenu<TSubValue> subMenu, Func<TSubValue> selector)
	{
		_subMenu = subMenu;
		_selector = selector;
	}

	public void Execute()
	{
		_subMenu.Start(_selector());
	}
}