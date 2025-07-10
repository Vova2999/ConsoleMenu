using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus.WithListValues;

namespace ConsoleMenu.CarDealership.Commands;

public class FindCarByMakeYearWithListYearsCommand : SubMenuConvertCommand<IEnumerable<int>>
{
    public FindCarByMakeYearWithListYearsCommand(string description, ICarDb carDb)
        : base(new SubMenuWithListValues<int>(
                new SelectCommand<int, IEnumerable<Car>>(
                    new ShowSelectedCarsCommand(description),
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