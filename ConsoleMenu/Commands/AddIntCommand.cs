using System;
using System.Threading.Tasks;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands;

public class AddIntCommand : ICommand<ValueWrapper<int>>
{
	public string Description { get; }

	public AddIntCommand(string description)
	{
		Description = description;
	}

	public Task ExecuteAsync(ValueWrapper<int> wrapper)
	{
		Console.Write("Введите число для сложения");
		var value = ConsoleReadHelper.ReadInt(" => ", int.MinValue, int.MaxValue);

		wrapper.Value += value;

		return Task.CompletedTask;
	}
}