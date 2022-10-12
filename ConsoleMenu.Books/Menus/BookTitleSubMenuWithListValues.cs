using ConsoleMenu.Books.Entities;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Menus.WithListValues;

namespace ConsoleMenu.Books.Menus {
	public class BookTitleSubMenuWithListValues : SubMenuWithListValues<Book> {
		public BookTitleSubMenuWithListValues(string description, ICommand<Book> command) : base(description, command, book => book.Title) {
		}
	}
}