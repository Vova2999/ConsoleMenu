using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.CarDealership.Commands;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.CarDealership.Services;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus.WithCommands;
using ConsoleMenu.Core.Logic.Menus.WithListValues;

namespace ConsoleMenu.CarDealership;

public static class Program
{
	private const string CarsFileName = "Cars.xml";

	public static async Task Main()
	{
		ICarDb carDb = new CarDb();
		ICarFinder carFinder = new CarFinder(carDb);

		try
		{
			await ReadCarsAndStartMenuAsync(carDb, carFinder).ConfigureAwait(false);
		}
		catch (Exception exception)
		{
			Console.WriteLine(exception);
			PrintHelper.ReadKeyForContinue();
		}
	}

	private static async Task ReadCarsAndStartMenuAsync(ICarDb carDb, ICarFinder carFinder)
	{
		foreach (var car in ReadCars())
			await carDb.AddAsync(car).ConfigureAwait(false);

		await CreateMenu(carDb, carFinder).StartAsync().ConfigureAwait(false);

		WriteCars(await carDb.GetAllAsync().ConfigureAwait(false));
	}

	private static IEnumerable<Car> ReadCars()
	{
		if (!File.Exists(CarsFileName))
			return new List<Car>();

		try
		{
			return XmlSerializerHelper.Deserializing<List<Car>>(File.ReadAllBytes(CarsFileName));
		}
		catch
		{
			return new List<Car>();
		}
	}

	private static void WriteCars(IEnumerable<Car> cars)
	{
		File.WriteAllBytes(CarsFileName, XmlSerializerHelper.Serializing(cars.ToArray()));
	}

	private static IMenu CreateMenu(ICarDb carDb, ICarFinder carFinder)
	{
		return new MainMenuWithCommands(
			new ShowCarsCommand("Показать все машины", carDb),
			new AddCarCommand("Добавить новую машину", carDb),
			new SubMenuConvertCommand<IReadOnlyList<Car>>(
				new SubMenuWithListValues<Car>(
					true,
					new DeleteCarCommand("Удалить машину", carDb),
					car => car.Name),
				carDb.GetAllAsync
			),
			new FindCarByNameCommand("Поиск по имени", carFinder),
			new FindCarByMakeYearCommand("Поиск по году выпуска", carFinder),
			new FindCarByEngineCapacityCommand("Поиск по мощности двигателя", carFinder),
			new FindCarByCostCommand("Поиск по стоимости", carFinder),
			new SubMenuConvertCommand<IEnumerable<int>>(
				new SubMenuWithListValues<int>(
					new SelectCommand<int, IEnumerable<Car>>(
						new ShowSelectedCarsCommand("Показать машины по году выпуска"),
						async makeYear =>
						{
							var cars = await carDb.GetAllAsync().ConfigureAwait(false);
							return cars.Where(c => c.MakeYear == makeYear);
						}),
					makeYear => makeYear.ToString()),
				async () =>
				{
					var cars = await carDb.GetAllAsync().ConfigureAwait(false);
					return cars.Select(c => c.MakeYear).Distinct().OrderBy(x => x);
				}),
			new SubMenuConvertCommand<IEnumerable<int>>(
				new SubMenuWithListValues<int>(
					new SubMenuConvertCommand<int, IEnumerable<Car>>(
						new SubMenuWithCommands<IEnumerable<Car>>(
							"Редактирование машин по году выпуска",
							cars => $"Редактирование машин с годом выпуска {cars.First().MakeYear}",
							new ShowSelectedCarsCommand("Показать машины"),
							new DeleteSelectedCarsCommand("Удалить машины", carDb, true)),
						async makeYear =>
						{
							var cars = await carDb.GetAllAsync().ConfigureAwait(false);
							return cars.Where(c => c.MakeYear == makeYear);
						}),
					makeYear => makeYear.ToString()),
				async () =>
				{
					var cars = await carDb.GetAllAsync().ConfigureAwait(false);
					return cars.Select(c => c.MakeYear).Distinct().OrderBy(x => x);
				}));
	}
}