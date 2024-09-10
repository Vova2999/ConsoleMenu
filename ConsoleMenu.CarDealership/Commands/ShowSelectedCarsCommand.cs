using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

	public Task ExecuteAsync(IEnumerable<Car> value)
	{
		value
			.Select(car => $"Id: {car.Id}, ���: {car.Name}, ��� �������: {car.MakeYear}, �������� ���������: {car.EngineCapacity}, ���������: {car.Cost}")
			.ForEach(Console.WriteLine);

		PrintHelper.ReadKeyForContinue();

		return Task.CompletedTask;
	}
}