using System;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands {
	public class MulIntCommand : ICommand<ValueWrapper<int>> {
		public string Description => "Умножить";

		public void Execute(ValueWrapper<int> wrapper) {
			Console.Write("Введите число для умножения");
			var value = ConsoleReadHelper.ReadInt(" => ", int.MinValue, int.MaxValue);

			wrapper.Value *= value;
		}
	}
}