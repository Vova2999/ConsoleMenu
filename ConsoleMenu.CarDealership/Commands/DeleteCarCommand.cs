using System;
using System.Linq;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

public class DeleteCarCommand : ICommand
{
	private readonly ICarDb _carDb;

	public string Description => "Удалить существующую машину";

	public DeleteCarCommand(ICarDb carDb)
	{
		_carDb = carDb;
	}

	public void Execute()
	{
		_carDb.Cars.Select((car, i) => $"{i}: {car.Name}").ForEach(Console.WriteLine);
		Console.WriteLine("0: Назад");

		var selector = ConsoleReadHelper.ReadInt(" => ", 0, _carDb.Cars.Count);
		if (selector == 0)
			return;

		_carDb.Delete(_carDb.Cars[selector - 1]);
	}
};