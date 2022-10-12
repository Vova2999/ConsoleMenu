using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands {
	public class CleanCommand<TValue> : ICommand<ValueWrapper<TValue>> {
		public string Description => "Очистить";

		private readonly TValue cleanValue;

		public CleanCommand(TValue cleanValue = default) {
			this.cleanValue = cleanValue;
		}

		public void Execute(ValueWrapper<TValue> wrapper) {
			wrapper.Value = cleanValue;
		}
	}
}