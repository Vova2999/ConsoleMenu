using System;
using System.Linq;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class ShowCarsCommand : ICommand
{
	private readonly ICarDb _carDb;

	public string Description { get; }

	public ShowCarsCommand(string description, ICarDb carDb)
	{
		Description = description;
		_carDb = carDb;
	}

	public void Execute()
	{
		_carDb.Cars
			.Select(car => $"Id: {car.Id}, ���: {car.Name}, ��� �������: {car.MakeYear}, �������� ���������: {car.EngineCapacity}, ���������: {car.Cost}")
			.ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
	}
}