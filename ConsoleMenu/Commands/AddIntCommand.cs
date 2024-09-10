using System;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands;

public class AddIntCommand : ICommand<ValueWrapper<int>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public AddIntCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public void Execute(ValueWrapper<int> wrapper)
	{
		Console.Write("Введите число для сложения");
		var value = ConsoleReadHelper.ReadInt(" => ");

		wrapper.Value += value;
	}
}