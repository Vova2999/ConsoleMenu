using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus.WithCommands;
using ConsoleMenu.Core.Logic.Menus.WithListValues;

namespace ConsoleMenu.CarDealership.Commands;

public class EditCarsByMakeYearWithCommandsCommand : SubMenuConvertCommand<IEnumerable<int>>
{
    public EditCarsByMakeYearWithCommandsCommand(string description, Func<int, string> getDescription, ICarDb carDb, params ICommand<IEnumerable<Car>>[] commands)
        : base(new SubMenuWithListValues<int>(
                new SubMenuConvertCommand<int, IEnumerable<Car>>(
                    new SubMenuWithCommands<IEnumerable<Car>>(
                        description,
                        cars => getDescription(cars.First().MakeYear),
                        commands),
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
            })
    {
    }
}