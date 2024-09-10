namespace ConsoleMenu.Core.Logic;

public interface ICommand<in TValue>
{
	string Description { get; }
	void Execute(TValue value);
}