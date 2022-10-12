using ConsoleMenu.Commands;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus.WithCommands;

namespace ConsoleMenu {
	public static class Program {
		public static void Main(string[] args) {
			var wrapper = new ValueWrapper<int>();

			var baseMenu = new SubMenuWithCommands<ValueWrapper<int>>("Базовые операции", new ShowCommand<int>(), new CleanCommand<int>());
			var operationsMenu = new SubMenuWithCommands<ValueWrapper<int>>("Математические операции", new AddIntCommand(), new SubIntCommand(), new MulIntCommand(), new DivIntCommand());
			var mainMenu = new MainMenuWithCommands<ValueWrapper<int>>(new ShowCommand<int>(), new SubMenuCommand<ValueWrapper<int>>(baseMenu), new SubMenuCommand<ValueWrapper<int>>(operationsMenu));

			mainMenu.Start(wrapper);
		}
	}
}