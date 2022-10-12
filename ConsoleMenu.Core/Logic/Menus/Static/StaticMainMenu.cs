namespace ConsoleMenu.Core.Logic.Menus.Static {
	public class StaticMainMenu<TValue> : StaticMenu<TValue>, IMenu {
		protected override string BackCommandDescription => "Выход";

		public StaticMainMenu(params ICommand<TValue>[] commands) : this(default(TValue), commands) {
		}
		public StaticMainMenu(TValue value,
							  params ICommand<TValue>[] commands) : this(new ValueWrapper<TValue> { Value = value }, commands) {
		}
		public StaticMainMenu(ValueWrapper<TValue> wrapper,
							  params ICommand<TValue>[] commands) : base(wrapper, commands) {
		}
	}
}