using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleMenu.CarDealership.Entities;

namespace ConsoleMenu.CarDealership.Services;

public interface ICarFinder
{
	Task<IEnumerable<Car>> FindByNameAsync(string name);
	Task<IEnumerable<Car>> FindByMakeYearAsync(int makeYear);
	Task<IEnumerable<Car>> FindByEngineCapacityAsync(double engineCapacity);
	Task<IEnumerable<Car>> FindByCostAsync(double cost);
}