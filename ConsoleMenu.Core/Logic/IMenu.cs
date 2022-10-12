namespace ConsoleMenu.Core.Logic {
	public interface IMenu<in TValue> {
		void Start(TValue value);
	}
}