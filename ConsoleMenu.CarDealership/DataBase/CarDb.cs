using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.CarDealership.Entities;

namespace ConsoleMenu.CarDealership.DataBase;

public class CarDb : ICarDb
{
	private readonly List<Car> _cars = new();

	public IReadOnlyList<Car> Cars => _cars.AsReadOnly();

	public void Add(Car car)
	{
		car.Id = _cars.Any() ? _cars.Max(c => c.Id) + 1 : 1;

		_cars.Add(car);
	}

	public void Delete(Car car)
	{
		_cars.Remove(car);
	}

	public void Clear()
	{
		_cars.Clear();
	}
}