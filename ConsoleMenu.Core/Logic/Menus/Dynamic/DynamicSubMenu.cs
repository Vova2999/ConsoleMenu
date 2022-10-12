using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Logic.Menus.Dynamic {
	public class DynamicSubMenu<TValue> : DynamicMenu<TValue>, ISubMenu {
		protected override string BackCommandDescription => "Назад";

		public string Description { get; }

		public DynamicSubMenu(string description,
							  IList<TValue> values,
							  ICommand<TValue> command,
							  Func<TValue, string> getValueDescription) : this(description, default(TValue), values, command, getValueDescription) {
		}
		public DynamicSubMenu(string description,
							  TValue value,
							  IList<TValue> values,
							  ICommand<TValue> command,
							  Func<TValue, string> getValueDescription) : this(description, new ValueWrapper<TValue> { Value = value }, values, command, getValueDescription) {
		}
		public DynamicSubMenu(string description,
							  ValueWrapper<TValue> wrapper,
							  IList<TValue> values,
							  ICommand<TValue> command,
							  Func<TValue, string> getValueDescription) : base(wrapper, values, command, getValueDescription) {
			Description = description;
		}

		protected override void PrintCommands() {
			Console.WriteLine($"<{Description}>");
			base.PrintCommands();
		}
	}
}