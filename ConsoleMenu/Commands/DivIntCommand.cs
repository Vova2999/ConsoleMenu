﻿using System;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands {
	public class DivIntCommand : ICommand<ValueWrapper<int>> {
		public string Description => "Разделить";

		public void Execute(ValueWrapper<int> wrapper) {
			Console.Write("Введите число для деления");
			var value = ConsoleReadHelper.ReadInt(" => ", int.MinValue, int.MaxValue);

			wrapper.Value /= value;
		}
	}
}