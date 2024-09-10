using System;
using System.Collections.Generic;
using System.IO;
using ConsoleMenu.Books.Commands;
using ConsoleMenu.Books.Commands.EditBookPages;
using ConsoleMenu.Books.Commands.EditBookProperties;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Books.Menus;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus.WithCommands;

namespace ConsoleMenu.Books;

public static class Program
{
	private const string BooksFileName = "Books.xml";

	public static void Main()
	{
		try
		{
			ReadBooksAndStartMenu();
		}
		catch (Exception exception)
		{
			Console.WriteLine(exception);
			PrintHelper.ReadKeyForContinue();
		}
	}

	private static void ReadBooksAndStartMenu()
	{
		var wrapper = new ValueWrapper<IList<Book>> { Value = ReadBooks() };

		CreateMenu().Start(wrapper);
		WriteBooks(wrapper.Value);
	}

	private static IList<Book> ReadBooks()
	{
		if (!File.Exists(BooksFileName))
			return new List<Book>();

		try
		{
			var books = XmlSerializerHelper.Deserializing<List<Book>>(File.ReadAllBytes(BooksFileName));
			books.ForEach(book => book.Pages ??= new List<string>());
			return books;
		}
		catch
		{
			return new List<Book>();
		}
	}

	private static void WriteBooks(IList<Book> books)
	{
		File.WriteAllBytes(BooksFileName, XmlSerializerHelper.Serializing(books));
	}

	private static IMenu<ValueWrapper<IList<Book>>> CreateMenu()
	{
		return new MainMenuWithCommands<ValueWrapper<IList<Book>>>(
			new ShowBooksCommand("Показать список книг"),
			new SubMenuConvertCommand<ValueWrapper<IList<Book>>, IReadOnlyList<Book>>(
				new BookTitleSubMenuWithListValues(
					new ShowBookCommand("Показать книгу")),
				wrapper => (IReadOnlyList<Book>) wrapper.Value),
			new AddBookCommand("Добавить книгу"),
			new DeleteBookCommand("Удалить книгу"),
			new SubMenuConvertCommand<ValueWrapper<IList<Book>>, IReadOnlyList<Book>>(
				new BookTitleSubMenuWithListValues(
					new SubMenuCommand<Book>(
						new SubMenuWithCommands<Book>("Редактировать книгу",
							new EditBookTitleCommand("Редактировать название"),
							new EditBookAuthorCommand("Редактировать автора"),
							new SubMenuCommand<Book>(
								new SubMenuWithCommands<Book>("Редактировать страницы",
									new AddBookPageCommand("Добавить страницу"),
									new EditBookPageCommand("Редактировать страницу"),
									new DeleteBookPageCommand("Удалить страницу")))))),
				wrapper => (IReadOnlyList<Book>) wrapper.Value),
			new SubMenuConvertCommand<ValueWrapper<IList<Book>>, IReadOnlyList<Book>>(
				new SubMenuWithCommands<IReadOnlyList<Book>>("Редактировать книгу 2",
					new SubMenuCommand<IReadOnlyList<Book>>(
						new BookTitleSubMenuWithListValues(
							new EditBookTitleCommand("Редактировать название"))),
					new SubMenuCommand<IReadOnlyList<Book>>(
						new BookTitleSubMenuWithListValues(
							new EditBookAuthorCommand("Редактировать автора"))),
					new SubMenuCommand<IReadOnlyList<Book>>(
						new BookTitleSubMenuWithListValues(
							new SubMenuCommand<Book>(
								new SubMenuWithCommands<Book>("Редактировать страницы",
									new AddBookPageCommand("Добавить страницу"),
									new EditBookPageCommand("Редактировать страницу"),
									new DeleteBookPageCommand("Удалить страницу")))))),
				wrapper => (IReadOnlyList<Book>) wrapper.Value));
	}
}