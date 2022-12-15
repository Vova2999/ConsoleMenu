using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands {
	public class DeleteBookCommand : ICommand<ValueWrapper<IList<Book>>> {
		public string Description { get; }

		public DeleteBookCommand(string description) {
			Description = description;
		}

		public Task ExecuteAsync(ValueWrapper<IList<Book>> wrapper) {
			Console.WriteLine("Введите номер удаляемой книги");

			Console.WriteLine("Вывести книги?");
			Console.WriteLine("1: Да");
			Console.WriteLine("0: Нет");

			var printSelector = ConsoleReadHelper.ReadInt(" => ", 0, 1);
			if (printSelector == 1)
				PrintHelper.PrintWithPause(wrapper.Value.Select((book, i) => $"{Environment.NewLine}Книга #{i + 1}{Environment.NewLine}Название: {book.Title}, Автор: {book.Author}, Количество страниц: {book.Pages.Count}"));

			Console.WriteLine("Введите 0 для отмены");
			var bookSelector = ConsoleReadHelper.ReadInt(" => ", 0, wrapper.Value.Count);
			if (bookSelector == 0)
				return Task.CompletedTask;

			wrapper.Value.RemoveAt(bookSelector - 1);

			return Task.CompletedTask;
		}
	}
}