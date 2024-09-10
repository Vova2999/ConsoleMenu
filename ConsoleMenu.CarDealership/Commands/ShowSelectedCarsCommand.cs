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

	public ShowSelectedCarsCommand(string description)
	{
		Description = description;
	}

	public void Execute(IEnumerable<Car> value)
	{
		value
            .Select(car => $"Id: {car.Id}, ���: {car.Name}, ��� �������: {car.MakeYear}, �������� ���������: {car.EngineCapacity}, ���������: {car.Cost}")
			.ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();
	}
}