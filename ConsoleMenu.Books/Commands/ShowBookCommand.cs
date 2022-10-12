using System;
using System.Linq;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands {
	public class ShowBookCommand : ICommand<Book> {
		public string Description { get; }

		public ShowBookCommand(string description) {
			Description = description;
		}

		public void Execute(Book book) {
			Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Количество страниц: {book.Pages.Count}");

			Console.WriteLine("Вывести страницы?");
			Console.WriteLine("1: Да");
			Console.WriteLine("0: Нет");

			var printSelector = ConsoleReadHelper.ReadInt(" => ", 0, 1);
			if (printSelector == 1)
				PrintHelper.PrintWithPause(book.Pages.Select((page, i) => $"{Environment.NewLine}Страница #{i + 1}{Environment.NewLine}{page}"));

			PrintHelper.ReadKeyForContinue();
		}
	}
}