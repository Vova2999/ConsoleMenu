using System;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands.EditBookProperties;

public class EditBookTitleCommand : ICommand<Book>
{
	public string Description { get; }

	public EditBookTitleCommand(string description)
	{
		Description = description;
	}

	public void Execute(Book book)
	{
		Console.Write("Введите заголовок => ");
		book.Title = Console.ReadLine();
	}
}