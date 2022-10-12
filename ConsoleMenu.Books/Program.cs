using System;
using System.Collections.Generic;
using System.IO;
using ConsoleMenu.Books.Commands;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Menus;
using ConsoleMenu.Core.Logic.Menus.Static;

namespace ConsoleMenu.Books {
	public static class Program {
		private const string BooksFileName = "Books.xml";

		public static void Main(string[] args) {
			try {
				ReadBooksAndStartMenu();
			}
			catch (Exception exception) {
				Console.WriteLine(exception);
			}
		}

		private static void ReadBooksAndStartMenu() {
			var books = ReadBooks();
			CreateMenu(books).Start();
			WriteBooks(books);
		}

		private static IList<Book> ReadBooks() {
			//if (!File.Exists(BooksFileName))
			//	return new List<Book>();

			//try {
			//	return XmlSerializerHelper.Deserializing<List<Book>>(File.ReadAllBytes(BooksFileName));
			//}
			//catch {
			//	return new List<Book>();
			//}

			return new List<Book> {
				new Book { Title = "Title1", Author = "Author1", PagesCount = 100 },
				new Book { Title = "Title2", Author = "Author2", PagesCount = 200 },
				new Book { Title = "Title3", Author = "Author3", PagesCount = 300 }
			};
		}

		private static void WriteBooks(IList<Book> books) {
			//File.WriteAllBytes(BooksFileName, XmlSerializerHelper.Serializing(books));
		}

		private static BaseMenu<IList<Book>> CreateMenu(IList<Book> books) {
			var wrapper = new ValueWrapper<IList<Book>> { Value = books };
			return new StaticMainMenu<IList<Book>>(wrapper, new ShowBooksCommand());
		}
	}
}