namespace ConsoleMenu.Core.Logic.Menus {
	public class MainMenu<TValue> : Menu<TValue> {
		protected override string BackCommandDescription => "Выход";

		public MainMenu(params ICommand<TValue>[] commands) : this(default(TValue), commands) {
		}
		public MainMenu(TValue value, params ICommand<TValue>[] commands) : this(new ValueWrapper<TValue> { Value = value }, commands) {
		}
		public MainMenu(ValueWrapper<TValue> wrapper, params ICommand<TValue>[] commands) : base(wrapper, commands) {
		}
	}
}