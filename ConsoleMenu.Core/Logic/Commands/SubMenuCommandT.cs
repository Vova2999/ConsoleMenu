using System;
using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic.Commands {
	public class SubMenuCommand<TValue, TSubValue> : ICommand<TValue> {
		public string Description => _subMenu.Description;

		private readonly ISubMenu<TSubValue> _subMenu;
		private readonly Func<TValue, TSubValue> _selector;

		public SubMenuCommand(ISubMenu<TSubValue> subMenu, Func<TValue, TSubValue> selector) {
			_subMenu = subMenu;
			_selector = selector;
		}

		public Task ExecuteAsync(TValue value) {
			return _subMenu.StartAsync(_selector(value));
		}
	}
}