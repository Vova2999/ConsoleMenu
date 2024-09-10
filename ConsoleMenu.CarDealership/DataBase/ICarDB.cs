using System.Collections.Generic;
using ConsoleMenu.CarDealership.Entities;

namespace ConsoleMenu.CarDealership.DataBase;

public interface ICarDb
{
	IReadOnlyList<Car> Cars { get; }

	void Add(Car car);
	void Delete(Car car);
	void Clear();
}