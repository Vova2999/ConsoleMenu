using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus {
	public abstract class MenuWithCommands<TValue> : MenuBase<TValue> {
		private readonly ICommand<TValue>[] commands;

		protected MenuWithCommands(params ICommand<TValue>[] commands) {
			this.commands = commands;
		}

		protected override IEnumerable<string> GetCommandDescriptions(TValue value) {
			return commands.Select(command => command.Description);
		}

		protected override int ReadSelector(TValue value) {
			return ConsoleReadHelper.ReadInt(" => ", 0, commands.Length);
		}

		protected override void ExecuteCommand(TValue value, int index) {
			commands[index].Execute(value);
		}
	}
}