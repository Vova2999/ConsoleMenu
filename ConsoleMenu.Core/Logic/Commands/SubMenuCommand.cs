using ConsoleMenu.Core.Logic.Menus;

namespace ConsoleMenu.Core.Logic.Commands {
	public class SubMenuCommand<TValue> : ICommand<TValue> {
		public string Description => subMenu.MenuDescription;

		private readonly SubMenu<TValue> subMenu;

		public SubMenuCommand(SubMenu<TValue> subMenu) {
			this.subMenu = subMenu;
		}

		public void Execute(ValueWrapper<TValue> wrapper) {
			subMenu.Start();
		}
	}
}