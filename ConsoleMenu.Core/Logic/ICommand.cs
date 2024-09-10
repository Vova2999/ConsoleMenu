using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic;

public interface ICommand
{
	string Description { get; }
	bool IsBackAfterExecute { get; }
	Task ExecuteAsync();
}