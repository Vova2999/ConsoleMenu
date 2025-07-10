using ConsoleMenu.CarDealership.Commands;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.CarDealership.Helpers;
using ConsoleMenu.CarDealership.Services;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Menus.WithCommands;

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
            new DeleteCarWithListValuesCommand("Удалить машину", carDb),
            new FindCarByNameCommand("Поиск по имени", carFinder),
            new FindCarByMakeYearCommand("Поиск по году выпуска", carFinder),
            new FindCarByEngineCapacityCommand("Поиск по мощности двигателя", carFinder),
            new FindCarByCostCommand("Поиск по стоимости", carFinder),
            new FindCarByMakeYearWithListYearsCommand("Показать машины по году выпуска", carDb),
            new EditCarsByMakeYearWithCommandsCommand(
                "Редактирование машин по году выпуска",
                makeYear => $"Редактирование машин с годом выпуска {makeYear}",
                carDb,
                new ShowSelectedCarsCommand("Показать машины"),
                new DeleteSelectedCarsCommand("Удалить машины", carDb, true)));
    }
}