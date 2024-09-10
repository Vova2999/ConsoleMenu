using ConsoleMenu.Commands;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus.WithCommands;

namespace ConsoleMenu;

public static class Program
{
	public static void Main(string[] args)
	{
		var wrapper = new ValueWrapper<int>();

		var mainMenu = new MainMenuWithCommands<ValueWrapper<int>>(
			new ShowCommand<int>("Показать"),
			new SubMenuCommand<ValueWrapper<int>>(new SubMenuWithCommands<ValueWrapper<int>>("Базовые операции",
				new ShowCommand<int>("Показать"),
				new CleanCommand<int>("Очистить"))),
			new SubMenuCommand<ValueWrapper<int>>(new SubMenuWithCommands<ValueWrapper<int>>("Математические операции",
				new AddIntCommand("Добавить"),
				new SubIntCommand("Вычесть"),
				new MulIntCommand("Умножить"),
				new DivIntCommand("Разделить"))));

		mainMenu.Start(wrapper);
	}
}