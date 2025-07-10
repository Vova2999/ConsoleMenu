namespace ConsoleMenu.Core.Logic;

public interface IMenu<in TValue>
{
	Task StartAsync(TValue value);
}