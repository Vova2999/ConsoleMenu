using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic;

public interface ICommand<in TValue>
{
	string Description { get; }
	bool IsBackAfterExecute { get; }
	Task ExecuteAsync(TValue value);
}