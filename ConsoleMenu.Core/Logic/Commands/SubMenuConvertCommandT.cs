using System;

namespace ConsoleMenu.Core.Logic.Commands;

public class SubMenuConvertCommand<TValue, TSubValue> : ICommand<TValue>
{
	public string Description => _subMenu.Description;
	public bool IsBackAfterExecute { get; }

	private readonly ISubMenu<TSubValue> _subMenu;
	private readonly Func<TValue, TSubValue> _selector;

	public SubMenuConvertCommand(ISubMenu<TSubValue> subMenu, Func<TValue, TSubValue> selector)
	{
		_subMenu = subMenu;
		_selector = selector;
	}

	public SubMenuConvertCommand(bool isBackAfterExecute, ISubMenu<TSubValue> subMenu, Func<TValue, TSubValue> selector)
	{
		IsBackAfterExecute = isBackAfterExecute;
		_subMenu = subMenu;
		_selector = selector;
	}

	public void Execute(TValue value)
	{
		_subMenu.Start(_selector(value));
	}
}