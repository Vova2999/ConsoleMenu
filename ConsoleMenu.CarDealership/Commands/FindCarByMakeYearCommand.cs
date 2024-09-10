using System;
using System.Linq;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.CarDealership.Services;
using ConsoleMenu.Core.Logic;

public class FindCarByMakeYearCommand : ICommand
{
	private readonly ICarFinder _carFinder;

	public string Description => "Поиск по году выпуска";

	public FindCarByMakeYearCommand(ICarFinder carFinder)
	{
		_carFinder = carFinder;
	}

	public void Execute()
	{
		Console.WriteLine("Введите год выпуска: ");
		var makeYear = int.Parse(Console.ReadLine()!);

		Console.WriteLine();
		Console.WriteLine("Найденные машины:");
		_carFinder.FindByMakeYear(makeYear).Select(car => $"Id: {car.Id}, Имя: {car.Name}").ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
    }
};