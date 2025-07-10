namespace ConsoleMenu.Core.Logic.Menus.WithListValues;

public class SubMenuWithListValues<TValue> : MenuWithListValues<TValue>, ISubMenu<IEnumerable<TValue>>
{
	protected override string BackCommandDescription => "Назад";

	public string Description { get; }

	public SubMenuWithListValues(ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(command, getValueDescription)
	{
		Description = command.Description;
	}

	public SubMenuWithListValues(bool isBackAfterExecute, ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(isBackAfterExecute, command, getValueDescription)
	{
		Description = command.Description;
	}

    protected override string? GetHeader(IEnumerable<TValue> value)
    {
        return Description;
    }
}