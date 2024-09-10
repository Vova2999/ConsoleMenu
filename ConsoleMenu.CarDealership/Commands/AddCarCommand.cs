using System;
using System.Threading.Tasks;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class AddCarCommand : ICommand
{
	private readonly ICarDb _carDb;

	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public AddCarCommand(string description, ICarDb carDb, bool isBackAfterExecute = false)
	{
		Description = description;
		_carDb = carDb;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public Task ExecuteAsync()
	{
		Console.Write("Введите имя: ");
		var name = Console.ReadLine();

		Console.Write("Введите год выпуска: ");
		var makeYear = int.Parse(Console.ReadLine()!);

		Console.Write("Введите мощность двигателя: ");
		var engineCapacity = double.Parse(Console.ReadLine()!);

		Console.Write("Введите стоимость: ");
		var cost = double.Parse(Console.ReadLine()!);

		_carDb.Add(new Car
		{
			Name = name,
			MakeYear = makeYear,
			EngineCapacity = engineCapacity,
			Cost = cost
		});

		return Task.CompletedTask;
	}
}