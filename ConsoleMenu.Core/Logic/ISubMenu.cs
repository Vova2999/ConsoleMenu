namespace ConsoleMenu.Core.Logic {
	public interface ISubMenu<in TValue> : IMenu<TValue> {
		string Description { get; }
	}
}