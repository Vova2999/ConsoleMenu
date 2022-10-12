using System;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands {
	public class AddIntCommand : ICommand<int> {
		public string Description => "Добавить";

		public void Execute(ValueWrapper<int> wrapper) {
			Console.Write("Введите число для сложения");
			var value = ConsoleReadHelper.ReadInt(" => ", int.MinValue, int.MaxValue);

			wrapper.Value += value;
		}
	}
}