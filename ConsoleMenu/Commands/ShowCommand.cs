using System;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands {
	public class ShowCommand<TValue> : ICommand<TValue> {
		public string Description => "Показать";

		public void Execute(ValueWrapper<TValue> wrapper) {
			Console.WriteLine(wrapper.Value);
			Console.ReadKey();
		}
	}
}