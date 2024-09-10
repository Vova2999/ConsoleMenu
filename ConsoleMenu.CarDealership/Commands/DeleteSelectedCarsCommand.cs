using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.CarDealership.Extensions;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class DeleteSelectedCarsCommand : ICommand<IEnumerable<Car>>
{
	private readonly ICarDb _carDb;

	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public DeleteSelectedCarsCommand(string description, ICarDb carDb, bool isBackAfterExecute = false)
	{
		_carDb = carDb;
		IsBackAfterExecute = isBackAfterExecute;
		Description = description;
	}

	public void Execute(IEnumerable<Car> value)
	{
		value.ToArray().ForEach(_carDb.Delete);
	}
}