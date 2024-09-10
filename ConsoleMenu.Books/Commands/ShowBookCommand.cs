using System;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands;

public class ShowBookCommand : ICommand<Book>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public ShowBookCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public Task ExecuteAsync(Book book)
	{
		Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Количество страниц: {book.Pages.Count}");

		Console.WriteLine("Вывести страницы?");
		Console.WriteLine("1: Да");
		Console.WriteLine("0: Нет");

		var printSelector = ConsoleReadHelper.ReadInt(" => ", 0, 1);
		if (printSelector == 1)
			PrintHelper.PrintWithPause(book.Pages.Select((page, i) => $"{Environment.NewLine}Страница #{i + 1}{Environment.NewLine}{page}"));

		PrintHelper.ReadKeyForContinue();

		return Task.CompletedTask;
	}
}