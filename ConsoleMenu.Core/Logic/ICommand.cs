namespace ConsoleMenu.Core.Logic;

public interface ICommand
{
	string Description { get; }
	void Execute();
}