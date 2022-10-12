using System;

namespace ConsoleMenu.Core.Logic.Menus.WithCommands {
	public class SubMenuWithCommands<TValue> : MenuWithCommands<TValue>, ISubMenu<TValue> {
		protected override string BackCommandDescription => "Назад";

		public string Description { get; }

		public SubMenuWithCommands(string description, params ICommand<TValue>[] commands) : base(commands) {
			Description = description;
		}

		protected override void PrintCommands(TValue value) {
			Console.WriteLine($"<{Description}>");
			base.PrintCommands(value);
		}
	}
}