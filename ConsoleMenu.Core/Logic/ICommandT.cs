namespace ConsoleMenu.Core.Logic;

public interface ICommand<in TValue>
{
	string Description { get; }
	bool IsBackAfterExecute { get; }
	void Execute(TValue value);
}