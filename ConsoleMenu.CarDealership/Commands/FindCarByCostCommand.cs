using System;
using System.Linq;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.CarDealership.Services;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class FindCarByCostCommand : ICommand
{
	private readonly ICarFinder _carFinder;

	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public FindCarByCostCommand(string description, ICarFinder carFinder, bool isBackAfterExecute = false)
	{
		Description = description;
		_carFinder = carFinder;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public void Execute()
	{
		Console.WriteLine("Введите стоимость: ");
		var cost = double.Parse(Console.ReadLine()!);

		Console.WriteLine();
		Console.WriteLine("Найденные машины:");
		_carFinder.FindByCost(cost).Select(car => $"Id: {car.Id}, Имя: {car.Name}").ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
	}
}