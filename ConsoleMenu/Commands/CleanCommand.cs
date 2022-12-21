using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Commands {
	public class CleanCommand<TValue> : ICommand<ValueWrapper<TValue>> {
		public string Description { get; }

		private readonly TValue _cleanValue;

		public CleanCommand(string description, TValue cleanValue = default) {
			Description = description;
			_cleanValue = cleanValue;
		}

		public void Execute(ValueWrapper<TValue> wrapper) {
			wrapper.Value = _cleanValue;
		}
	}
}