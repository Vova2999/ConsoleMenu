using System;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class ShowCarsCommand : ICommand
{
	private readonly ICarDb _carDb;

	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public ShowCarsCommand(string description, ICarDb carDb, bool isBackAfterExecute = false)
	{
		Description = description;
		_carDb = carDb;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public async Task ExecuteAsync()
	{
		(await _carDb.GetAllAsync().ConfigureAwait(false))
			.Select(car => $"Id: {car.Id}, Имя: {car.Name}, Год выпуска: {car.MakeYear}, Мощность двигателя: {car.EngineCapacity}, Стоимость: {car.Cost}")
			.ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
	}
}