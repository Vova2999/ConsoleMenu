using System;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands;

public class MulIntCommand : ICommand<ValueWrapper<int>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public MulIntCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public void Execute(ValueWrapper<int> wrapper)
	{
		Console.Write("Введите число для умножения");
		var value = ConsoleReadHelper.ReadInt(" => ");

		wrapper.Value *= value;
	}
}