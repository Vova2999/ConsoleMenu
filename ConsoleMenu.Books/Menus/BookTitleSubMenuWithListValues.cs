using ConsoleMenu.Books.Entities;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Menus.WithListValues;

namespace ConsoleMenu.Books.Menus;

public class BookTitleSubMenuWithListValues : SubMenuWithListValues<Book>
{
	public BookTitleSubMenuWithListValues(ICommand<Book> command) : base(command, book => book.Title)
	{
	}
}