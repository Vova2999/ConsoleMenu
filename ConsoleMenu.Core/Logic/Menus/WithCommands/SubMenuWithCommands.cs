using System;

namespace ConsoleMenu.Core.Logic.Menus.WithCommands {
	public class SubMenuWithCommands<TValue> : MenuWithCommands<TValue>, ISubMenu<TValue> {
		protected override string BackCommandDescription => "Назад";

		public string Description { get; }
		public Func<TValue, string> GetDescription { get; }

		public SubMenuWithCommands(string description, params ICommand<TValue>[] commands) : base(commands) {
			Description = description;
		}

		public SubMenuWithCommands(Func<TValue, string> getDescription, params ICommand<TValue>[] commands) : base(commands) {
			GetDescription = getDescription;
		}

		public SubMenuWithCommands(string description, Func<TValue, string> getDescription, params ICommand<TValue>[] commands) : base(commands) {
			Description = description;
			GetDescription = getDescription;
		}

		protected override void PrintCommands(TValue value) {
			Console.WriteLine($"<{GetDescription?.Invoke(value) ?? Description}>");
			base.PrintCommands(value);
		}
	}
}