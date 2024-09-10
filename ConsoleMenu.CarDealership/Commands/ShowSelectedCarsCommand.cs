using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class ShowSelectedCarsCommand : ICommand<IEnumerable<Car>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public ShowSelectedCarsCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public void Execute(IEnumerable<Car> value)
	{
		value
			.Select(car => $"Id: {car.Id}, Имя: {car.Name}, Год выпуска: {car.MakeYear}, Мощность двигателя: {car.EngineCapacity}, Стоимость: {car.Cost}")
			.ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
	}
}