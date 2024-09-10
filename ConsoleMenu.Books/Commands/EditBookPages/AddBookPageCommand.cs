using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Extensions;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands.EditBookPages;

public class AddBookPageCommand : ICommand<Book>
{
	public string Description { get; }

	public AddBookPageCommand(string description)
	{
		Description = description;
	}

	public void Execute(Book book)
	{
		Console.WriteLine("Введите новую страницу. Конец ввода - пустая строка");

		var lines = new List<string>();
		while (true)
		{
			var line = Console.ReadLine();
			if (line.IsNullOrEmpty())
				break;

			lines.Add(line);
		}

		Console.WriteLine("Введите номер для вставки страницы");

		Console.WriteLine("Вывести страницы?");
		Console.WriteLine("1: Да");
		Console.WriteLine("0: Нет");

		var printSelector = ConsoleReadHelper.ReadInt(" => ", 0, 1);
		if (printSelector == 1)
			PrintHelper.PrintWithPause(book.Pages.Select((page, i) => $"{Environment.NewLine}Страница #{i + 1}{Environment.NewLine}{page}"));

		Console.WriteLine("Введите -1 для вставки в конец, 0 для отмены");
		var pageSelector = ConsoleReadHelper.ReadInt(" => ", -1, book.Pages.Count);
		if (pageSelector == 0)
			return;

		if (pageSelector == -1)
			book.Pages.Add(string.Join(Environment.NewLine, lines));
		else
			book.Pages.Insert(pageSelector - 1, string.Join(Environment.NewLine, lines));
	}
}