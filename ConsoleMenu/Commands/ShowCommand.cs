using System;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands;

public class ShowCommand<TValue> : ICommand<ValueWrapper<TValue>>
{
	public string Description { get; }

	public ShowCommand(string description)
	{
		Description = description;
	}

	public void Execute(ValueWrapper<TValue> wrapper)
	{
		Console.WriteLine(wrapper.Value);
		Console.ReadKey();
	}
}