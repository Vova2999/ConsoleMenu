using System.Collections.Generic;
using ConsoleMenu.CarDealership.Entities;

namespace ConsoleMenu.CarDealership.Services;

public interface ICarFinder
{
	IEnumerable<Car> FindByName(string name);
	IEnumerable<Car> FindByMakeYear(int makeYear);
	IEnumerable<Car> FindByEngineCapacity(double engineCapacity);
	IEnumerable<Car> FindByCost(double cost);
}