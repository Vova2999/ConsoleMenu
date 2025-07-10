using System.Collections.Generic;
using ConsoleMenu.CarDealership.DataBase;
using ConsoleMenu.CarDealership.Entities;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus.WithListValues;

namespace ConsoleMenu.CarDealership.Commands;

public class DeleteCarWithListValuesCommand : SubMenuConvertCommand<IReadOnlyList<Car>>
{
    public DeleteCarWithListValuesCommand(string description, ICarDb carDb)
        : base(new SubMenuWithListValues<Car>(
                true,
                new DeleteCarCommand(description, carDb),
                car => car.Name),
            carDb.GetAllAsync)
    {
    }
}