using System;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.Core.Logic;

public class AddCarCommand : ICommand
{
	private readonly ICarDb _carDb;

	public string Description => "Добавить новую машину";

	public AddCarCommand(ICarDb carDb)
	{
		_carDb = carDb;
	}

	public void Execute()
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
	}
}