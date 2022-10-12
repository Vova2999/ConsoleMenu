namespace ConsoleMenu.Core.Logic {
	public interface ICommand<TValue> {
		string Description { get; }
		void Execute(ValueWrapper<TValue> wrapper);
	}
}