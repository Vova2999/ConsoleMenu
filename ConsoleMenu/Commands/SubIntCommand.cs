using System;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands;

public class SubIntCommand : ICommand<ValueWrapper<int>>
{
	public string Description { get; }

	public SubIntCommand(string description)
	{
		Description = description;
	}

	public void Execute(ValueWrapper<int> wrapper)
	{
		Console.Write("Введите число для вычитания");
		var value = ConsoleReadHelper.ReadInt(" => ", int.MinValue, int.MaxValue);

		wrapper.Value -= value;
	}
}