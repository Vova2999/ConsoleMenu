using System;
using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic.Commands;

public class SubMenuConvertCommand<TValue, TSubValue> : ICommand<TValue>
{
	public string Description => _subMenu.Description;
	public bool IsBackAfterExecute { get; }

	private readonly ISubMenu<TSubValue> _subMenu;
	private readonly Func<TValue, Task<TSubValue>> _selector;

	public SubMenuConvertCommand(ISubMenu<TSubValue> subMenu, Func<TValue, Task<TSubValue>> selector)
	{
		_subMenu = subMenu;
		_selector = selector;
	}

	public SubMenuConvertCommand(bool isBackAfterExecute, ISubMenu<TSubValue> subMenu, Func<TValue, Task<TSubValue>> selector)
	{
		IsBackAfterExecute = isBackAfterExecute;
		_subMenu = subMenu;
		_selector = selector;
	}

	public async Task ExecuteAsync(TValue value)
	{
		var subValue = await _selector(value).ConfigureAwait(false);
		await _subMenu.StartAsync(subValue).ConfigureAwait(false);
	}
}