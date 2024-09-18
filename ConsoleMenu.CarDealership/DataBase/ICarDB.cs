using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleMenu.CarDealership.Entities;

namespace ConsoleMenu.CarDealership.DataBase;

public interface ICarDb
{
	Task<IReadOnlyList<Car>> GetAllAsync();

	Task AddAsync(Car car);
	Task DeleteAsync(Car car);
	Task ClearAsync();
}