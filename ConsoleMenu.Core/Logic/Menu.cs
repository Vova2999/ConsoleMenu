using System;
using System.Linq;
using ConsoleMenu.Core.Extensions;
using ConsoleMenu.Core.Helpers;

namespace ConsoleMenu.Core.Logic {
	public abstract class Menu<TValue> {
		protected abstract string BackCommandDescription { get; }

		private readonly ICommand<TValue>[] commands;
		private readonly ValueWrapper<TValue> wrapper;

		protected Menu(params ICommand<TValue>[] commands) : this(default(TValue), commands) {
		}
		protected Menu(TValue value, params ICommand<TValue>[] commands) : this(new ValueWrapper<TValue> { Value = value }, commands) {
		}
		protected Menu(ValueWrapper<TValue> wrapper, params ICommand<TValue>[] commands) {
			this.commands = commands;
			this.wrapper = wrapper;
		}

		public void Start() {
			while (true) {
				Console.Clear();
				PrintCommands();

				var selector = ConsoleReadHelper.ReadInt(" => ", 0, commands.Length);
				if (selector == 0)
					break;

				ExecuteCommand(selector - 1);
			}
		}

		protected virtual void PrintCommands() {
			commands
				.Select((command, i) => $"{i + 1}: {command.Description}")
				.Concat($"0: {BackCommandDescription}".AsEnumerable())
				.ForEach(Console.WriteLine);
		}

		private void ExecuteCommand(int selector) {
			commands[selector].Execute(wrapper);
		}
	}
}