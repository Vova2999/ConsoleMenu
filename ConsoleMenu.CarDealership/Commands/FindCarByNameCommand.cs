using System;
using System.Linq;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.CarDealership.Services;
using ConsoleMenu.Core.Logic;

public class FindCarByNameCommand : ICommand
{
	private readonly ICarFinder _carFinder;

	public string Description { get; }

	public FindCarByNameCommand(string description, ICarFinder carFinder)
	{
		Description = description;
		_carFinder = carFinder;
	}

	public void Execute()
	{
		Console.WriteLine("Введите имя: ");
		var name = Console.ReadLine();

		Console.WriteLine();
		Console.WriteLine("Найденные машины:");
		_carFinder.FindByName(name).Select(car => $"Id: {car.Id}, Имя: {car.Name}").ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
    }
};