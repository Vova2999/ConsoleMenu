using System;
using System.Collections.Generic;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands;

public class AddBookCommand : ICommand<ValueWrapper<IList<Book>>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public AddBookCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public void Execute(ValueWrapper<IList<Book>> wrapper)
	{
		Console.Write("Введите название книги => ");
		var title = Console.ReadLine();

		Console.Write("Введите автора книги => ");
		var author = Console.ReadLine();

		wrapper.Value.Add(new Book { Title = title, Author = author, Pages = new List<string>() });
	}
}