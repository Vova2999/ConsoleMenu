namespace ConsoleMenu.Core.Logic.Commands {
	public class SubMenuCommand<TValue> : ICommand<TValue> {
		public string Description => subMenu.Description;

		private readonly ISubMenu subMenu;

		public SubMenuCommand(ISubMenu subMenu) {
			this.subMenu = subMenu;
		}

		public void Execute(ValueWrapper<TValue> wrapper) {
			subMenu.Start();
		}
	}
}