using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleMenu.CarDealership.Entities;

namespace ConsoleMenu.CarDealership.DataBase;

public class CarDb : ICarDb
{
	private readonly List<Car> _cars = new();

	public Task<IReadOnlyList<Car>> GetAllAsync()
	{
		return Task.FromResult((IReadOnlyList<Car>) _cars.AsReadOnly());
	}

	public Task AddAsync(Car car)
	{
		_cars.Add(car);
		return Task.CompletedTask;
	}

	public Task DeleteAsync(Car car)
	{
		_cars.Remove(car);
		return Task.CompletedTask;
	}

	public Task ClearAsync()
	{
		_cars.Clear();
		return Task.CompletedTask;
	}
}