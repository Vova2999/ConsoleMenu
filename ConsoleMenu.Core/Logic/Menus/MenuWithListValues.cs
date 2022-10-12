using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus {
	public abstract class MenuWithListValues<TValue> : MenuBase<IList<TValue>> {
		private readonly ICommand<TValue> command;
		private readonly Func<TValue, string> getValueDescription;

		protected MenuWithListValues(ICommand<TValue> command, Func<TValue, string> getValueDescription) {
			this.command = command;
			this.getValueDescription = getValueDescription;
		}

		protected override IEnumerable<string> GetCommandDescriptions(IList<TValue> values) {
			return values.Select(getValueDescription);
		}

		protected override int ReadSelector(IList<TValue> values) {
			return ConsoleReadHelper.ReadInt(" => ", 0, values.Count);
		}

		protected override void ExecuteCommand(IList<TValue> values, int index) {
			command.Execute(values[index]);
		}
	}
}