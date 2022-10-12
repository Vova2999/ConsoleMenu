using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Logic.Menus.WithListValues {
	public class SubMenuWithListValues<TValue> : MenuWithListValues<TValue>, ISubMenu<IList<TValue>> {
		protected override string BackCommandDescription => "Назад";

		public string Description { get; }

		public SubMenuWithListValues(string description, ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(command, getValueDescription) {
			Description = description;
		}

		protected override void PrintCommands(IList<TValue> values) {
			Console.WriteLine($"<{Description}>");
			base.PrintCommands(values);
		}
	}
}