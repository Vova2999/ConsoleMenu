using System;
using System.Threading.Tasks;
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

	public Task ExecuteAsync(ValueWrapper<int> wrapper)
	{
		Console.Write("Введите число для умножения");
		var value = ConsoleReadHelper.ReadInt(" => ");

		wrapper.Value *= value;

		return Task.CompletedTask;
	}
}