using System;
using System.Collections.Generic;
using System.Linq;
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

	public IEnumerable<Car> FindByName(string name)
	{
		return carDb.Cars.Where(car => string.Equals(car.Name, name, StringComparison.OrdinalIgnoreCase));
	}

	public IEnumerable<Car> FindByMakeYear(int makeYear)
	{
		return carDb.Cars.Where(car => car.MakeYear == makeYear);
    }

	public IEnumerable<Car> FindByEngineCapacity(double engineCapacity)
	{
		return carDb.Cars.Where(car => car.EngineCapacity == engineCapacity);
	}

	public IEnumerable<Car> FindByCost(double cost)
	{
		return carDb.Cars.Where(car => car.Cost == cost);
	}
}