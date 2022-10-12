using System;
using System.Linq;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands.EditBookPages {
	public class DeleteBookPageCommand : ICommand<Book> {
		public string Description { get; }

		public DeleteBookPageCommand(string description) {
			Description = description;
		}

		public void Execute(Book book) {
			Console.WriteLine("Введите номер удаляемой страницы");

			Console.WriteLine("Вывести страницы?");
			Console.WriteLine("1: Да");
			Console.WriteLine("0: Нет");

			var printSelector = ConsoleReadHelper.ReadInt(" => ", 0, 1);
			if (printSelector == 1)
				PrintHelper.PrintWithPause(book.Pages.Select((page, i) => $"{Environment.NewLine}Страница #{i + 1}{Environment.NewLine}{page}"));

			Console.WriteLine("Введите 0 для отмены");
			var pageSelector = ConsoleReadHelper.ReadInt(" => ", 0, book.Pages.Count);
			if (pageSelector == 0)
				return;

			book.Pages.RemoveAt(pageSelector - 1);
		}
	}
}