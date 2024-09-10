using System;
using System.Linq;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.Core.Logic;

public class ShowCarsCommand : ICommand
{
	private readonly ICarDb _carDb;

	public string Description => "Показать все машины";

	public ShowCarsCommand(ICarDb carDb)
	{
		_carDb = carDb;
	}

	public void Execute()
	{
		_carDb.Cars
			.Select(car => $"Id: {car.Id}, Имя: {car.Name}, Год выпуска: {car.MakeYear}, Мощность двигателя: {car.EngineCapacity}, Стоимость: {car.Cost}")
			.ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
    }
};