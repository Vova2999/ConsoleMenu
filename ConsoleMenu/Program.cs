using ConsoleMenu.Commands;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus.Static;

namespace ConsoleMenu {
	public static class Program {
		public static void Main(string[] args) {
			var wrapper = new ValueWrapper<int>();

			var baseMenu = new StaticSubMenu<int>("Базовые операции", wrapper, new ShowCommand<int>(), new CleanCommand<int>());
			var operationsMenu = new StaticSubMenu<int>("Математические операции", wrapper, new AddIntCommand(), new SubIntCommand(), new MulIntCommand(), new DivIntCommand());
			var mainMenu = new StaticMainMenu<int>(wrapper, new ShowCommand<int>(), new SubMenuCommand<int>(baseMenu), new SubMenuCommand<int>(operationsMenu));

			mainMenu.Start();
		}
	}
}