using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;

namespace ConsoleMenu.CarDealership.Services;

public class CarFinder : ICarFinder
{
	private readonly ICarDb carDb;

	public CarFinder(ICarDb carDb)
	{
		this.carDb = carDb;
	}

	public async Task<IEnumerable<Car>> FindByNameAsync(string name)
	{
		var cars = await carDb.GetAllAsync().ConfigureAwait(false);
		return cars.Where(car => string.Equals(car.Name, name, StringComparison.OrdinalIgnoreCase));
	}

	public async Task<IEnumerable<Car>> FindByMakeYearAsync(int makeYear)
	{
		var cars = await carDb.GetAllAsync().ConfigureAwait(false);
		return cars.Where(car => car.MakeYear == makeYear);
	}

	public async Task<IEnumerable<Car>> FindByEngineCapacityAsync(double engineCapacity)
	{
		var cars = await carDb.GetAllAsync().ConfigureAwait(false);
		return cars.Where(car => car.EngineCapacity == engineCapacity);
	}

	public async Task<IEnumerable<Car>> FindByCostAsync(double cost)
	{
		var cars = await carDb.GetAllAsync().ConfigureAwait(false);
		return cars.Where(car => car.Cost == cost);
	}
}