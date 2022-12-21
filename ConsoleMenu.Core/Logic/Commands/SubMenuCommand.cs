namespace ConsoleMenu.Core.Logic.Commands {
	public class SubMenuCommand<TValue> : ICommand<TValue> {
		public string Description => _subMenu.Description;

		private readonly ISubMenu<TValue> _subMenu;

		public SubMenuCommand(ISubMenu<TValue> subMenu) {
			_subMenu = subMenu;
		}

		public void Execute(TValue value) {
			_subMenu.Start(value);
		}
	}
}