using System;
using System.Linq;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.CarDealership.Services;
using ConsoleMenu.Core.Logic;

public class FindCarByEngineCapacityCommand : ICommand
{
	private readonly ICarFinder _carFinder;

	public string Description => "Поиск по мощности двигателя";

	public FindCarByEngineCapacityCommand(ICarFinder carFinder)
	{
		_carFinder = carFinder;
	}

	public void Execute()
	{
		Console.WriteLine("Введите мощность двигателя: ");
		var engineCapacity = double.Parse(Console.ReadLine()!);

		Console.WriteLine();
		Console.WriteLine("Найденные машины:");
		_carFinder.FindByEngineCapacity(engineCapacity).Select(car => $"Id: {car.Id}, Имя: {car.Name}").ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
    }
};