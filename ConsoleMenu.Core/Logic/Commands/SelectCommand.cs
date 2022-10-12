using System;

namespace ConsoleMenu.Core.Logic.Commands {
	public class SelectCommand<TValue, TSubValue> : ICommand<TValue> {
		public string Description { get; }

		private readonly ICommand<TSubValue> command;
		private readonly Func<TValue, TSubValue> selector;

		public SelectCommand(string description, ICommand<TSubValue> command, Func<TValue, TSubValue> selector) {
			Description = description;
			this.command = command;
			this.selector = selector;
		}

		public void Execute(TValue value) {
			command.Execute(selector(value));
		}
	}
}