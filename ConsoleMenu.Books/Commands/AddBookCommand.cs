using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands {
	public class AddBookCommand : ICommand<ValueWrapper<IList<Book>>> {
		public string Description { get; }

		public AddBookCommand(string description) {
			Description = description;
		}

		public Task ExecuteAsync(ValueWrapper<IList<Book>> wrapper) {
			Console.Write("Введите название книги => ");
			var title = Console.ReadLine();

			Console.Write("Введите автора книги => ");
			var author = Console.ReadLine();

			wrapper.Value.Add(new Book { Title = title, Author = author, Pages = new List<string>() });

			return Task.CompletedTask;
		}
	}
}