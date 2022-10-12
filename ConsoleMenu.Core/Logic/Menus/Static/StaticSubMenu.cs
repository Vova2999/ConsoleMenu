using System;

namespace ConsoleMenu.Core.Logic.Menus.Static {
	public class StaticSubMenu<TValue> : StaticMenu<TValue>, ISubMenu {
		protected override string BackCommandDescription => "Назад";

		public string Description { get; }

		public StaticSubMenu(string description,
							 params ICommand<TValue>[] commands) : this(description, default(TValue), commands) {
		}
		public StaticSubMenu(string description,
							 TValue value,
							 params ICommand<TValue>[] commands) : this(description, new ValueWrapper<TValue> { Value = value }, commands) {
		}
		public StaticSubMenu(string description,
							 ValueWrapper<TValue> wrapper,
							 params ICommand<TValue>[] commands) : base(wrapper, commands) {
			Description = description;
		}

		protected override void PrintCommands() {
			Console.WriteLine($"<{Description}>");
			base.PrintCommands();
		}
	}
}