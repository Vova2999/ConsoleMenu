using System;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.CarDealership.Services;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class FindCarByNameCommand : ICommand
{
	private readonly ICarFinder _carFinder;

	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public FindCarByNameCommand(string description, ICarFinder carFinder, bool isBackAfterExecute = false)
	{
		Description = description;
		_carFinder = carFinder;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public async Task ExecuteAsync()
	{
		Console.WriteLine("Введите имя: ");
		var name = Console.ReadLine();

		Console.WriteLine();
		Console.WriteLine("Найденные машины:");
		var cars = await _carFinder.FindByNameAsync(name).ConfigureAwait(false);
		cars.Select(car => $"Id: {car.Id}, Имя: {car.Name}").ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
	}
}