using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class DeleteCarCommand : ICommand<Car>
{
	private readonly ICarDb _carDb;

	public string Description { get; }

	public DeleteCarCommand(string description, ICarDb carDb)
	{
		Description = description;
		_carDb = carDb;
	}

	public void Execute(Car car)
	{
		_carDb.Delete(car);
	}
}