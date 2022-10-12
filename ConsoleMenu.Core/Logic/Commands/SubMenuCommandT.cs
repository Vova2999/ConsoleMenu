using System;

namespace ConsoleMenu.Core.Logic.Commands {
	public class SubMenuCommand<TValue, TSubValue> : ICommand<TValue> {
		public string Description => subMenu.Description;

		private readonly ISubMenu<TSubValue> subMenu;
		private readonly Func<TValue, TSubValue> selector;

		public SubMenuCommand(ISubMenu<TSubValue> subMenu, Func<TValue, TSubValue> selector) {
			this.subMenu = subMenu;
			this.selector = selector;
		}

		public void Execute(TValue value) {
			subMenu.Start(selector(value));
		}
	}
}