using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Extensions;

namespace ConsoleMenu.Core.Logic.Menus {
	public abstract class MenuBase<TValue> {
		protected abstract string BackCommandDescription { get; }

		public void Start(TValue value) {
			while (true) {
				Console.Clear();
				PrintCommands(value);

				var selector = ReadSelector(value);
				if (selector == 0)
					break;

				ExecuteCommand(value, selector - 1);
			}
		}

		protected virtual void PrintCommands(TValue value) {
			GetCommandDescriptions(value)
				.Select((description, i) => $"{i + 1}: {description}")
				.Concat($"0: {BackCommandDescription}".AsEnumerable())
				.ForEach(Console.WriteLine);
		}

		protected abstract IEnumerable<string> GetCommandDescriptions(TValue value);

		protected abstract int ReadSelector(TValue value);

		protected abstract void ExecuteCommand(TValue value, int index);
	}
}