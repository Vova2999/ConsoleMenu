using System;
using System.Collections.Generic;

namespace ConsoleMenu.Core.Logic.Menus.WithListValues {
	public class MainMenuWithListValues<TValue> : MenuWithListValues<TValue>, IMenu<IList<TValue>> {
		protected override string BackCommandDescription => "Выход";

		public MainMenuWithListValues(ICommand<TValue> command, Func<TValue, string> getValueDescription) : base(command, getValueDescription) {
		}
	}
}