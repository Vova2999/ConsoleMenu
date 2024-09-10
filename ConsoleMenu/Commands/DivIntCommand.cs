using System;
using System.Threading.Tasks;
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

	public Task ExecuteAsync(ValueWrapper<int> wrapper)
	{
		Console.Write("Введите число для деления");
		var value = ConsoleReadHelper.ReadInt(" => ");

		wrapper.Value /= value;

		return Task.CompletedTask;
	}
}