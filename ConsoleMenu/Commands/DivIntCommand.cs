using System;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands;

public class DivIntCommand : ICommand<ValueWrapper<int>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public DivIntCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public void Execute(ValueWrapper<int> wrapper)
	{
		Console.Write("Введите число для деления");
		var value = ConsoleReadHelper.ReadInt(" => ");

		wrapper.Value /= value;
	}
}