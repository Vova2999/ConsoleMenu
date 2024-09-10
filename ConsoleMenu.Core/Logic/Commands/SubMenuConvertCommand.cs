using System;
using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic.Commands;

public class SubMenuConvertCommand<TSubValue> : ICommand
{
	public string Description => _subMenu.Description;
	public bool IsBackAfterExecute { get; }

	private readonly ISubMenu<TSubValue> _subMenu;
	private readonly Func<TSubValue> _selector;

	public SubMenuConvertCommand(ISubMenu<TSubValue> subMenu, Func<TSubValue> selector)
	{
		_subMenu = subMenu;
		_selector = selector;
	}

	public SubMenuConvertCommand(bool isBackAfterExecute, ISubMenu<TSubValue> subMenu, Func<TSubValue> selector)
	{
		IsBackAfterExecute = isBackAfterExecute;
		_subMenu = subMenu;
		_selector = selector;
	}

	public Task ExecuteAsync()
	{
		return _subMenu.StartAsync(_selector());
	}
}