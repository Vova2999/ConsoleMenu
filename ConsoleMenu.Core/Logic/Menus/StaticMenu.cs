using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus {
	public abstract class StaticMenu<TValue> : BaseMenu<TValue> {
		private readonly ICommand<TValue>[] commands;

		protected StaticMenu(ValueWrapper<TValue> wrapper,
							 params ICommand<TValue>[] commands) : base(wrapper) {
			this.commands = commands;
		}

		protected override IEnumerable<string> GetCommandDescriptions() {
			return commands.Select(command => command.Description);
		}

		protected override int ReadSelector() {
			return ConsoleReadHelper.ReadInt(" => ", 0, commands.Length);
		}

		protected override void ExecuteCommand(int index) {
			commands[index].Execute(Wrapper);
		}
	}
}