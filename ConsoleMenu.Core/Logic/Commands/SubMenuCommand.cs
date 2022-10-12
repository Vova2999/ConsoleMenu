namespace ConsoleMenu.Core.Logic.Commands {
	public class SubMenuCommand<TValue> : ICommand<TValue> {
		public string Description => subMenu.Description;

		private readonly ISubMenu<TValue> subMenu;

		public SubMenuCommand(ISubMenu<TValue> subMenu) {
			this.subMenu = subMenu;
		}

		public void Execute(TValue value) {
			subMenu.Start(value);
		}
	}
}