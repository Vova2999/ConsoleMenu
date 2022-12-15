using System.Threading.Tasks;

namespace ConsoleMenu.Core.Logic {
	public interface ICommand<in TValue> {
		string Description { get; }
		Task ExecuteAsync(TValue value);
	}
}