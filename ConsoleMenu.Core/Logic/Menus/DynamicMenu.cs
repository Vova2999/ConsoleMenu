using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic.Menus {
	public abstract class DynamicMenu<TValue> : BaseMenu<TValue> {
		private readonly IList<TValue> values;
		private readonly ICommand<TValue> command;
		private readonly Func<TValue, string> getValueDescription;

		protected DynamicMenu(ValueWrapper<TValue> wrapper,
							  IList<TValue> values,
							  ICommand<TValue> command,
							  Func<TValue, string> getValueDescription) : base(wrapper) {
			this.values = values;
			this.command = command;
			this.getValueDescription = getValueDescription;
		}

		protected override IEnumerable<string> GetCommandDescriptions() {
			return values.Select(getValueDescription);
		}

		protected override int ReadSelector() {
			return ConsoleReadHelper.ReadInt(" => ", 0, values.Count);
		}

		protected override void ExecuteCommand(int index) {
			command.Execute(new ValueWrapper<TValue> { Value = values[index] });
		}
	}
}