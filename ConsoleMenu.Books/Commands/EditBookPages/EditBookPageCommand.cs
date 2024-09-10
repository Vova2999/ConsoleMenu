using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Extensions;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands.EditBookPages;

public class EditBookPageCommand : ICommand<Book>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public EditBookPageCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public Task ExecuteAsync(Book book)
	{
		Console.WriteLine("Вывести страницы?");
		Console.WriteLine("1: Да");
		Console.WriteLine("0: Нет");

		var printSelector = ConsoleReadHelper.ReadInt(" => ", 0, 1);
		if (printSelector == 1)
			PrintHelper.PrintWithPause(book.Pages.Select((page, i) => $"{Environment.NewLine}Страница #{i + 1}{Environment.NewLine}{page}"));

		Console.WriteLine("Введите номер редактируемой страницы");
		Console.WriteLine("Введите 0 для отмены");
		var pageSelector = ConsoleReadHelper.ReadInt(" => ", 0, book.Pages.Count);
		if (pageSelector == 0)
			return Task.CompletedTask;

		Console.WriteLine("Введите новую страницу. Конец ввода - пустая строка");

		var lines = new List<string>();
		while (true)
		{
			var line = Console.ReadLine();
			if (line.IsNullOrEmpty())
				break;

			lines.Add(line);
		}

		book.Pages.RemoveAt(pageSelector - 1);
		book.Pages.Insert(pageSelector - 1, string.Join(Environment.NewLine, lines));

		return Task.CompletedTask;
	}
}