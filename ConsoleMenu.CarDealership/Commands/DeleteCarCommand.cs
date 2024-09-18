using System.Threading.Tasks;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.CarDealership.Commands;

public class DeleteCarCommand : ICommand<Car>
{
	private readonly ICarDb _carDb;

	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public DeleteCarCommand(string description, ICarDb carDb, bool isBackAfterExecute = false)
	{
		Description = description;
		_carDb = carDb;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public Task ExecuteAsync(Car car)
	{
		_carDb.DeleteAsync(car);

		return Task.CompletedTask;
	}
}