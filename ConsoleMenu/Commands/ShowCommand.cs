using System;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands;

public class ShowCommand<TValue> : ICommand<ValueWrapper<TValue>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public ShowCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public void Execute(ValueWrapper<TValue> wrapper)
	{
		Console.WriteLine(wrapper.Value);
		Console.ReadKey();
	}
}