using System;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands {
	public class SubIntCommand : ICommand<int> {
		public string Description => "Вычесть";

		public void Execute(ValueWrapper<int> wrapper) {
			Console.Write("Введите число для вычитания");
			var value = ConsoleReadHelper.ReadInt(" => ", int.MinValue, int.MaxValue);

			wrapper.Value -= value;
		}
	}
}