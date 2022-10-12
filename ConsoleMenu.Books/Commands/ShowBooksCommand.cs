using System;
using System.Collections.Generic;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands {
	public class ShowBooksCommand : ICommand<IList<Book>> {
		public string Description => "Показать книги";

		public void Execute(ValueWrapper<IList<Book>> wrapper) {
			foreach (var book in wrapper.Value)
				Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, PagesCount: {book.PagesCount}");
		}
	}
}